using Mecalux.Domain.Service;
using Mecalux.Domain.Service.Impl;
using Mecalux.Infraestructure.ApiRest;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Mecalux.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;

        public App()
        {
            ServiceCollection service = new ServiceCollection();
            ConfigureServices(service);
            _serviceProvider = service.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection service)
        {
            service.AddSingleton<WordsUI>();
            service.AddSingleton<ITextService, TextServiceApiRest>();
            service.AddSingleton<ITextAnalyticsService, TextAnalyticsApiRest>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var ui = _serviceProvider.GetService<WordsUI>();
            ui.Show();
        }
    }
}
