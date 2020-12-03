using Shortener.Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shortener.Service
{
    public interface IUrlService
    {
        Task<Guid> Shorten(RequestDTO requestDTO);

        Task<(bool isFound, string redirectUrl)> TryGetRedirectUrl(Guid code);
    }
}
