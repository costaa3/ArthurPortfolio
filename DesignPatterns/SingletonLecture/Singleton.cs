using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.SingletonLecture
{
    public class Singleton
    {

        private static Singleton instance;

        public int Age { get; set; } = 23;
        public string Name { get; set; } = "Arthur";

        protected Singleton() { }

        public static Singleton Instance() {

            if (instance == null)
            {
                instance = new Singleton();
            }
            
            return instance;
        }
    }
}
