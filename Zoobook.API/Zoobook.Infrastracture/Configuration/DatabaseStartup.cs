//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;

//using System;
//using Zoobook.Infrastracture.Context;

//namespace Zoobook.Infrastructure.Configuration
//{
//    public static class DatabaseConfiguration
//    {
//        public static IServiceCollection AddDatabaseModule(this IServiceCollection @this)
//        {
//            //ZoobookContext
//            @this.AddDbContext<ZoobookContext>(context => context.UseSqlServer(ManageAppSetting.GetConnectionString("ZoobookConnection")));
           
//            return @this;
//        }
//    }
//}
