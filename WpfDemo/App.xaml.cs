using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Windows;
using WpfDemo.Services;
using WpfDemo.View.page;
using WpfDemo.View.window;
using WpfDemo.ViewModel;

namespace WpfDemo
{
    public partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();
        }

        public new static App Current => (App)Application.Current;

        public IServiceProvider Services { get; }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<StudentService>();
            services.AddLogging(builder =>
            {
                builder.AddConsole();  // 添加控制台日志
                builder.AddDebug();    // 添加调试日志
                                       // 可以添加其他日志提供程序
                builder.SetMinimumLevel(LogLevel.Information);
            });
            services.AddTransient<StudentViewModel>();
            services.AddTransient<MainWindowModel>();
            services.AddTransient<StudentView>();
            services.AddTransient<CourseView>();
            services.AddTransient<StudentEditWindow>();
            

            services.AddTransient<MainWindow>();

            return services.BuildServiceProvider();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var mainWindow = Services.GetService<MainWindow>();
            mainWindow!.Show();
        }
    }
}
    