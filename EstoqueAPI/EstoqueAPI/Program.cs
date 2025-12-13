
using EstoqueAPI.Data;
using EstoqueAPI.Interfaces;
using EstoqueAPI.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace EstoqueAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddEntityFrameworkSqlServer().
                AddDbContext<EstoqueDBContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                );

            builder.Services.AddScoped<IProduto, ProdutoRepositorio>();
            builder.Services.AddScoped<IFornecedor, FornecedorRepositorio>();
            builder.Services.AddScoped<IMovimentacao, MovimentacaoRepositorio>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
        
        
    }
}
