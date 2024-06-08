namespace InventoryManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

			builder.Services.AddDistributedMemoryCache();

			builder.Services.AddSession(option =>
			{
				option.IdleTimeout = TimeSpan.FromMinutes(30);
				option.Cookie.HttpOnly = true;
				option.Cookie.IsEssential = true;
			});

			var app = builder.Build();

			
			
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseSession();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=LoginPage}/{id?}");

            app.Run();
        }
    }
}
