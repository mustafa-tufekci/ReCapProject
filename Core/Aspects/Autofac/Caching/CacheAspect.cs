using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            //Hagi cache managerı kullanacaımızı belirtiyoruz
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            //{invocation.Method.ReflectedType} ile methodun namespace ismi ile class ismini alıyoruz. (namspace + class name)
            //{invocation.Method.Name} methodun ismini alıyoruz.
            //invocation.Arguments.ToList(); methodun parametrelerini listeye çevirme.
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            //methodun parametresi var ise alıyoruz yok ise null olarak veriyoruz.
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            //bellekte cache uyan key varmı.
            if (_cacheManager.IsAdd(key))
            {
                //Varsa invocation.ReturnValue return değerini çalıştırmayıp verileri _cacheManager(key) sayiseinde cache üzerinden getiriyor.
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
