using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Adapter.Data_processor
{
    internal class DataProcessor: IDataProcessor
    {
        public bool DataProcess()
        {
            Console.WriteLine("Process data");
            return true;    
        }

        public void sendNetworkRequest(string ip,string apiKey)
        {
            Console.WriteLine( $"Send Network request request with Ip address: {ip}, that requires apiKey:{apiKey}" );
        }
    }
}
