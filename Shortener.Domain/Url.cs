using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shortener.Domain
{
    [Table(nameof(Url), Schema = DbSchema.Url)]
    public class Url
    {
        public Url()
        {
            this.ShortCodes = new List<ShortCode>();
        }
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string ReqUrl { get; set; }
        public List<ShortCode> ShortCodes { get; set; }

        public long TotalRedirectCount { get; set; }
    }
}
