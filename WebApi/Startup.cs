using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WebApi.DbOperations;
using WebApi.Middlewares;
using WebApi.Services;

namespace WebApi
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
                c.AddSecurityDefinition("Bearer",new OpenApiSecurityScheme{
                    In = ParameterLocation.Header,
                    Description ="Please Insert Token",
                    Type =SecuritySchemeType.Http,
                    BearerFormat ="JWT",
                    Scheme="bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme{
                            Reference =new OpenApiReference{
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt=> 
            {
                opt.TokenValidationParameters =new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Token:Issuer"],
                    ValidAudience = Configuration["Token:Audience"],
                    IssuerSigningKey =new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddControllers()
            .AddNewtonsoftJson();
            services.AddDbContext<MovieStoreDbContext>(options=> options.UseInMemoryDatabase(databaseName :"MovieStoreDB"));
            services.AddScoped<IMovieStoreDbContext>(provider => provider.GetService<MovieStoreDbContext>());
            services.AddSingleton<ILoggerService, ConsoleLogger>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthorization();

            app.UseCustomExceptionMiddle();
            //app.Run()
            //app.Run(async context => Console.WriteLine("Middleware 1."));
            // app.Run(async context => Console.WriteLine("Middleware 2."));

            //app.User()
            // app.Use(async(context,next)=>{
            //     Console.WriteLine("Middleware 1 başladı.");
            //     await next.Invoke();
            //     Console.WriteLine("Middleware 1 sonlandırılıyor..");
            // });
            // app.Use(async(context,next)=>{
            //     Console.WriteLine("Middleware 2 başladı.");
            //     await next.Invoke();
            //     Console.WriteLine("Middleware 2 sonlandırılıyor..");
            // });
            // app.Use(async(context,next)=>{
            //     Console.WriteLine("Middleware 3 başladı.");
            //     await next.Invoke();
            //     Console.WriteLine("Middleware 3 sonlandırılıyor..");
            // });
            
            // app.UseBook();
            
            // app.Use(async(context,next)=>{
            //     Console.WriteLine("Use Middleware tetiklendi.");
            //     await next.Invoke();
                
            // });

            // app.Map("/example",internalApp=>
            // internalApp.Run(async context =>
            // {
            //     Console.WriteLine("/exmaple middleware tetiklendi.");
            //     await context.Response.WriteAsync("/exmaple middleware tetiklendi.");
            // }));

            // //app.MapWhen()
            // app.MapWhen(x=> x.Request.Method=="GET",internalApp=>{
            //     internalApp.Run(async context => {
            //         Console.WriteLine(" MapWhen Middleware tetiklendi.");
            //         await context.Response.WriteAsync("MapWhen Middleware tetiklendi.");
            //     });
            // });

         

            app.UseEndpoints(endpoints =>
            {
               endpoints.MapControllers();
            });
        }
    }
}