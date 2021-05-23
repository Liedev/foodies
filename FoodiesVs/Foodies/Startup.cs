using FluentValidation;
using FluentValidation.AspNetCore;
using Foodies.Areas.Identity.Data;
using Foodies.Data;
using Foodies.Data.UnitOfWork;
using Foodies.Helpers;
using Foodies.Models;
using Foodies.Validators;
using Foodies.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodies
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
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddFluentValidation();
            services.AddTransient<IValidator<Ingredient>, IngredientValidator>();
            services.AddTransient<IValidator<Ingredient>, EditIngredientValidator>();
            services.AddTransient<IValidator<Category>, CategoryValidator>();
            services.AddTransient<IValidator<Category>, EditCategoryValidator>();
            services.AddTransient<IValidator<LevelPreperation>, LevelPreperationValidator>();
            services.AddTransient<IValidator<PreperationTime>, PreperationTimeValidator>();
            services.AddTransient<IValidator<Unit>, UnitValidator>();
            services.AddTransient<IValidator<Meal>, MealValidator>();
            services.AddTransient<IValidator<Meal>, EditMealValidator>();
            services.AddTransient<IValidator<MealIngredient>, MealIngredientValidator>();
            services.AddDbContext<FoodiesContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("FoodiesConnection")));
            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<FoodiesContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.Configure<AppSettings>(Configuration.GetSection("Appsettings"));
            var appSettings = Configuration.GetSection("AppSettings").Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication()
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[0]}
                };
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
                });
            });
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });
            services.AddSwaggerGen();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.WithOrigins("http://localhost:3000", "http://localhost:3001", "http://localhost:3002")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            //CreateUserRoles(serviceProvider).Wait();//After Initialisation this is commented out
        }
        //Create Userrole must be deleted after initialisation, I've let it stand because it's a testCase with a local db
        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            FoodiesContext foodiesContext = serviceProvider.GetRequiredService<FoodiesContext>();

            IdentityResult roleResult;
            //Adding Admin Role
            bool roleCheck = await roleManager.RoleExistsAsync("Admin");
            if (!roleCheck)
            {
                // create roles and seed them to the datebase
                roleResult = await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            bool loggedInUserRoleCheck = await roleManager.RoleExistsAsync("LoggedInUser");
            if (!loggedInUserRoleCheck)
            {
                roleResult = await roleManager.CreateAsync(new IdentityRole("LoggedInUser"));
            }
            // Assign Admin Role to the main user
            ApplicationUser user = new ApplicationUser();

            user.UserName = "LazyJay@test.be";
            user.Email = "LazyJay@test.be";
            PasswordHasher<ApplicationUser> password = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = password.HashPassword(user, "Test1234!");
            user.EmailConfirmed = true;
            user.NormalizedEmail = user.Email.ToUpper();
            user.NormalizedUserName = user.UserName.ToUpper();
            user.EndUser = new EndUser
            {
                NickName = "LazyJay",
                Name = "Lazy",
                LastName = "Jay"
            };
            foodiesContext.Users.Add(user);
            if (user != null)
            {
                DbSet<IdentityUserRole<string>> roles = foodiesContext.UserRoles;
                IdentityRole adminRole = foodiesContext.Roles.FirstOrDefault(roles => roles.Name == "Admin");
                if (adminRole != null)
                {
                    if (!roles.Any(Uri => Uri.UserId == user.Id && Uri.RoleId == adminRole.Id))
                    {
                        roles.Add(new IdentityUserRole<string> { UserId = user.Id, RoleId = adminRole.Id });
                        foodiesContext.SaveChanges();
                    }
                }
            }
        }
    }
}
