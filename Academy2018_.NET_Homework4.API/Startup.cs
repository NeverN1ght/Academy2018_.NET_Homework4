using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Academy2018_.NET_Homework4.Core.Abstractions;
using Academy2018_.NET_Homework4.Core.Services;
using Academy2018_.NET_Homework4.Core.Validation;
using Academy2018_.NET_Homework4.Infrastructure.Abstractions;
using Academy2018_.NET_Homework4.Infrastructure.Data;
using Academy2018_.NET_Homework4.Infrastructure.Models;
using Academy2018_.NET_Homework4.Infrastructure.Repositories;
using Academy2018_.NET_Homework4.Shared.DTOs;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Academy2018_.NET_Homework4.API
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
            services.AddMvc();

            services.AddSingleton<DataSource>();

            services.AddScoped<IService<PilotDto>, PilotsService>();
            services.AddScoped<IService<FlightDto>, FlightsService>();
            services.AddScoped<IService<DepartureDto>, DeparturesService>();
            services.AddScoped<IService<StewardesseDto>, StewardessesService>();
            services.AddScoped<IService<TicketDto>, TicketsService>();
            services.AddScoped<IService<AirplaneDto>, AirplanesService>();
            services.AddScoped<IService<AirplaneTypeDto>, AirplaneTypesService>();
            services.AddScoped<IService<CrewDto>, CrewsService>();

            services.AddTransient<AbstractValidator<PilotDto>, PilotDtoValidator>();
            services.AddTransient<AbstractValidator<AirplaneDto>, AirplaneDtoValidator>();
            services.AddTransient<AbstractValidator<DepartureDto>, DepartureDtoValidator>();
            services.AddTransient<AbstractValidator<StewardesseDto>, StewardesseDtoValidator>();
            services.AddTransient<AbstractValidator<CrewDto>, CrewDtoValidator>();
            services.AddTransient<AbstractValidator<FlightDto>, FlightDtoValidator>();
            services.AddTransient<AbstractValidator<TicketDto>, TicketDtoValidator>();
            services.AddTransient<AbstractValidator<AirplaneTypeDto>, AirplaneTypeDtoValidator>();

            services.AddTransient<IRepository<Pilot>, PilotsRepository>();
            services.AddTransient<IRepository<Flight>, FlightsRepository>();
            services.AddTransient<IRepository<Departure>, DeparturesRepository>();
            services.AddTransient<IRepository<Stewardesse>, StewardessesRepository>();
            services.AddTransient<IRepository<Ticket>, TicketsRepository>();
            services.AddTransient<IRepository<Airplane>, AirplanesRepository>();
            services.AddTransient<IRepository<AirplaneType>, AirplaneTypesRepository>();
            services.AddTransient<IRepository<Crew>, CrewsRepository>();
            
            var mapper = MapperConfiguration().CreateMapper();
            services.AddTransient(_ => mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        public MapperConfiguration MapperConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Pilot, PilotDto>();
                cfg.CreateMap<PilotDto, Pilot>();

                cfg.CreateMap<Flight, FlightDto>();
                cfg.CreateMap<FlightDto, Flight>();

                cfg.CreateMap<Stewardesse, StewardesseDto>();
                cfg.CreateMap<StewardesseDto, Stewardesse>();

                cfg.CreateMap<Ticket, TicketDto>();
                cfg.CreateMap<TicketDto, Ticket>();

                cfg.CreateMap<Crew, CrewDto>();
                cfg.CreateMap<CrewDto, Crew>();

                cfg.CreateMap<Airplane, AirplaneDto>();
                cfg.CreateMap<AirplaneDto, Airplane>();

                cfg.CreateMap<AirplaneType, AirplaneTypeDto>();
                cfg.CreateMap<AirplaneTypeDto, AirplaneType>();

                cfg.CreateMap<Departure, DepartureDto>();
                cfg.CreateMap<DepartureDto, Departure>();
            });

            return config;
        }
    }
}
