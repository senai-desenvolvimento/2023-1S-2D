using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Adiciona o serviço de controllers
builder.Services.AddControllers();

//Adiciona serviço de autenticação JWT Bearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

//Define os parâmetros de validação do token
.AddJwtBearer(options => { });//paramos aqui....continuar na segunda

//Adiciona o gerador do Swagger 
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Filmes Tarde",
        Description = "API para gerenciamento de fimes - Introdução a sprint 2 - Backend API",
        Contact = new OpenApiContact
        {
            Name = "Senai Informática - Turma Tarde",
            Url = new Uri("https://github.com/senai-desenvolvimento")
        }
    });

    //Configure o Swagger para usar o arquivo XML gerado
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

//Habilita o middleware para atender ao documento JSON gerado e à interface do usuário do Swagger
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


//Mapear os controllers
app.MapControllers();

app.Run();
