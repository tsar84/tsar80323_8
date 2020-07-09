using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tsar80323_4.dal.Entities;

namespace Tsar80323_4.dal.Data
{
    class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public
        ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }
    }
}