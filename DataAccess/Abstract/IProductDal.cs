using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal :IEntityRepository<Product>      //veri erişim işlerini yapan bir interface oluşturduk
                                       //aslında entity'i her katmanda kodluyoruz
                                      //Product'ın buradaki karşılığı:iproductdal
    {
       
        //ürünleri category'e göre  filtrele // int : category id
        //e- ticaret sisteminde kategorye basınca, kategorilere göre listeleme yapar
    
    }
}
