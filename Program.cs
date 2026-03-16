using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMusic.Data;
using SocialMusic.Services;

namespace SocialMusic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            //=========ENtity framework=========
            builder.Services.AddDbContext<AppDbContext>(options => 
                options.UseNpgsql(builder.Configuration.GetConnectionString("conexion")));



            //Servicios de TOken
            builder.Services.AddScoped<TokenService>();


            //################## CORS para fetch en front######################
            //builder.Services.AddCors(options => 
            //{
            //    options.AddPolicy("PermitirReact",
            //        policy =>
            //        {
            //            policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod();
            //        });


            //});


            var app = builder.Build();




            //==========Producción=================
            // app.UseCors("PermitirReact");

            //=========Usada Para desarrollo
            //if (builder.Environment.IsDevelopment())
            //{
                app.UseCors(policy =>
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod());
            //}




            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
