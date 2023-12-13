using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
