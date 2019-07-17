using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class CoreContext: DbContext
    {
        //string connection = "Data Source=127.0.0.1;Database=learn;User ID=root;Password=haosql;pooling=true;CharSet=utf8;port=3306;sslmode=none";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //Database.EnsureCreated();//如果有数据库存在，那么什么也不会发生。但是如果没有，那么就会创建一个数据库
            // optionsBuilder.UseMySQL(connection);
        }

        public CoreContext(DbContextOptions<CoreContext> options):base(options)
        {

        }
        //数据迁移
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<student>().Property(x => x.name).IsRequired();
           // modelBuilder.Entity<Teacher>().ToTable("Teacher");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<student> student { get; set; }
        public DbSet<Teacher> teacher { get; set; }
    }
}
