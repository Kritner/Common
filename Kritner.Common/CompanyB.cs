using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kritner.Common
{
    public class CompanyB : ICompany
    {
        public CompanyType MyCompanyType
        {
            get
            {
                return CompanyType.Partner;
            }
        }
    }
}
