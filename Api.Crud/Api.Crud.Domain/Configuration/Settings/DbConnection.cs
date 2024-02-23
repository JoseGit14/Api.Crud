namespace Api.Crud.Domain.Configuration.Settings;

public class Root
{
    public DbConnection DbConnection { get; set; }
}
public class DbConnection
{
    public Customer Customer { get; set; }
    public ProductDb ProductDb { get; set; }
}

public class Customer
{
    public string DataSource { get; set; }
    public string InitialCatalog { get; set; }
    public string IntegratedSecurity { get; set; }

    public string ConnectionString
    {
        get
        {
            return $"Data Source={DataSource}; Initial Catalog={InitialCatalog}; Integrated Security={IntegratedSecurity}";
        }
    }
}

public class ProductDb
{
    public string DataSource { get; set; }
    public string InitialCatalog { get; set; }
    public string IntegratedSecurity { get; set; }

    public string ConnectionString
    {
        get
        {
            return $"Data Source={DataSource}; Initial Catalog={InitialCatalog}; Integrated Security={IntegratedSecurity}";
        }
    }
}
