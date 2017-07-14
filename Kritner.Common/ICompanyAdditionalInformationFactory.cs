using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kritner.Common
{
    public interface ICompanyAdditionalInformationFactory
    {
        IWebURL GetAdditionalInformation(ICompany company);
    }

    public class CompanyAdditionalInformationFactory : ICompanyAdditionalInformationFactory
    {
        public IWebURL GetAdditionalInformation(ICompany company)
        {
            if (company.MyCompanyType == CompanyType.Member)
            {
                return new WebURLMemberInformation();
            }
            if (company.MyCompanyType == CompanyType.Partner)
            {
                return new WebURLPartnerInformation();
            }

            return new NullURLPartnerInformation();
        }
    }
}
