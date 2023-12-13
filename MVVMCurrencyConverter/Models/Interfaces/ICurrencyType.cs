namespace MVVMCurrencyConverter.ViewModel
{
    public interface ICurrencyType
    {
        int Id { get; set; }
        string Name { get; set; }
        decimal Value { get; set; }
    }
}