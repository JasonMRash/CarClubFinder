using CarClubWebApp.Data.Enum;
using CarClubWebApp.Models;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;

namespace CarClubWebApp.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Clubs.Any())
                {
                    context.Clubs.AddRange(new List<Club>()
                    {
                        new Club()
                        {
                            Title = "Salina SCCA",
                            Image = "http://www.salinascca.org/wp-content/uploads/2018/12/SCCABanner4.jpg",
                            Website="http://salinascca.org",
                            Description = "Salina Region Sports Car Club of America",
                            ClubCategory = ClubCategory.SCCA,
                            Address = new Address()
                            {
                                Street = "841 Markley Rd.",
                                City = "Salina",
                                State = "KS"
                            }
                         },
                        new Club()
                        {
                            Title = "Wichita SCCA",
                            Image = "https://www.wichitascca.org/ict_images/bg_6.jpg",
                            Website = "http://www.wichitascca.org",
                            Description = "Wichita Region Sports Car Club of America",
                            ClubCategory = ClubCategory.SCCA,
                            Address = new Address()
                            {
                                Street = "1117 E Red Rock Rd",
                                City = "Hutchison",
                                State = "KS"
                            }
                        },
                        new Club()
                        {
                            Title = "Wichita PCA",
                            Image = "https://wrpca.wildapricot.org/Content/ArtText/40339.png?text=%20Wichita%20Region%2C%20Porsche%20Club%20of%20America%20&style=Site%20title%201&styleGroup=100&tc1=666666&tc2=333333&fn=Travelogue&fs=36&sid=197452340910795",
                            Website = "https://wrpca.wildapricot.org/",
                            Description = "Wichita Region Porche Club of America",
                            ClubCategory = ClubCategory.PCA,
                            Address = new Address()
                            {
                                Street = "1117 E Red Rock Rd",
                                City = "Hutchison",
                                State = "KS"
                            }
                        },
                        new Club()
                        {
                            Title = "Kansas City SCCA",
                            Image = "https://i0.wp.com/www.kcrscca.org/wp-content/uploads/2018/12/KCSCCA_horizaontal2019_2.png?w=936&ssl=1",
                            Website = "https://www.kcrscca.org",
                            Description = "Kansas City Region Sports Car Club of America",
                            ClubCategory = ClubCategory.SCCA,
                            Address = new Address()
                            {
                                Street = "1322 South Powell Rd",
                                City = "Independence",
                                State = "MO"
                            }
                        }
                    });
                    context.SaveChanges();
                }
                //Races
                if (!context.Competitions.Any())
                {
                    context.Competitions.AddRange(new List<Competition>()
                    {
                        new Competition()
                        {
                            Title = "Salina Autocross Event #1",
                            Image = "https://dl.motorsportreg.com/09f64688-3695-4327-943b-8cdc176bea72/-/crop/1959x1102/0,102/-/preview/",
                            Description = "Autocross Event #1 March 19th",
                            CompetitionCategory = CompetitionCategory.Autocross,
                            Address = new Address()
                            {
                                Street = "841 Markley Rd.",
                                City = "Salina",
                                State = "KS"
                            }
                        },
                        new Competition()
                        {
                            Title = "Wichita Rallycross Event #1",
                            Image = "https://www.wichitascca.org/ict_images/bg_6.jpg",
                            Description = "Rallycross Event #1 April 9th",
                            CompetitionCategory = CompetitionCategory.Rallycross,
                            AddressId = 5,
                            Address = new Address()
                            {
                                Street = "609 N 1st St",
                                City = "Mulvane",
                                State = "KS"
                            }

                        }
                    });
                    context.SaveChanges();
                }
            }

        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "jasonmichaelrash@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "jasonrash",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        Address = new Address()
                        {
                            Street = "409 Morgan Ave",
                            City = "Downs",
                            State = "KS"
                        }
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        Address = new Address()
                        {
                            Street = "1234 Main St",
                            City = "Topeka",
                            State = "KS"
                        }
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
