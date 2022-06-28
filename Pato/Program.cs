using Pato.Repositories;

namespace Pato
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddTransient<IProdutoRepository, ProdutoSqlRepository>();
            builder.Services.AddTransient<IPessoaRepository, PessoaSqlRepository>();
            builder.Services.AddTransient<IClienteRepository, ClienteSqlRepository>();
            builder.Services.AddTransient<IUsuarioRepository, UsuarioSqlRepository>();
            builder.Services.AddTransient<ILoginRepository, LoginSqlRepository>();
            builder.Services.AddTransient<IFornecedorRepository, FornecedorSqlRepository>();
            builder.Services.AddTransient<IVendaRepository, VendaSqlRepository>();
            builder.Services.AddTransient<IProdutoVendaRepository, ProdutoVendaSqlRepository>();
            builder.Services.AddTransient<IOrcamentoRepository, OrcamentoSqlRepository>();
            builder.Services.AddTransient<IProdutoOrcamentoRepository, ProdutoOrcamentoSqlRepository>();
            var app = builder.Build();

            app.UseSession();  
            app.MapDefaultControllerRoute();
            app.Run();
        }
    }
}
