using Microsoft.EntityFrameworkCore;
using IdentityServer4.Context;

namespace IdentiyServer4
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
            var server = Configuration["DBServer"];
            var port = Configuration["DBPort"] ?? "1433";
            var user = Configuration["DBUser"] ?? "SA";
            var pass = Configuration["DBPassword"] ?? "Qwerty_12345";
            var database = Configuration["DBName"] ?? "PizzaShop";

            string connectionString = string.Empty;

            if (server != null)
            {
                connectionString = $"Server={server},{port};Initial Catalog={database};User ID={user};Password={pass}";
            }
            else
            {
                connectionString = Configuration.GetConnectionString("DefaultConnection");
            }

            services.AddControllers();
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(Configurations.Apis)
                .AddInMemoryClients(Configurations.Clients)
                .AddResourceOwnerValidator<UserPasswordValidator>()
                .AddInMemoryIdentityResources(Configurations.IdentityResources());
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseIdentityServer();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
