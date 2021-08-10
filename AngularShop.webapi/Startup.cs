using DataLayer.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using ServicesLayer.Security;
using ServicesLayer.Servicse.Implamtinan;
using ServicesLayer.Servicse.Interface;
using ServicesLayer.Uitelites.Converts;
using ServicesLayer.Uitelites.Extinsion.Connection;
using System.IO;
using System.Text;

namespace AngularShop.webapi
{
  public class Startup
  {
    public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
    {
      Configuration = configuration;
      WebHostEnvironment = webHostEnvironment;
    }

    public IConfiguration Configuration { get; }
    public IWebHostEnvironment WebHostEnvironment { get; }

    public void ConfigureServices(IServiceCollection services)
    {

      services.AddSingleton<IConfiguration>(
                 new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile($"appsettings.json")
                     .Build()
             );
      #region AddDBContext
      services.AddApplicationDbContext(Configuration);
      services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
      #endregion
      #region Services
      services.AddScoped<IUserService, UserService>();
      services.AddScoped<SliderService, SliderService>();
      services.AddScoped<IPasswordHelper, PasswordHelper>();
      services.AddScoped<IMailSender, SendEmail>();
      //services.AddScoped<IViewRenderService, RenderViewToString>();
      services.AddScoped<IProductService, ProductService>();
      #endregion
      services.AddControllers();

      #region Authentication

      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(option =>
        {
          option.TokenValidationParameters = new TokenValidationParameters
          {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://localhost:44373",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AngularshopJwtBearer"))
          };
        });

      #endregion

      #region Cors

      services.AddCors(option =>
      {

        option.AddPolicy("EnableCors", builde =>
        {
          builde.AllowAnyMethod()
            .AllowAnyHeader()
            .AllowAnyOrigin()
            .Build();
        });
      });

      #endregion

    }


    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();

      }

      app.UseStaticFiles();
      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();
      app.UseCors("EnableCors");

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
