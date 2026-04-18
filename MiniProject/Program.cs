
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MiniProject.AppDbContext;
using MiniProject.DTOs;
using MiniProject.Mapper;
using MiniProject.Repositories;
using MiniProject.Services;


//using MiniProject.Mapper;
using MiniProject.UserRepository;
using System.Text;

namespace MiniProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

             //Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddScoped<UserRepoInterface, UserRepo>();
            builder.Services.AddScoped<IProductRepo, ProductRepo>();
            builder.Services.AddScoped<ICartInterface,CartRepo>();

            builder.Services.AddScoped<IUserService, UserServices>();
            builder.Services.AddScoped<IProductServiceInterface, ProductServices>();
            builder.Services.AddScoped<ICartServices, CartServices>();


            builder.Services.AddDbContext<ProjectDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));
            builder.Services.AddAutoMapper(typeof(UserMapper));
            builder.Services.AddAutoMapper(typeof(ProductMapper));


            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<UserRegisterDto>();
            builder.Services.AddValidatorsFromAssemblyContaining<AddProductDto>();

            builder.Services.AddAuthentication("Bearer").AddJwtBearer(option =>
            option.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))

            }


            );


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(o => o.SwaggerEndpoint("/openapi/v1.json", "Medo"));

            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
