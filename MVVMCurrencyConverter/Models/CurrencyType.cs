using System.Collections.Generic;
using System.Linq;

namespace MVVMCurrencyConverter.ViewModel
{
    public class CurrencyType
    {
        public string Name { get; set; }
        public decimal Value { get; set; }

        protected CurrencyType(string name, decimal value)
        {
            Name = name;
            Value = value;
        }

        public static IEnumerable<CurrencyType> GetTestData()
        {
            List<CurrencyType> result = new List<CurrencyType>
            {
                CurrencyFactory("==Select==", 1m)
            };
            result.AddRange(Enumerable.Range(1, 200).Select(item => CurrencyFactory("value" + item, item)).ToList());
            return result;
        } 

        public static CurrencyType CurrencyFactory(string name,decimal value)
        {
            if (string.IsNullOrEmpty(name) || value.Equals(0))
            {
                return null;
            }
            return new CurrencyType(name,value);    
        }
    }
}