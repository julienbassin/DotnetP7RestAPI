using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoseidonRestAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Configuration
{
    public class SeedData : IEntityTypeConfiguration<BidList>
    {
        public void Configure(EntityTypeBuilder<BidList> builder)
        {
            builder.ToTable("BidList");
            builder.Property(b => b.BidListId)
                .IsRequired(true);
            builder.HasData(
                new BidList 
                {
                    Account = "Julien",
                    BidQuantity = 10.0
                },

                new BidList
                {
                    Account = "test",
                    BidQuantity = 20.0
                }

                );
        }
    }
}
