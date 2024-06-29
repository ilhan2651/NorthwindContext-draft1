using Core.Data_Access.EntityFramework;
using DataAccess.Abstract;
using Entitites.Concrete;
using Entitites.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.products
                             join c in context.categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto { ProductId=p.ProductId,ProductName =p.ProductName,CategoryName=c.CategoryName,UnitsInStock=p.UnitInStock};
                return result.ToList();


            }
          
        }
    }
}
