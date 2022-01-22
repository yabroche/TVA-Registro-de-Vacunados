using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVA_Registro_de_Vacunados.Data;
using TVA_Registro_de_Vacunados.Data.DataInterface;
using TVA_Registro_de_Vacunados.Mappers;
using TVA_Registro_de_Vacunados.Services;
using TVA_Registro_de_Vacunados.Services.Interfaz;

namespace TVA_Registro_de_Vacunados
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(x =>
            {
                x.UseLazyLoadingProxies();
                x.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IRepositorio, Repositorio>();
            services.AddScoped<IAuthRepositorio, AuthRepositorio>();

            //Agregamos el token services
            services.AddScoped<ITokenServices, TokenService>();


            services.AddAutoMapper(typeof(AutomapperProfiles).Assembly);

            //configuracion par el uso de token
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(Configuration["TokenLlave"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });

            services.AddControllers();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TVA_Registro_de_Vacunados", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TVA_Registro_de_Vacunados v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //Agragando la autenticacion
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
