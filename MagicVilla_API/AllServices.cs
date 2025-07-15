namespace MagicVilla_Services
{
    public static class AllServices
    {

        public static IServiceCollection RegisterServicesMethod(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }
    }
}
