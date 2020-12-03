using Shortener.Domain;
using System;
using System.Threading.Tasks;

namespace Shortener.BL
{
    public interface IUrlRepository
    {
        Task<Guid> Shorten(Url url);

        Task<(bool isFound, string redirectUrl)> TryGetRedirectUrl(Guid code);
    }
}
