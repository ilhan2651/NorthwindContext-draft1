﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entitites.Concrete;
using Entitites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
   
    public class ProductManager : IProductServices
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {

            if (product.ProductName.Length<2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);

            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            //if (DateTime.Now.Hour==22)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            //}


            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>( _productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId==productId),Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetByUnitPrice(float min, float max)
        {
            return new SuccessDataResult<List<Product>> (_productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max),Messages.ProductsListed);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>> (_productDal.GetProductDetails(),Messages.ProductsListed);
        }
    }
}
