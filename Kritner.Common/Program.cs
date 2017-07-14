using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kritner.Common
{
    public class Program
    {
        static void Main(string[] args)
        {
            CompanyA a = new CompanyA();
            CompanyB b = new CompanyB();

            ICompanyAdditionalInformationFactory factory = new CompanyAdditionalInformationFactory();
            Console.WriteLine(factory.GetAdditionalInformation(a));
            Console.WriteLine(factory.GetAdditionalInformation(b));
        }
    }
}
