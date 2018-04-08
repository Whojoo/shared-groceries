using Autofac;
using SharedGrocery.GroceryService.Api;
using SharedGrocery.GroceryService.Api.Repository;
using SharedGrocery.GroceryService.Api.Service;
using SharedGrocery.GroceryService.Repository;
using SharedGrocery.GroceryService.Service;

namespace SharedGrocery.GroceryService.DI
{
    public static class GroceryModules
    {
        public static void RegisterModules(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<GroceryListService>().As<IGroceryListService>();
            containerBuilder.RegisterType<GroceryListRepository>().As<IGroceryListRepository>();
        }
    }
}