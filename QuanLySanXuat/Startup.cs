using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuanLySanXuat.Models;
using QuanLySanXuat.ViewModel;
using QuanLySanXuat.Views;
using System;
using System.IO;

namespace QuanLySanXuat
{
    public class Startup
    {
        public IServiceProvider ServiceProvider { get; private set; }
        public IConfiguration Configuration { get; private set; }

        public Startup()
        {
            // Đọc file appsettings.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Lấy thư mục hiện tại
                .AddJsonFile("AppSetting.json", optional: false, reloadOnChange: true); // Đọc file JSON

            Configuration = builder.Build(); // Xây dựng cấu hình

            // Đăng ký các dịch vụ vào container
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // Tạo ServiceProvider
                ServiceProvider = serviceCollection.BuildServiceProvider();

            // Tạo và hiển thị cửa sổ chính
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services) 
        {
            // Đăng ký IConfiguration để các lớp khác có thể inject
            services.AddSingleton<IConfiguration>(Configuration);

            // Đọc cấu hình từ appsettings.json
            var appSettings = Configuration.GetSection("AppSetting").Get<AppSetting>();
            // Kiểm tra nếu cấu hình không hợp lệ
            if (appSettings == null || appSettings.ConnectionString == null)
            {
                throw new Exception("AppSettings configuration is invalid.");
            }
            // Sử dụng ServerName trong chuỗi kết nối
            var connectionString = appSettings.ConnectionString.DefaultConnection.Replace("{ServerName}", appSettings.ServerName);

            // Đăng ký DbContext với ConnectionString đã chỉnh sửa
            services.AddDbContext<QuanLySanXuatDbcontext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            // Đăng ký các ViewModel, Service (nếu cần)
            services.AddSingleton<MainViewModel>();

            // Đăng ký cửa sổ chính (MainWindow)
            services.AddSingleton<MainWindow>();
        }
    }
}
