using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Entities
{
    public class Drink : IEntity
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public string ImageSrc { get; set; }
    }
}
