using Projeto02.AppWebForum.Services;

var builder = WebApplication.CreateBuilder(args);

/*
 * AddTransient: Uma instância é criada cada vez que o serviço é requisitado.
 *               Útil para serviços 'stateless'
 * 
 * AddScoped: Uma instância é criada por cada requisição cliente.
 *            Útil para instancias de banco de dados (Entity Framework)
 * 
 * AddSingleton: Uma única instância é criada durante toda a vida da aplicação.
 *               Útil para aplicações envolvendo logs e cache.
 * 
 */


builder.Services.AddTransient<IForumService, ForumService>();
builder.Services.AddTransient<IUsuarioService, UsuarioService>();
builder.Services.AddTransient<IComentarioService, ComentarioService>();

builder.Services.AddHttpClient();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
