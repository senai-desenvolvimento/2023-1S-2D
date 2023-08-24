var builder = WebApplication.CreateBuilder(args);

//Adiciona o serviço de Controllers
builder.Services.AddControllers();

//Adicione o gerador do Swagger à coleção de serviços
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Começa a configuração do Swagger
//https://learn.microsoft.com/pt-br/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-7.0&tabs=visual-studio

//Habilite o middleware para atender ao documento JSON gerado e à interface do usuário do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Para atender à interface do usuário do Swagger na raiz do aplicativo
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

//Finaliza a configuração do Swagger

//Adiciona mapeamento dos Controllers
app.MapControllers();

app.UseHttpsRedirection();

app.Run();
