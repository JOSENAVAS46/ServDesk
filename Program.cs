using Microsoft.EntityFrameworkCore;
using ServDesk.Bussines.General.DocumentoInterno;
using ServDesk.Bussines.Login.Usuario;
using ServDesk.DataAccess;
using ServDesk.Seguridad;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Configurar CORS
// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PolicyServDesk",
        policy =>
        {
            policy.WithOrigins("https://localhost:7040", "*").WithMethods("POST", "PUT", "DELETE", "GET");
        });
});

var sqlConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var configuration = new Configuracion(sqlConnectionString);
builder.Services.AddSingleton(configuration);

builder.Services.AddTransient<SqlHelper>();
builder.Services.AddSingleton<IErrorSistema, ErrorSistema>();

builder.Services.AddTransient<IDocumentoInterno, DocumentoInterno>();
builder.Services.AddTransient<OperadorDocumentoInterno>();

builder.Services.AddTransient<IUsuario, Usuario>();
builder.Services.AddTransient<OperadorUsuario>();



var app = builder.Build();


app.UseExceptionHandler(appError =>
{
    appError.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = System.Net.Mime.MediaTypeNames.Text.Plain;
        var contextFeature = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
        if (contextFeature != null) await context.Response.WriteAsync(contextFeature.Error.Message);

    });
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
