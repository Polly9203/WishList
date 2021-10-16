using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WishList.Models
{
    public class WishModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Link { get; set; }
    }
}
