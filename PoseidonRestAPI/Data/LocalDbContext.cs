using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Controllers.Domain;
using Dot.Net.WebApi.Controllers;

namespace PoseidonRestAPI.Data
{
    public class LocalDbContext : DbContext
    {
        public DbSet<User> Users { get; set;}
        public DbSet<BidList> BidList { get; set; }
        public DbSet<CurvePoint> CurvePoints { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<Trade> Trades { get; set; }
        public DbSet<User> Users { get; set; }
    }
}