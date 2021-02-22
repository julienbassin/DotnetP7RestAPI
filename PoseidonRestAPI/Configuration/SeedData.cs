using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using PoseidonRestAPI.Data;
using PoseidonRestAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Configuration
{
    public static class SeedData
    {
       public static void Initialize(IServiceProvider serviceProvider)
        {
            var services = serviceProvider;

            try
            {
                var dbOptions = serviceProvider.GetRequiredService<DbContextOptions<LocalDbContext>>();
                using (var context = new LocalDbContext(dbOptions))
                {
                    context.Database.EnsureCreated();

                    var dummyUser = context.Users.Where(x => x.UserName == "DummyUser").FirstOrDefault();
                    if (dummyUser == null)
                    {
                        var dummy = new User
                        {
                            UserName = "DummyUser",
                            FullName = "Dummy User",
                            Password = JsonWebToken.GenerateHash("test1234!", "128"),
                            Role = "dummyuser tester"
                        };

                        context.Users.Add(dummy);
                    }

                    var dummyTester = context.Users.Where(x => x.UserName == "DummyTester").FirstOrDefault();

                    if (dummyTester == null)
                    {
                        var dummytester = new User
                        {
                            UserName = "DummyTester",
                            FullName = "Dummy tester",
                            Password = JsonWebToken.GenerateHash("test1234!", "128"),
                            Role = "tester"
                        };

                        context.Users.Add(dummytester);
                    }

                    var dummyAdmin = context.Users.Where(x => x.UserName == "dummyAdmin").FirstOrDefault();

                    if (dummyAdmin == null)
                    {
                        var adminUser = new User
                        {
                            UserName = "DummyAdmin",
                            FullName = "Dummy Admin",
                            Password = JsonWebToken.GenerateHash("test1234", "128"),
                            Role = "Admin"
                        };

                        context.Users.Add(adminUser);
                    }

                    if (!context.BidList.Any())
                    {
                        context.BidList.AddRange(
                            new BidList
                            {
                                BidListId = 1,
                                Account = dummyTester.UserName,
                                AskQuantity = 10
                            },
                            new BidList
                            {
                                BidListId = 2,
                                Account = dummyUser.UserName,
                                AskQuantity = 20
                            },
                            new BidList
                            {
                                BidListId = 3,
                                Account = dummyAdmin.UserName,
                                AskQuantity = 30
                            }
                        );
                    }


                    if (!context.CurvePoints.Any())
                    {
                        context.CurvePoints.AddRange(
                            new CurvePoint
                            {
                                CurveId = 1,
                                Term = 1,
                                Value = 10
                            },
                            new CurvePoint
                            {
                                CurveId = 2,
                                Term = 2,
                                Value = 20
                            },
                            new CurvePoint
                            {
                                CurveId = 3,
                                Term = 3,
                                Value = 30
                            }
                        );

                        if (! context.Ratings.Any())
                        {
                            context.Ratings.AddRange(
                                new Rating
                                {
                                     MoodysRating = "azez",
                                     FitchRating = "chjhdd",
                                     SandPRating = "shdh"
                                },

                                new Rating
                                {
                                    MoodysRating = "gkeeoe",
                                    FitchRating = "azzdd",
                                    SandPRating = "retr"
                                },
                                new Rating
                                {
                                    MoodysRating = "jemlkop",
                                    FitchRating = "zaeer",
                                    SandPRating = "shfgfddh"
                                }
                            );
                        }

                        if (! context.Rules.Any())
                        {
                            context.Rules.AddRange(
                                
                                new Rule
                                {
                                    Name = "this a test rule",
                                    Description = "djjsdpo",
                                    Template = "hdshljsq",
                                },
                                new Rule
                                {
                                    Name = "this a test rule1",
                                    Description = "djjsdpo",
                                    Template = "hdshljsq",
                                },
                                new Rule
                                {
                                    Name = "this a test rule2",
                                    Description = "djjsdpo",
                                    Template = "hdshljsq",
                                }

                            );
                        }

                        if (! context.Trades.Any())
                        {
                            context.Trades.AddRange(
                                
                                new Trade
                                {
                                    Account = dummyTester.UserName,
                                    BuyPrice = 5,
                                    BuyQuantity = 5
                                },
                                new Trade
                                {
                                    Account = dummyUser.UserName,
                                    BuyPrice = 10,
                                    BuyQuantity = 10
                                },
                                new Trade
                                {
                                    Account = dummyAdmin.UserName,
                                    BuyPrice = 15,
                                    BuyQuantity = 15
                                }

                            );
                        }
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
