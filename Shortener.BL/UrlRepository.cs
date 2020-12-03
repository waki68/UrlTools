using Shortener.Domain;
using Shortener.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shortener.BL
{
    public class UrlRepository: IUrlRepository
    {
        public UrlRepository(AppDbContext context)
        {
            Context = context;
        }

        public AppDbContext Context { get; }

        public async Task<Guid> Shorten(Url url)
        {
            var shortCode = new ShortCode();
            shortCode.ReqDate = DateTime.Now;
            shortCode.Code = await GenerateCode();

            if (Context.Url.Any(e => e.ReqUrl == url.ReqUrl))
            {
                url = Context.Url.Where(e => e.ReqUrl == url.ReqUrl).First();
                shortCode.UrlId = url.Id;
                await Context.ShortCode.AddAsync(shortCode);
            }
            else
            {
                url.ShortCodes.Add(shortCode);
                await Context.Url.AddAsync(url);
            }

            await Context.SaveChangesAsync();


            return shortCode.Code;
        }

        private async Task<Guid> GenerateCode()
        {
            return await Task.Run(() =>
            {
                return Guid.NewGuid();
            });
        }

        public async Task<(bool isFound, string redirectUrl)> TryGetRedirectUrl(Guid code)
        {

            if (Context.ShortCode.Any(e => e.Code == code))
            {
                var shortCode = Context.ShortCode.Where(e => e.Code == code).First();
                var url = await Context.Url.FindAsync(shortCode.UrlId);
                shortCode.RedirectCount++;
                try
                {
                    Context.ShortCode.Update(shortCode);
                    await Context.SaveChangesAsync();
                    return (true, url.ReqUrl);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return (false, "");
        }
    }
}
