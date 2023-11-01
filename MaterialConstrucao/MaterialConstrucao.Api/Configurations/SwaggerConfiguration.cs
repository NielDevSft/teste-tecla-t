using Microsoft.AspNetCore.Builder;

namespace MaterialConstrucao.Api.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Material Construcão API V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
