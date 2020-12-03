using Shortener.BL;
using Shortener.Domain;
using Shortener.Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shortener.Service
{
    public class UrlService:IUrlService
    {
        public UrlService(IUrlRepository urlRepository)
        {
            UrlRepository = urlRepository;
        }

        public IUrlRepository UrlRepository { get; }

        public async Task<Guid> Shorten(RequestDTO requestDTO)
        {
            var url = new Url();
            url.ReqUrl = requestDTO.ReqUrl;
            return await UrlRepository.Shorten(url);
        }

        public async Task<(bool isFound, string redirectUrl)> TryGetRedirectUrl(Guid code)
        {
            return await UrlRepository.TryGetRedirectUrl(code);
        }
       
    }
}
