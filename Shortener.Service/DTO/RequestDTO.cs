using System;
using System.Linq;
using System.Threading.Tasks;

namespace Shortener.Service.DTO
{
    public class RequestDTO
    {
        public string ReqUrl { get; set; }
        public bool IsValid()
        {
            Uri uriResult;
            bool result = Uri.TryCreate(ReqUrl, UriKind.Absolute, out uriResult)
                    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            return result;
        }
    }
}
