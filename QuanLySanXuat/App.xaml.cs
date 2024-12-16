using Microsoft.Extensions.DependencyInjection;
using QuanLySanXuat.Views;
using System.Configuration;
using System.Data;
using System.Windows;

namespace QuanLySanXuat
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider _serviceProvider;
        protected override void OnStartup(StartupEventArgs e)// ghi đè phương thức
        {
            base.OnStartup(e);
            var startUp = new Startup();
            // Lấy ServiceProvider từ Startup
            _serviceProvider = startUp.ServiceProvider;

            
        }

    }

}
