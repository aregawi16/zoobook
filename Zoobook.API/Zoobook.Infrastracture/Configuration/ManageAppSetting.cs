

//using Microsoft.Extensions.Configuration;

//namespace Zoobook.Infrastructure.Configuration;

//public class ManageAppSetting
//{
//    public static IConfiguration AppSetting { get; }


//    static ManageAppSetting()
//    {
//        AppSetting = new ConfigurationBuilder()
//                .SetBasePath(Directory.GetCurrentDirectory())
//                .AddJsonFile("appsettings.json")
//                .Build();
//    }

//    public static string GetSettingValueByKey(string key)
//    {
//        var value = Configuration().GetValue<string>(key);

//        return value;
//    }
//    public static string GetConnectionString(string key = null)
//    {
//        var value = Configuration().GetConnectionString(key ?? "DefaultConnection");

//        return value;
//    }

//    private static IConfiguration Configuration()
//    {
//        var builder = new ConfigurationBuilder();

//        builder.SetBasePath(Directory.GetCurrentDirectory());
//        builder.AddJsonFile("appsettings.json")
//            .AddEnvironmentVariables();

//        var configuration = builder.Build();

//        return configuration;
//    }
//}
