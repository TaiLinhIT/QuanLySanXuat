using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace QuanLySanXuat.Models
{
    public class QuanLySanXuatDbcontext : DbContext
    {
        public QuanLySanXuatDbcontext(DbContextOptions<QuanLySanXuatDbcontext> options) : base(options) { }

        public QuanLySanXuatDbcontext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("AppSetting.json", optional: false, reloadOnChange: true)
                    .Build();

                var connectionString = configuration.GetSection("AppSetting:ConnectionString:DefaultConnection").Value
                    .Replace("{ServerName}", configuration.GetSection("AppSetting:ServerName").Value);

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        // DbSet cho các bảng trong database
        public DbSet<Product> products { get; set; }
    }
}
