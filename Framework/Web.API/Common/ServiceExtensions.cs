namespace Web.API.Common
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureCors(this IServiceCollection services)
        {
            return services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
        }

        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services)
        {
            // Add projects dependency injection configurations here

            return services;
        }
    }
}
