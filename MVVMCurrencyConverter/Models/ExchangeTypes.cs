using System.Collections.Generic;

namespace MVVMCurrencyConverter.Models
{
    public class ExchangeTypes
    {
        public long Timestamp { get; set; }

        public Dictionary<string, decimal> Rates { get; set; }

        public string License { get; set; }
    }

    //public class Rates
    //{


    //    Values { get; set; }


    //}
}
