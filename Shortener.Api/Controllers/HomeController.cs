using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Shortener.Models;
using Shortener.Service;
using Shortener.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Shortener.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public HomeController(IUrlService urlService)
        {
            UrlService = urlService;
        }
        public IUrlService UrlService { get; }

        [HttpGet("welcome")]
        public IActionResult Index()
        {
            return Content("Welcome, Now you can use UrlTools API");
        }

        [HttpPost("shorten")]
        public async Task<IActionResult> Shorten(JObject data)
        {
            var req = data["req"].ToObject<RequestDTO>();
            Guid code;
            if (req.IsValid())
            {
                code = await UrlService.Shorten(req);
            }
            else
            {
                return BadRequest();
            }
            return Ok(code);
        }

        [HttpGet("redirect")]
        public async Task<IActionResult> GetRedirect(Guid code)
        {
            var result = await UrlService.TryGetRedirectUrl(code);
            if (result.isFound)
                return Redirect(result.redirectUrl);
            return NotFound();
        }
    }
}
