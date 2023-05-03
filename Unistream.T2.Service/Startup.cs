using Unistream.T2.Business.Handlers;
using Unistream.T2.DataAccess.Storages;
using Unistream.T2.DataAccess.Storages.Abstractions;
using Unistream.T2.Domain.Entities;
using Unistream.T2.Service.Converters;

namespace Unistream.T2.Service
{
    internal class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IStorage<Entity>, EntityInMemoryStorage>();
            services.AddSingleton<IEntityHandler, EntityHandler>();
            services.AddSingleton<IJsonConverter, JsonConverter>();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
