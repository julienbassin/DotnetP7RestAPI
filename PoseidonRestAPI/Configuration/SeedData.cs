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


                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
