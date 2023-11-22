using Autofac;
using MVVMCurrencyConverter.Models;
using MVVMCurrencyConverter.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMCurrencyConverter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var builder = new ContainerBuilder();

            builder.RegisterType<MainWindow>().AsSelf().SingleInstance(); ;
            builder.RegisterType<CurrencyConverter>().AsSelf().SingleInstance(); ;
            builder.RegisterType<CurrencyMaster>().AsSelf().SingleInstance(); ;
            builder.RegisterType<MainViewModel>().AsSelf().SingleInstance(); ;
            builder.RegisterType<DatabaseHandler>().As<IDatabaseHandler>().SingleInstance();
            builder.RegisterType<DataHolderService>().As<IFullDataHandler>().SingleInstance();
            var container  = builder.Build();

            var data = container.Resolve<MainWindow>();
            data.Show();


        }
    }
}
