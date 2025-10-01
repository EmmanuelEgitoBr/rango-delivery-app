using AutoMapper;
using Food.Delivery.Store.Application.Mappings;
using Food.Delivery.Store.Application.Services;
using Food.Delivery.Store.Application.Services.Interfaces;
using Food.Delivery.Store.Domain.Contracts.Base;
using Food.Delivery.Store.Infra.Mongo.Configurations;
using Food.Delivery.Store.Infra.Mongo.Repositories.Base;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using System.Reflection;

namespace Food.Delivery.Store.Api.Extensions;

/// <summary>
/// Classe de extensão para configurar serviços e middlewares da aplicação
/// </summary>
public static class WebApiBuilderExtensions
{
    /// <summary>
    /// Configura o MongoDB para a aplicação
    /// </summary>
    /// <param name="builder"></param>
    public static void AddMongoConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<MongoDbSettings>(
            builder.Configuration.GetSection("MongoDbSettings"));

        builder.Services.AddSingleton<IMongoClient>(sp =>
        {
            var settings = builder.Configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
            return new MongoClient(settings!.ConnectionString);
        });

        builder.Services.AddScoped(sp =>
        {
            var settings = builder.Configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
            var client = sp.GetRequiredService<IMongoClient>();
            return client.GetDatabase(settings!.DatabaseName);
        });

        builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
    }

    /// <summary>
    /// Configura o AutoMapper para a aplicação
    /// </summary>
    /// <param name="builder"></param>
    public static void AddMapperConfiguration(this WebApplicationBuilder builder)
    {
        IMapper mapper = MappingConfig.RegisterMap().CreateMapper();
        builder.Services.AddSingleton(mapper);
        builder.Services.AddAutoMapper(typeof(MappingConfig));
    }

    /// <summary>
    /// Configura os serviços da aplicação
    /// </summary>
    /// <param name="builder"></param>
    public static void AddServicesConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IClienteService, ClienteService>();
    }

    /// <summary>
    /// Configura o Swagger para a API
    /// </summary>
    /// <param name="builder"></param>
    public static void AddSwaggerConfiguration(this WebApplicationBuilder builder)
    {
        // --- API Versioning ---
        builder.Services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0); // v1.0 por padrão
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true; // retorna headers com versões suportadas
        });

        // --- API Explorer (necessário para Swagger) ---
        builder.Services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV"; // exibe "v1", "v2"
            options.SubstituteApiVersionInUrl = true;
        });

        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new()
            {
                Title = "API de Delivery de Comida",
                Version = "v1",
                Description = "Api destinada para o gerenciamento do serviço de delivery de restaurantes",
                Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                {
                    Name = "Emmanuel Egito",
                    Url = new Uri("https://github.com/EmmanuelEgitoBr/rango-delivery-app")
                }
            });

            // Adiciona o arquivo XML gerado para incluir os comentários
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);

            options.SupportNonNullableReferenceTypes();
            options.MapType<IFormFile>(() => new Microsoft.OpenApi.Models.OpenApiSchema
            {
                Type = "string",
                Format = "binary"
            });
        });
    }
}
