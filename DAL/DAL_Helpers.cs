namespace web_api_curd.DAL
{
    public class DAL_Helpers
    {
        public static string ConnStr = new ConfigurationBuilder().AddJsonFile("appsettings.json")
            .Build()
            .GetConnectionString("DBCS");
    }
}
