using Abc.Core.DataAccsess.EntityFramework;
using Abc.Northwind.DataAccess.Abstract;
using Abc.Northwind.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Northwind.DataAccess.Concrate.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {
    }
}
