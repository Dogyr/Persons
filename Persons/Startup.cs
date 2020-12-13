using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persons.Common.Dtos;
using Persons.Common.Filters;
using Persons.Common.Interfaces;
using Persons.Common.Validators;
using Persons.DataLayer;
using Persons.DataLayer.Entities;
using Persons.DataLayer.Repositories;

namespace Persons
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<Context>(options => options.UseNpgsql(connection));

            services.AddScoped<ICrudRepository<PersonDto>, BaseRepository<Person, PersonDto>>();
            services.AddScoped<ICrudRepository<CompanyDto>, BaseRepository<Company, CompanyDto>>();
            services.AddScoped<ICrudRepository<PassportDto>, BaseRepository<Passport, PassportDto>>();
            services.AddScoped<IPersonRepository, PersonRepository>();

            services.AddControllers();
            services.AddSwaggerGen();

            var mappingConfig = new MapperConfiguration(UseMapperConfiguration);
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services
               .AddMvc(options =>
               {
                   options.Filters.Add(new ValidationFilter());
               })
               .AddFluentValidation(options =>
               {
                   options.ImplicitlyValidateChildProperties = true;
                   options.RegisterValidatorsFromAssemblyContaining<PersonValidator>();
               });
        }

        protected void UseMapperConfiguration(IMapperConfigurationExpression mapperConfiguration)
        {
            mapperConfiguration.AddProfile(new MappingProfile());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Persons"));
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
