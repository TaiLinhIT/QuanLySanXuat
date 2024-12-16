using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanXuat.Models
{
    public class QuanLySanXuatDbcontext : DbContext
    {
        public QuanLySanXuatDbcontext()
        {
        }
        public QuanLySanXuatDbcontext(DbContextOptions<QuanLySanXuatDbcontext> options) : base(options)
        {
        }
        public DbSet<Product> products { get; set; }
    }
}
