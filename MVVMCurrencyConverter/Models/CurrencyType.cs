using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace MVVMCurrencyConverter.ViewModel
{
    public class CurrencyType : ICurrencyType
    {
        #region properties
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        #endregion

        #region methods

        protected CurrencyType(int id, string name, decimal value)
        {
            Id = id;
            Name = name;
            Value = value;
        }

        public static CurrencyType CurrencyFactory(int id, string name, decimal value)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }
            return new CurrencyType(id, name, value);
        }

        public static ICurrencyType GetDefaultItem()
        {
            return CurrencyFactory(0, "==Select==", 1m);
        }
        #endregion

    }
}