namespace Api.Crud.Domain.ViewModel;

public class TotalAmountViewModel<T>
{
    public IEnumerable<T> Results { get; set; }
    public double TotalAmount { get; set; }
}
