namespace API.Source.Base.Utils
{
    public class AppSettings
    {
        public static string? PostgreSQlConnection { get; set; }

        public static string? JwtKey { get; set; }

        public static void LoadSettings(IConfiguration config)
        {
            PostgreSQlConnection = config.GetValue<string>("ConnectionString");
            JwtKey = config.GetValue<string>("JWT:JwtKey");
        }
    }
}
