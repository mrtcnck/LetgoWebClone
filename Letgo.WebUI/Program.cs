using Algolia.Search.Clients;
using Algolia.Search.Iterators;
using Algolia.Search.Models.Common;
using Algolia.Search.Models.Search;
using Letgo.BusinessLayer.API.Abstract;
using Letgo.BusinessLayer.API.Concrete;
using Letgo.DataAccess.Contexts;
using Letgo.Entities.Concrete;
using Letgo.WebUI.AutoMapper;
using Letgo.WebUI.Data;
using Letgo.WebUI.Extentions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Letgo.WebUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = true;
            });

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<SqlDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<SqlDbContext>();
            builder.Services.AddControllersWithViews();

            //Repository ve Manager sýnýflarýnýn servislere eklenmesi
            builder.Services.AddLetgoServices();

            builder.Services.AddAutoMapper(typeof(LetgoAutoMapper));

            //Algolia Search
            builder.Services.AddSingleton<ISearchClient>(new SearchClient(builder.Configuration["Algolia:ApplicationId"], builder.Configuration["Algolia:ApiKey"]));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            #region Rol oluþturma
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var roles = new[] { "Admin", "Manager", "Member" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }
            } 
            #endregion

            #region Rol vererek üye oluþturma
            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                string email = "admin@admin.com";
                string password = "Test1234.";

                if (await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new User();
                    user.UserName = email;
                    user.Email = email;

                    await userManager.CreateAsync(user, password);

                    await userManager.AddToRoleAsync(user, "Admin");
                }
            } 
            #endregion

            using (var scope = app.Services.CreateScope())
            {
                SearchClient client = new SearchClient(builder.Configuration["Algolia:ApplicationId"], builder.Configuration["Algolia:ApiKey"]);

                SearchIndex index = client.InitIndex("adverts");

                #region Tüm kayýtlarý getir

                //IndexIterator<Advert> indexIterator = index.Browse<Advert>(new BrowseIndexQuery { });
                //foreach (var record in indexIterator)
                //{
                //    Console.WriteLine(record);
                //} 
                #endregion

                #region Kayýt ekleme
                //var advert = new Advert
                //{
                //    ObjectID = "bbe462a4-0d59-4f05-8bb6-0f13bff274a0",
                //    Name = "mertcan2",
                //    Description = "mertcan",
                //    Price = 0,
                //    Slug = "mertcan"
                //};
                //var staus = await index.SaveObjectAsync(advert); 
                #endregion

                #region Index içerisinde ID ile cagirma
                //ID ile çaðýrma - index içerisinde
                //Advert advert = index.GetObject<Advert>("bbe462a4-0d59-4f05-8bb6-0f13bff274a0"); 
                #endregion

                #region Search one typed Contact
                //var result = index.Search<Advert>(new Query("adverts")); 
                #endregion
            }

            app.Run();
        }
    }
}