using MVVMCurrencyConverter.ViewModel;

namespace MVVMCurrencyConverter.Models
{
    public interface IDataHandler : IDataHolderService
    {


        ICurrencyType CurrencyTypeSelected { get; }

        void UpdateData();
        void AppendToDatabase(string currencyName, decimal CurrencyValue);
        void UpdataDbItem(string currencyName, decimal CurrencyValue);
        void DeleteData(ICurrencyType currencyType);
        void SetCurrencyBeingEditted(ICurrencyType currencyType);

        void SubscribeToLinkSelection(UpdateLinkSelectionOnSubscribed UpdateLinkSelectionDelegate);
        void SubscribeToCurrenciesChangeSelection(UpdateDataOnSubscribed UpdateDataOnSubscribedDelegate);

    }
}