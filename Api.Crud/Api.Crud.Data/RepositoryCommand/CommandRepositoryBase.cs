namespace Api.Crud.Data.RepositoryCommand;

public class CommandRepositoryBase
{
    public string sp_InsertCart { get { return "sp_InsertCart"; } }
    public string sp_DeleteCartItemByProductId { get { return "sp_DeleteCartItemByProductId"; } }
    public string sp_SaveCart { get { return "sp_SaveCart"; } }
}
