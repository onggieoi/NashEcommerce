using Microsoft.AspNetCore.Builder;

namespace backend.Extensions
{
    public static class SwaggerAppBuilder
    {
        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "api v1");
                options.RoutePrefix = "swagger";
                options.DisplayRequestDuration();
            });
        }
    }
}