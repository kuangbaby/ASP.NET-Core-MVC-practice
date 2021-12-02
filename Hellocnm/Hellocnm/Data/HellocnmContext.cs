using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hellocnm.Models;

namespace Hellocnm.Data
{
    public class HellocnmContext : DbContext
    {
        public HellocnmContext (DbContextOptions<HellocnmContext> options)
            : base(options)
        {
        }


        public DbSet<Hellocnm.Models.readerinformation> 读者信息 { get; set; }


        public DbSet<Hellocnm.Models.读者分类> 读者分类 { get; set; }


        public DbSet<Hellocnm.Models.借阅历史> 借阅历史 { get; set; }


       
    }
}
