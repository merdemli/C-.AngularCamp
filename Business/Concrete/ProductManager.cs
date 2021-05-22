using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;     //data access'e erişiyorum //ne InMemory, ne de EntityFrameWork ismi geçmeyecek

        public ProductManager(IProductDal productDal) //veri erişim alternatifleri olarak, interface kullandık. Business katmanı, Dal'a erişir. 
        {                   //IProductDal referansı ver diyo
            _productDal = productDal;
        }
                                                 //ctor'da new'lendiğinde ona IProductDal vermelisin, yani hangi veri yöntemiyle çalıştığını,//
                                                   //örn inMemory veya EntityFrameWork gibi 
        
        public List<Product> GetAll() //Tüm ürünleri listeleyecek
        {
            //burada iş kodları var(if'ler)  eğer iş kodlarınddan geçiyorsa,business katmanı veri erişim katmanını çağrırız;ürünleri liste olarak verir. Hocanın ilk tablosunu anla
            //Yetkisi var mı?vs.  varsa, veritabanına diyor ki, yani data access'e bana ürünleri verebilirsin diyo, 
            //_productDal referans yerine ürünleri koyuyor gibi düşün

            return _productDal.GetAll();
        }                              //p=>p.CategoryId bu bir expression'dır
                                       //bunun içine expression yazabilmemiz için ,alttaki metot gibi

        public List<Product> GetAllByCategoryid(int id)
        {                                                                //burada istediğimiz metodu yazabiliriz,
                                                                        //Sadece Get ve GetAll metodlarını,içine tanımladığımız 
                                                                        //expreessiona göre kullanıyoruz !!!!
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }
    }              //filtre yazıyoruz
}


//bir iş sınıfı başka sınıfları new'lemez
