using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shortener.Domain
{
    [Table(nameof(ShortCode), Schema = DbSchema.Url)]
    public class ShortCode
    {
        public long Id { get; set; }
        public int UrlId { get; set; }
        public Url Url { get; set; }
        public Guid Code { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ReqDate { get; set; }
        public long RedirectCount { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
