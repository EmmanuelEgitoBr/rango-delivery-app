using AutoMapper;
using Food.Delivery.Store.Application.Mappings;
using Food.Delivery.Store.Application.Services;
using Food.Delivery.Store.Application.Services.Interfaces;
using Food.Delivery.Store.Domain.Contracts.Base;
using Food.Delivery.Store.Infra.Mongo.Configurations;
using Food.Delivery.Store.Infra.Mongo.Repositories.Base;
using MongoDB.Driver;

namespace Food.Delivery.Store.Api.Extensions;

public static class WebApiBuilderExtensions
{
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

    public static void AddMapperConfiguration(this WebApplicationBuilder builder)
    {
        IMapper mapper = MappingConfig.RegisterMap().CreateMapper();
        builder.Services.AddSingleton(mapper);
        builder.Services.AddAutoMapper(typeof(MappingConfig));
    }

    public static void AddServicesConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IClienteService, ClienteService>();
    }
}
