using System;

namespace Kritner.Common
{
    public class NullURLPartnerInformation : IWebURL
    {
        public string GetURL()
        {
            return string.Empty;
        }
    }
}