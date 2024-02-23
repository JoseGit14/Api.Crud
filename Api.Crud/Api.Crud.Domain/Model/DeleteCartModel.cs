namespace Api.Crud.Domain.Model;

public class DeleteCartModel
{
    public int CartId { get; set; }
    public int ProductId { get; set; }

    public DeleteCartModel()
    {
        CartId = 0;
        ProductId = 0;
    }
}
