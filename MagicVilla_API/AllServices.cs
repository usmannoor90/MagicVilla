using Microsoft.OpenApi.Models;

namespace MagicVilla_Services
{
    public static class AllServices
    {

        public static IServiceCollection RegisterServicesMethod(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(opt =>
            {
                var title = "Our Version API";
                var description = "this is our web api";

                opt.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "v1",
                    Title = title + " v1",
                    Description = description,
                });
                opt.SwaggerDoc("v2", new OpenApiInfo()
                {
                    Version = "v2",
                    Title = title + " v2",
                    Description = description,
                });


            });
            return services;
        }
    }
}
