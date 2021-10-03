namespace Students
{
    using System;
    using System.IO;
   
    using Microsoft.OpenApi.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Services;
    using Students.Data.WebAPIInMemoryDB.Models;

    public class Startup
    {
        #region Fields

        public IConfiguration Configuration { get; }

        #endregion Fields

        #region Constructor

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion Constructor

        #region Methods

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<StudentDBContext>(opt =>
                 opt.UseInMemoryDatabase("Students"));

            services.AddScoped<IStudentService, StudentService>();

            services.AddSwaggerGen(c =>
             {
                 var basePath = AppContext.BaseDirectory;
                 var apiXmlPath = Path.Combine(basePath, "Students.xml");
                 c.IncludeXmlComments(apiXmlPath);
                 c.SwaggerDoc("v1", new OpenApiInfo { Title = "Students", Version = "v1" });

                //c.SchemaFilter<EnumSchemaFilter>(); //TODO: to fix gender enums
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Students v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        #endregion Methods
    }
}
