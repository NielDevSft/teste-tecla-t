using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace MaterialConstrucao.Api.Middlewares
{
    public static class SwaggerMiddleware
    {
        public static void AddSwaggerMiddleware(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Material Construcão API", Version = "v1" })
            );
        }
    }
}
