using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kritner.Common
{
    public enum CompanyType
    {
        Partner,
        Member,
        BlahBlah
    }

    public interface ICompany
    {
        CompanyType MyCompanyType { get; }
    }
}
