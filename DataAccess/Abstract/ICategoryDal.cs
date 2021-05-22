using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICategoryDal :IEntityRepository<Category>// Generic Repository Desingn Pattern
    {
                     //interface metotları default publictir. Interface'in kendisi değil.
       
    }
}
