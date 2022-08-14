using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContextDal>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetailDto()
        {
            using (ReCapContextDal context = new ReCapContextDal())
            {
                var result = from re in context.Rentals
                             join c in context.Cars
                             on re.CarId equals c.Id
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             from cu in context.Customers
                             join u in context.Users
                             on cu.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 BrandName = b.BrandName,
                                 ModelName = c.ModelName,
                                 ColorName = co.ColorName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate,
                             };
                return result.ToList();
            }
        }
    }
}
