using Autofac;
using MVVMCurrencyConverter.Models;
using MVVMCurrencyConverter.ViewModel;
using System.Windows;

namespace MVVMCurrencyConverter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected async override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ApiHandling apiHandling = new ApiHandling();
            var builder = new ContainerBuilder();

            builder.RegisterType<MainWindow>().AsSelf().SingleInstance(); ;
            builder.RegisterType<CurrencyConverterViewModel>().AsSelf().SingleInstance(); ;
            builder.RegisterType<CurrencyMasterViewModel>().AsSelf().SingleInstance(); ;
            builder.RegisterType<MainViewModel>().AsSelf().SingleInstance(); ;
            builder.RegisterType<DatabaseHandler>().As<IDatabaseHandler>().SingleInstance();
            builder.RegisterType<DataHolderService>().As<IDataHandler>().SingleInstance();
            var container = builder.Build();


            var dbHandler = container.Resolve<IDatabaseHandler>();

            var result = await apiHandling.GetData("https://openexchangerates.org/api/latest.json?app_id=df6e40d64da8455cb5442e04f2de846d");
            foreach (var item in result.Rates)
            {
                dbHandler.AddOrUpdate(item.Key, item.Value);
            }

            var data = container.Resolve<MainWindow>();
            data.Show();

        }
    }
}
