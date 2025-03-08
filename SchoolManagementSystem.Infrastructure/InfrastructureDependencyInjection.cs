using AngularApi.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Infrastructure.GoogleServices;
using SchoolManagementSystem.Infrastructure.JwtServices;
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
            #region Email Messages
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<EmailTemplateService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            #endregion

            #region Reps Registeration
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IClassRoomRepository, ClassRoomRepository>();
            services.AddScoped<IParentRepository, ParentRepository>();
            services.AddScoped<ILibraryRepository, LibraryRepository>();
            services.AddScoped<IBorrowedBookRepository, BorrowedBookRepository>();
            services.AddScoped<IFeeRepository, FeeRepository>();
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IAssignmentRepository, AssignmentRepository>();
            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IExamResultRepository, ExamResultRepository>();
            services.AddScoped<IExamScoreRepository, ExamScoreRepository>();
            services.AddScoped<IExamTypeRepository, ExamTypeRepository>();
            services.AddScoped<IGradeRepository, GradeRepository>();

            services.AddScoped<IUserRolesClaimsRepository, UserRolesClaimsRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            #region JwtService
            services.AddScoped<IJwtService, JwtService>();
            #endregion

            #region GoogleService
            services.AddScoped<IGoogleService, GoogleService>();
            #endregion

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


            services.Configure<IdentityOptions>(op =>
            {
                op.Lockout.MaxFailedAccessAttempts = 5;
                op.Lockout.AllowedForNewUsers = true;
                op.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(40);
            });

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
                //options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
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
                    ValidateLifetime = true, //  Enforce expiration check
                    ClockSkew = TimeSpan.Zero,
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


            services.AddAuthorization(options =>
            {
                options.AddPolicy("PermissionPolicy", builder =>
                {
                    builder.RequireClaim("Permission", "CanEditUsers");
                });
                options.AddPolicy("EmailPolicy", builder =>
                {
                    builder.RequireClaim("EmailVerified", "falsse")
                    ;
                });
            });
        }

        public static async Task EnsureRolesCreatedAsync(this RoleManager<IdentityRole> roleManager)
        {
            var roles = new[] { "admin", "student", "teacher" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
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
