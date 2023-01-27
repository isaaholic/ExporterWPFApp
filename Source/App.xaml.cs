using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Source.Services;
using Source.ViewModels;
using Source.Views;
using System.Windows;

namespace Source
{
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<EmployeeViewModel>();
                    services.AddTransient<IEmployeeService, EmployeeService>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            var startUpFrom = AppHost.Services.GetRequiredService<MainWindow>();
            startUpFrom.DataContext = AppHost.Services.GetService<EmployeeViewModel>();
            startUpFrom.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();
            base.OnExit(e);
        }
    }
}
