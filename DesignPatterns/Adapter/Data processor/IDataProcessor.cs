using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Adapter.Data_processor
{
    internal interface IDataProcessor
    {

         bool DataProcess();


        void sendNetworkRequest(string ip, string apiKey);
      
    }
}
