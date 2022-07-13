using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContextDal>, ICarDal
    {
        public List<CarDetailDto> GetCarDetail()
        {
            using (ReCapContextDal context = new ReCapContextDal())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto 
                             {
                                 CarName = c.CarName, BrandName = b.BrandName, 
                                 ColorName = co.ColorName, DailyPrice = c.DailyPrice
                             };

                return result.ToList();
            }
        }
    }
}
