﻿using Abc.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Northwind.Entities.Concrate
{
    public class Category:IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
