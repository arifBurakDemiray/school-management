using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using AutoMapper;
using SchoolManagement.API.Data;
using SchoolManagement.API.Models;
using Newtonsoft.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using SchoolManagament.API.Security;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SchoolManagament.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddDbContext<SchoolManagement.API.RepoContext>(opt => opt
                                                    .UseMySql("server=DATABASE_ENDPOINT;port=PORT;user= ;password= ;database=NAME", 
                                                        new MySqlServerVersion(new Version(8, 0, 20)),
                                                        mySqlOptions => mySqlOptions
                                                            .CharSetBehavior(CharSetBehavior.NeverAppend).EnableRetryOnFailure())
                                                    .UseLoggerFactory(LoggerFactory.Create(b => b
                                                        .AddConsole()
                                                        .AddFilter(level => level >= LogLevel.Information)))
                                                    .EnableSensitiveDataLogging()
                                                    .EnableDetailedErrors());
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IRepo<User>, UserRepo>();
            services.AddScoped<IRepo<Role>, RoleRepo>();
            services.AddScoped<IRepo<Teacher>, TeacherRepo>();
            services.AddScoped<IRepo<Student>, StudentRepo>();
            services.AddScoped<IRepo<Lesson>, LessonRepo>();
            //services.AddScoped<IRepo<School>, SchoolRepo>();
            services.AddScoped<IUserService, UserService>();
            services.AddControllers();
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings").Get<AppSettings>().Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                        })
             .AddJwtBearer(x =>
             {
                 x.RequireHttpsMetadata = false;
                 x.SaveToken = true;
                 x.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(key),
                     ValidateIssuer = false,
                     ValidateAudience = false
                 };
             });
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "SchoolManagement API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseMiddleware<JwtMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("This is a School Management Api for my Internship\ncontact: burakdemiray09@gmail.com\ngithub : https://github.com/arifBurakDemiray \nlinkedin : https://linkedin.com/in/arifburakdemiray");
                });
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger/ui";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "School Management REST API");
            });
        }
    }
}
