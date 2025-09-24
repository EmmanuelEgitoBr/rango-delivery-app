namespace Food.Delivery.Store.Infra.Mongo.Configurations;

public class MongoDbSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
}
