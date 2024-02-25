

namespace StaffManagement
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServises(IServiceCollection services)
        { }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) 
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /*app.UseDefaultFiles();

            app.UseStaticFiles();*/

            app.UseFileServer();

            app.UseRouting();

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("MiddleWare 1 dan salom!\n");
                await next();
            });
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("MiddleWare 2 dan salom!\n");
                await next();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Main Page");
                });
                endpoints.MapGet("/user", async context =>
                {
                    await context.Response.WriteAsync("Users Page");
                });
            });
        }

    }
}
