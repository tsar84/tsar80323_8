using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using tsar80323.DAL.Entities;
using Microsoft.EntityFrameworkCore;



namespace tsar80323.DAL.Data
{
   public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishGroup> DishGroups { get; set; }





        public  ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {







       }
    }
}
