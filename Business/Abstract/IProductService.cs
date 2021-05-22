using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        List <Product> GetAll();                  //hepsini getir
        List<Product> GetAllByCategoryid(int id); //kategori İd'sine göre getir
        List<Product> GetByUnitPrice(decimal min, decimal max);

    }
}
