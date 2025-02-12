namespace Amem.Api.Extensions
{
    public static class HttpRequestExtensions
    {

        public static void HttpRequestPipelineConfig(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sharp Sword API V1"));
                //app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            //app.UseAuthorization();
            //app.UseEndpoints(endpoints => endpoints.MapControllers());
            app.MapControllers();
        }

    }
}