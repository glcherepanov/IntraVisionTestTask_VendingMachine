using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Entities
{
    public class Coin : IEntity
    {
        public int Id { get; set; }
        public int Denomination { get; set; }
        public int Count { get; set; }
        public bool IsAvaliable { get; set; }
    }
}
