namespace Api.Crud.Domain.Model;

public class SaveCartModel
{
    public int CartId { get; set; }
    public double TotalAmount { get; set; }
    public double Cash { get; set; }
    public double ChangeCash { get; set; }
    public string CreatedBy { get; set; }

    public SaveCartModel()
    {
        CartId = 0;
        TotalAmount = 0;
        Cash = 0;
        ChangeCash = 0;
        CreatedBy = string.Empty;
    }
}
