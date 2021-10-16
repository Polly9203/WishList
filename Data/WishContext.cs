using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WishList.Models;


namespace WishList.Data
{
    public class WishContext : DbContext
    {
        public DbSet<Wish> Wishes { get; set; }

        public WishContext(DbContextOptions<WishContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
