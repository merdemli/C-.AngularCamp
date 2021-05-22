using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    // context: DB tabloları ile proje class'larını bağlamak için kullanılan class'tır ve connection string yazılır
    public class NorthwindContext : DbContext //EF: Nuget ile gelen base bir sınıftır
    {

        //projen hangi db ile ilişkili belirtecepin yer

        //abstract class//DB context'ten geliyor
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // connection string; 
            // ters slaş kullanıldığında çift \ kullanırız,@ : başına @ koydugunda normal \ olarak algıla demek
                                       
                                       //@" Server =175.45.2.12"                 //kullanıcı adı şifre de yazılabilir
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");

        }
        //context hangi db'ye bağlanacağımızı buldu.Şimdi hangi tablo hangi class'a denk gelecek ,DbSet nesnesi ile yapılır
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}


//SQL: caseInsensitive'dir