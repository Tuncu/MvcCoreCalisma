using Abc.Core.DataAccsess;
using Abc.Northwind.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Northwind.DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        //İsteğe bağlı ek operasyonları buradan yapabilirsin
    }   
}
