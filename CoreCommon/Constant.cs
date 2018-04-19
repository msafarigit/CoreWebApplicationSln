using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCommon
{
    public class MessagePattern
    {
        public const string Required = "مقدار {0} الزامی می باشد";
        public const string ValidLength = "تعداد کاراکتر {0} می بایست بین {1} و {2} باشد";
        public const string InvalidLength = "تعداد کاراکتر {0} معتبر نمی باشد";
        public const string IsInvalid = "مقدار {0} معتبر نمی باشد";
    }
}
