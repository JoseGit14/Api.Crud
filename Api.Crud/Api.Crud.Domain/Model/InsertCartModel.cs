namespace Api.Crud.Domain.Model;

public class InsertCartModel
{
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public string CreatedBy { get; set; }

    public InsertCartModel()
    {
        CartId = 0;
        ProductId = 0;
        Quantity = 0;
        CreatedBy = string.Empty;
    }
}
