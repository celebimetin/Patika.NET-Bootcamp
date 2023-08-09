using Core.SharedLibrary.Configurations;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Operation.Order.Handlers;
using WebAPI.Extensions;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CustomTokenOptions>(Configuration.GetSection("TokenOptions"));
            services.Configure<RedisSettings>(Configuration.GetSection("RedisSettings"));


            services.AddControllers().AddFluentValidation();
            services.AddHttpContextAccessor();
            services.AddMediatR(typeof(CreateOrderCommandHandler).Assembly);
            services.AddDbContextExtension(Configuration);
            services.AddRepositoryExtension();
            services.AddServiceExtension();
            services.AddMapperExtension();
            services.AddIdentityExtension();
            services.AddAuthenticationExtension(Configuration);

            services.AddCustomSwaggerExtension();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}