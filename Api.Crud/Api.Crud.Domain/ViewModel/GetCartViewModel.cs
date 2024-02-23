namespace Api.Crud.Domain.ViewModel;

public class GetCartViewModel
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public double Cost { get; set; }
    public int Quantity { get; set; }
    public double Amount { get; set; }
}
