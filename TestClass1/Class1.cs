using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClass1
{
    public class Class1
    {
        public void PubMet()
        {
            Console.WriteLine("Hello");
        }
        protected void ProtMet()
        {
            Console.WriteLine("Hello");
        }
        private void PrivMet()
        {
            Console.WriteLine("Hello");
        }
    }
    public class Class2
    {
        public void PubMet1()
        {
            Console.WriteLine("Hello");
        }
        protected void ProtMet1()
        {
            Console.WriteLine("Hello");
        }
        private void PrivMet1()
        {
            Console.WriteLine("Hello");
        }
    }
}
