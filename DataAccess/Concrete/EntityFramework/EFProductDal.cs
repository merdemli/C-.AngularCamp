 using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework

          //NuGET başkalarının yazdığı paket kodlar

          //.NET Core içinde EF paket ile gelir. nuget
{         //ORM : Object Relatinal Mapping;; DB'deki nesnelerle(tablolarla) kodlar arası ilişkiyi kurup,(sql'leri)
          //vertabanı işlerini yapmaya(linQ ile) yarar //
         
    public class EFProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //IDısposable pattern implemention of C# 
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity); //referansı yakalama, yani Northwind contex'e bağla bu entity'i, db ile ilişkilendir
                addedEntity.State = EntityState.Added;   //o aslında eklenecek br nesne,durumu belirtiriz  
                context.SaveChanges();        //ekle kaydet, işlemleri yapar                              


                //göderilen productı veri KAYNAĞINDAA
                //1 tane nesneye eşleştir, ama bu yeni ekleme olacağı için
                //referansı addedEntity'e atıyoruz,veri kaynağına yeni ekleyeceğiz

            }

            //bir class new'lendiğinde garbage collec. belli zaman sonra gelir onları temizler
            //ama using içine yazdığın nesneler, using bitince gc.'e gelip beni bellekten at diyor

        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity); 
                deletedEntity.State = EntityState.Deleted;   
                context.SaveChanges();                                  

            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using(NorthwindContext contex = new NorthwindContext())
            {
                return contex.Set<Product>().SingleOrDefault(filter);//product döndürür
                      //ürünler tablosu
            }
        }
                                                                        //defaultu null olan bir filtre
        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using(NorthwindContext context =new NorthwindContext())
            {
                
                //
                return filter == null ? context.Set<Product>().ToList() 
                                      : context.Set<Product>().Where(filter).ToList();


                //DbSet 'deki, products tablosuna yerleş, listeye çevir bana ver, select * from döndürür
                //filter kısmına lambdalı filtre yazılır
            }

        }
          
        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
