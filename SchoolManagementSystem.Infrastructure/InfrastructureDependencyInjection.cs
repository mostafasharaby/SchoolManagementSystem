using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Infrastructure.Repositories;
using SchoolManagementSystem.Infrastructure.RepositoryImpelementation;
using System.Globalization;
using System.Text;

namespace SchoolManagementSystem.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {

        public static void AddInfrastructurefDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IParentRepository, ParentRepository>();
            services.AddScoped<IClassRoomRepository, ClassRoomRepository>();

            services.AddDbContext<SchoolContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("connection"));
            });



            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultProvider;
            })
            .AddEntityFrameworkStores<SchoolContext>()
            .AddDefaultTokenProviders();


            // Step 1: Add localization services
            #region  Localization
            services.AddLocalization(options => options.ResourcesPath = "");

            services.Configure<RequestLocalizationOptions>(options =>
             {
                 var supportedCultures = new[]
                 {
                    new CultureInfo("en-US"),
                    new CultureInfo("ar-EG"),
                    new CultureInfo("fr-FR"),
                 };

                 options.DefaultRequestCulture = new RequestCulture("ar-EG");
                 options.SupportedCultures = supportedCultures;
                 options.SupportedUICultures = supportedCultures;
             });
            #endregion
        }
        public static void AddAuthenticationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                //options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["Jwt:ValidIssuer"],
                    ValidateAudience = true,
                    ValidAudience = configuration["Jwt:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]))
                };
            })
            .AddCookie()
            .AddGoogle(options =>
            {
                options.ClientId = configuration["GoogleAuth:ClientId"];
                options.ClientSecret = configuration["GoogleAuth:ClientSecret"];
            });


            services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
        }


        //public static void AddSwaggerServices(this IServiceCollection services)
        //{
        //    services.AddSwaggerGen(c =>
        //    {
        //        c.SwaggerDoc("v1", new OpenApiInfo
        //        {
        //            Version = "v1",
        //            Title = "Medical Center",
        //            Description = "ASP.NET Core Web API"
        //        });

        //        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        //        {
        //            Name = "Authorization",
        //            Type = SecuritySchemeType.Http,
        //            Scheme = "Bearer",
        //            BearerFormat = "JWT",
        //            In = ParameterLocation.Header,
        //            Description = "JWT Authorization header using the Bearer scheme."
        //        });

        //        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        //        {
        //            {
        //                new OpenApiSecurityScheme
        //                {
        //                    Reference = new OpenApiReference
        //                    {
        //                        Type = ReferenceType.SecurityScheme,
        //                        Id = "Bearer"
        //                    }
        //                },
        //                Array.Empty<string>()
        //            }
        //        });
        //    });
        //}

    }
}
