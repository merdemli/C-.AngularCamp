using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{       
    //generic constraint
    //class: referans tip olablir demek
    //IEntity: ya IEntity ya da ondan türeyen bir sınıf olabilir
    //new'lenebilir olmalı, yani IEntity de olmasın , kısıtladık. Soyut işimize yaramaz şuan
     public interface IEntityRepository<T> where T:class,IEntity,new()
        //Bu T'yi sınırlandırmak istiyoruz,T bir referans tip olabilir ve IEntity'den implemente olan bir şey olabilir.

    {                          //null, filtre vermeyebilirsin de demektir,filtre verirse filtreleyip verirsin
        List<T> GetAll(Expression<Func<T,bool>> filter=null);//bununla kategory'e göre getir, ürünün fiyatına göre getir
                                                             //gibi ayrı ayrı metotlar yazman gerekmeyecek
        T Get(Expression<Func<T, bool>> filter); //bir sistemde bir şeyin detyına gitmek için kullanılır
        void Add(T entity);              //interface metotları default publictir. Interface'in kendisi değil.
        void Update(T entity);            //generic repository nesnelerinde bu 5 metot ve id'ye göre geetirme olur
        void Delete(T entity);

        //List<T> GetAllByCategory(int categoryId); yukarıdaki expression'ı yazdıktan sonra bu koda ihtiyacımız kalmayacak
    }
}
