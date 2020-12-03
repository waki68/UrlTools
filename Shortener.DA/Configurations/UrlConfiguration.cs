using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shortener.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shortener.DA.Configurations
{
    internal interface IUrlConfig
        : IEntityTypeConfiguration<Url>
        , IEntityTypeConfiguration<ShortCode>
    {

    }

    public class UrlConfig : IUrlConfig
    {
        public void Configure(EntityTypeBuilder<Url> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).UseIdentityColumn(seed: 1, increment: 1);
            builder.HasMany(e => e.ShortCodes).WithOne(e => e.Url).HasForeignKey(e => e.UrlId).HasPrincipalKey(e => e.Id);
            builder.Property(e => e.TotalRedirectCount).HasComputedColumnSql("[Url].[udf_CalculateTotalRedirectCount]([Id])");
        }

        public void Configure(EntityTypeBuilder<ShortCode> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).UseIdentityColumn(seed: 1, increment: 1);
            builder.HasIndex(e => e.Code).IsUnique();
            builder.Property(e => e.RowVersion).IsRowVersion();
        }
    }
}
