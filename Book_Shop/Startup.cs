using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_Shop.Data;
using Book_Shop.Data.interfaces;
using Book_Shop.Data.Mocks;
using Book_Shop.Data.models;
using Book_Shop.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

//TODO:   Çðîáèòè øëÿõ books/{genre}/{bookName} íà îñíîâ³ razor pages
//        Ñòâîðèòè razor-ñòîð³íêó æàíð³â genre/
//        Ïðè âèáîð³ æàíðó ïåðåíàïðàâëåííÿ íà books/{genre}

//kjhfdlvkshdflvkjzdfvlkzjfdhvlzkdfj

namespace Book_Shop
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

            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(connection));
            services.AddTransient<IAllBooks, BooksRepository>();
            services.AddTransient<IAllGenres, GenresRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();

            services.AddMemoryCache();
            services.AddSession();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));

            services.AddRazorPages();

  

            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.AddEfDiagrams<AppDBContext>();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStatusCodePages(); // Â³äîáðàæåííÿ ñòàòóñ ³ êîä ñòîð³íêè

            app.UseStaticFiles(); // Â³äîáðàæåííÿ ñòàòè÷íèõ ôàéë³â(êàðòèíêè ³ òä.)

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession(); // Äëÿ ñåñ³é îáîâ'ÿçêîâî

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContext content = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                AddToDB.Initial(content);
            }
        }
    }
}
