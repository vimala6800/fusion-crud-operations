using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PartnerPortal.Domain.Entities;
using PartnerPortal.Infrastructure.Identity;

namespace PartnerPortal.Infrastructure.Persistence
{
    public class ApplicationDbContextInitialiser
    {
        private readonly ILogger<ApplicationDbContextInitialiser> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                if (_context.Database.IsSqlServer())
                {
                    await _context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        public async Task TrySeedAsync()
        {
            // Default roles
            var administratorRole = new IdentityRole("Administrator");

            if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await _roleManager.CreateAsync(administratorRole);
            }

            // Default users
            var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

            if (_userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await _userManager.CreateAsync(administrator, "Administrator1!");
                await _userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
            }

            // Default data
            // Seed, if necessary
            if (!_context.TodoLists.Any())
            {
                _context.TodoLists.Add(new TodoList
                {
                      Title = "Todo List",
                      Items =
                 {
                      new TodoItem { Title = "Make a todo list 📃" },
                      new TodoItem { Title = "Check off the first item ✅" },
                    new TodoItem { Title = "Realise you've already done two things on the list! 🤯"},
                    new TodoItem { Title = "Reward yourself with a nice, long nap 🏆" },
                }
                });

                await _context.SaveChangesAsync();
            }


            if (!_context.Counts.Any())
            {
                _context.Counts.Add(new Count() { CountryName = "Afghanistan" });
                _context.Counts.Add(new Count() { CountryName = "Åland Islands" });
                _context.Counts.Add(new Count() { CountryName = "Albania" });
                _context.Counts.Add(new Count() { CountryName = "Algeria" });
                _context.Counts.Add(new Count() { CountryName = "American Samoa" });
                _context.Counts.Add(new Count() { CountryName = "Andorra" });
                _context.Counts.Add(new Count() { CountryName = "Angola" });
                _context.Counts.Add(new Count() { CountryName = "Anguilla" });
                _context.Counts.Add(new Count() { CountryName = "Antarctica" });
                _context.Counts.Add(new Count() { CountryName = "Antigua and Barbuda" });
                _context.Counts.Add(new Count() { CountryName = "Argentina" });
                _context.Counts.Add(new Count() { CountryName = "Armenia" });
                _context.Counts.Add(new Count() { CountryName = "Aruba" });
                _context.Counts.Add(new Count() { CountryName = "Australia" });
                _context.Counts.Add(new Count() { CountryName = "Austria" });
                _context.Counts.Add(new Count() { CountryName = "Azerbaijan" });
                _context.Counts.Add(new Count() { CountryName = "Bahamas" });
                _context.Counts.Add(new Count() { CountryName = "Bahrain" });
                _context.Counts.Add(new Count() { CountryName = "Bangladesh" });
                _context.Counts.Add(new Count() { CountryName = "Barbados" });
                _context.Counts.Add(new Count() { CountryName = "Belarus" });
                _context.Counts.Add(new Count() { CountryName = "Belgium" });
                _context.Counts.Add(new Count() { CountryName = "Belize" });
                _context.Counts.Add(new Count() { CountryName = "Benin" });
                _context.Counts.Add(new Count() { CountryName = "Bermuda" });
                _context.Counts.Add(new Count() { CountryName = "Bhutan" });
                _context.Counts.Add(new Count() { CountryName = "Bolivia" });
                _context.Counts.Add(new Count() { CountryName = "Bosnia and Herzegovina" });
                _context.Counts.Add(new Count() { CountryName = "Botswana" });
                _context.Counts.Add(new Count() { CountryName = "Bouvet Island" });
                _context.Counts.Add(new Count() { CountryName = "Brazil" });
                _context.Counts.Add(new Count() { CountryName = "British Indian Ocean Territory" });
                _context.Counts.Add(new Count() { CountryName = "Brunei Darussalam" });
                _context.Counts.Add(new Count() { CountryName = "Bulgaria" });
                _context.Counts.Add(new Count() { CountryName = "Burkina Faso" });
                _context.Counts.Add(new Count() { CountryName = "Burundi" });
                _context.Counts.Add(new Count() { CountryName = "Cambodia" });
                _context.Counts.Add(new Count() { CountryName = "Cameroon" });
                _context.Counts.Add(new Count() { CountryName = "Canada" });
                _context.Counts.Add(new Count() { CountryName = "Cape Verde" });
                _context.Counts.Add(new Count() { CountryName = "Cayman Islands" });
                _context.Counts.Add(new Count() { CountryName = "Central African Republic" });
                _context.Counts.Add(new Count() { CountryName = "Chad" });
                _context.Counts.Add(new Count() { CountryName = "Chile" });
                _context.Counts.Add(new Count() { CountryName = "China" });
                _context.Counts.Add(new Count() { CountryName = "Christmas Island" });
                _context.Counts.Add(new Count() { CountryName = "Cocos (Keeling) Islands" });
                _context.Counts.Add(new Count() { CountryName = "Colombia" });
                _context.Counts.Add(new Count() { CountryName = "Comoros" });
                _context.Counts.Add(new Count() { CountryName = "Congo" });
                _context.Counts.Add(new Count() { CountryName = "Cook Islands" });
                _context.Counts.Add(new Count() { CountryName = "Costa Rica" });
                _context.Counts.Add(new Count() { CountryName = "Cote D'ivoire" });
                _context.Counts.Add(new Count() { CountryName = "Croatia" });
                _context.Counts.Add(new Count() { CountryName = "Cuba" });
                _context.Counts.Add(new Count() { CountryName = "Cyprus" });
                _context.Counts.Add(new Count() { CountryName = "Czech Republic" });
                _context.Counts.Add(new Count() { CountryName = "Denmark" });
                _context.Counts.Add(new Count() { CountryName = "Djibouti" });
                _context.Counts.Add(new Count() { CountryName = "Dominica" });
                _context.Counts.Add(new Count() { CountryName = "Dominican Republic" });
                _context.Counts.Add(new Count() { CountryName = "Ecuador" });
                _context.Counts.Add(new Count() { CountryName = "Egypt" });
                _context.Counts.Add(new Count() { CountryName = "El Salvador" });
                _context.Counts.Add(new Count() { CountryName = "Equatorial Guinea" });
                _context.Counts.Add(new Count() { CountryName = "Eritrea" });
                _context.Counts.Add(new Count() { CountryName = "Estonia" });
                _context.Counts.Add(new Count() { CountryName = "Ethiopia" });
                _context.Counts.Add(new Count() { CountryName = "Falkland Islands (Malvinas)" });
                _context.Counts.Add(new Count() { CountryName = "Faroe Islands" });
                _context.Counts.Add(new Count() { CountryName = "Fiji" });
                _context.Counts.Add(new Count() { CountryName = "Finland" });
                _context.Counts.Add(new Count() { CountryName = "France" });
                _context.Counts.Add(new Count() { CountryName = "French Guiana" });
                _context.Counts.Add(new Count() { CountryName = "French Polynesia" });
                _context.Counts.Add(new Count() { CountryName = "French Southern Territories" });
                _context.Counts.Add(new Count() { CountryName = "Gabon" });
                _context.Counts.Add(new Count() { CountryName = "Gambia" });
                _context.Counts.Add(new Count() { CountryName = "Georgia" });
                _context.Counts.Add(new Count() { CountryName = "Germany" });
                _context.Counts.Add(new Count() { CountryName = "Ghana" });
                _context.Counts.Add(new Count() { CountryName = "Gibraltar" });
                _context.Counts.Add(new Count() { CountryName = "Greece" });
                _context.Counts.Add(new Count() { CountryName = "Greenland" });
                _context.Counts.Add(new Count() { CountryName = "Grenada" });
                _context.Counts.Add(new Count() { CountryName = "Guadeloupe" });
                _context.Counts.Add(new Count() { CountryName = "Guam" });
                _context.Counts.Add(new Count() { CountryName = "Guatemala" });
                _context.Counts.Add(new Count() { CountryName = "Guernsey" });
                _context.Counts.Add(new Count() { CountryName = "Guinea" });
                _context.Counts.Add(new Count() { CountryName = "Guinea-bissau" });
                _context.Counts.Add(new Count() { CountryName = "Guyana" });
                _context.Counts.Add(new Count() { CountryName = "Haiti" });
                _context.Counts.Add(new Count() { CountryName = "Heard Island and Mcdonald Islands" });
                _context.Counts.Add(new Count() { CountryName = "Holy See (Vatican City State)" });
                _context.Counts.Add(new Count() { CountryName = "Honduras" });
                _context.Counts.Add(new Count() { CountryName = "Hong Kong" });
                _context.Counts.Add(new Count() { CountryName = "Hungary" });
                _context.Counts.Add(new Count() { CountryName = "Iceland" });
                _context.Counts.Add(new Count() { CountryName = "India" });
                _context.Counts.Add(new Count() { CountryName = "Indonesia" });
                _context.Counts.Add(new Count() { CountryName = "Iran, Islamic Republic of" });
                _context.Counts.Add(new Count() { CountryName = "Iraq" });
                _context.Counts.Add(new Count() { CountryName = "Ireland" });
                _context.Counts.Add(new Count() { CountryName = "Isle of Man" });
                _context.Counts.Add(new Count() { CountryName = "Israel" });
                _context.Counts.Add(new Count() { CountryName = "Italy" });
                _context.Counts.Add(new Count() { CountryName = "Jamaica" });
                _context.Counts.Add(new Count() { CountryName = "Japan" });
                _context.Counts.Add(new Count() { CountryName = "Jersey" });
                _context.Counts.Add(new Count() { CountryName = "Jordan" });
                _context.Counts.Add(new Count() { CountryName = "Kazakhstan" });
                _context.Counts.Add(new Count() { CountryName = "Kenya" });
                _context.Counts.Add(new Count() { CountryName = "Kiribati" });
                _context.Counts.Add(new Count() { CountryName = "South Korea" });
                _context.Counts.Add(new Count() { CountryName = "North Korea" });
                _context.Counts.Add(new Count() { CountryName = "Kuwait" });
                _context.Counts.Add(new Count() { CountryName = "Kyrgyzstan" });
                _context.Counts.Add(new Count() { CountryName = "Lao People's Democratic Republic" });
                _context.Counts.Add(new Count() { CountryName = "Latvia" });
                _context.Counts.Add(new Count() { CountryName = "Lebanon" });
                _context.Counts.Add(new Count() { CountryName = "Lesotho" });
                _context.Counts.Add(new Count() { CountryName = "Liberia" });
                _context.Counts.Add(new Count() { CountryName = "Libyan Arab Jamahiriya" });
                _context.Counts.Add(new Count() { CountryName = "Liechtenstein" });
                _context.Counts.Add(new Count() { CountryName = "Lithuania" });
                _context.Counts.Add(new Count() { CountryName = "Luxembourg" });
                _context.Counts.Add(new Count() { CountryName = "Macao" });
                _context.Counts.Add(new Count() { CountryName = "Macedonia" });
                _context.Counts.Add(new Count() { CountryName = "Madagascar" });
                _context.Counts.Add(new Count() { CountryName = "Malawi" });
                _context.Counts.Add(new Count() { CountryName = "Malaysia" });
                _context.Counts.Add(new Count() { CountryName = "Maldives" });
                _context.Counts.Add(new Count() { CountryName = "Mali" });
                _context.Counts.Add(new Count() { CountryName = "Malta" });
                _context.Counts.Add(new Count() { CountryName = "Marshall Islands" });
                _context.Counts.Add(new Count() { CountryName = "Martinique" });
                _context.Counts.Add(new Count() { CountryName = "Mauritania" });
                _context.Counts.Add(new Count() { CountryName = "Mauritius" });
                _context.Counts.Add(new Count() { CountryName = "Mayotte" });
                _context.Counts.Add(new Count() { CountryName = "Mexico" });
                _context.Counts.Add(new Count() { CountryName = "Micronesia" });
                _context.Counts.Add(new Count() { CountryName = "Moldova" });
                _context.Counts.Add(new Count() { CountryName = "Monaco" });
                _context.Counts.Add(new Count() { CountryName = "Mongolia" });
                _context.Counts.Add(new Count() { CountryName = "Montenegro" });
                _context.Counts.Add(new Count() { CountryName = "Montserrat" });
                _context.Counts.Add(new Count() { CountryName = "Morocco" });
                _context.Counts.Add(new Count() { CountryName = "Mozambique" });
                _context.Counts.Add(new Count() { CountryName = "Myanmar" });
                _context.Counts.Add(new Count() { CountryName = "Namibia" });
                _context.Counts.Add(new Count() { CountryName = "Nauru" });
                _context.Counts.Add(new Count() { CountryName = "Nepal" });
                _context.Counts.Add(new Count() { CountryName = "Netherlands" });
                _context.Counts.Add(new Count() { CountryName = "Netherlands Antilles" });
                _context.Counts.Add(new Count() { CountryName = "New Caledonia" });
                _context.Counts.Add(new Count() { CountryName = "New Zealand" });
                _context.Counts.Add(new Count() { CountryName = "Nicaragua" });
                _context.Counts.Add(new Count() { CountryName = "Niger" });
                _context.Counts.Add(new Count() { CountryName = "Nigeria" });
                _context.Counts.Add(new Count() { CountryName = "Niue" });
                _context.Counts.Add(new Count() { CountryName = "Norfolk Island" });
                _context.Counts.Add(new Count() { CountryName = "Northern Mariana Islands" });
                _context.Counts.Add(new Count() { CountryName = "Norway" });
                _context.Counts.Add(new Count() { CountryName = "Oman" });
                _context.Counts.Add(new Count() { CountryName = "Pakistan" });
                _context.Counts.Add(new Count() { CountryName = "Palau" });
                _context.Counts.Add(new Count() { CountryName = "Palestinian Territory, Occupied" });
                _context.Counts.Add(new Count() { CountryName = "Panama" });
                _context.Counts.Add(new Count() { CountryName = "Papua New Guinea" });
                _context.Counts.Add(new Count() { CountryName = "Paraguay" });
                _context.Counts.Add(new Count() { CountryName = "Peru" });
                _context.Counts.Add(new Count() { CountryName = "Philippines" });
                _context.Counts.Add(new Count() { CountryName = "Pitcairn" });
                _context.Counts.Add(new Count() { CountryName = "Poland" });
                _context.Counts.Add(new Count() { CountryName = "Portugal" });
                _context.Counts.Add(new Count() { CountryName = "Puerto Rico" });
                _context.Counts.Add(new Count() { CountryName = "Qatar" });
                _context.Counts.Add(new Count() { CountryName = "Reunion" });
                _context.Counts.Add(new Count() { CountryName = "Romania" });
                _context.Counts.Add(new Count() { CountryName = "Russian Federation" });
                _context.Counts.Add(new Count() { CountryName = "Rwanda" });
                _context.Counts.Add(new Count() { CountryName = "Saint Helena" });
                _context.Counts.Add(new Count() { CountryName = "Saint Kitts and Nevis" });
                _context.Counts.Add(new Count() { CountryName = "Saint Lucia" });
                _context.Counts.Add(new Count() { CountryName = "Saint Pierre and Miquelon" });
                _context.Counts.Add(new Count() { CountryName = "Saint Vincent and The Grenadines" });
                _context.Counts.Add(new Count() { CountryName = "Samoa" });
                _context.Counts.Add(new Count() { CountryName = "San Marino" });
                _context.Counts.Add(new Count() { CountryName = "Sao Tome and Principe" });
                _context.Counts.Add(new Count() { CountryName = "Saudi Arabia" });
                _context.Counts.Add(new Count() { CountryName = "Senegal" });
                _context.Counts.Add(new Count() { CountryName = "Serbia" });
                _context.Counts.Add(new Count() { CountryName = "Seychelles" });
                _context.Counts.Add(new Count() { CountryName = "Sierra Leone" });
                _context.Counts.Add(new Count() { CountryName = "Singapore" });
                _context.Counts.Add(new Count() { CountryName = "Slovenia" });
                _context.Counts.Add(new Count() { CountryName = ">Solomon Islands" });
                _context.Counts.Add(new Count() { CountryName = "Somalia" });
                _context.Counts.Add(new Count() { CountryName = "South Africa" });
                _context.Counts.Add(new Count() { CountryName = "South Georgia and The South Sandwich Islands" });
                _context.Counts.Add(new Count() { CountryName = "Spain" });
                _context.Counts.Add(new Count() { CountryName = "Sri Lanka" });
                _context.Counts.Add(new Count() { CountryName = "Sudan" });
                _context.Counts.Add(new Count() { CountryName = "Suriname" });
                _context.Counts.Add(new Count() { CountryName = "Svalbard and Jan Mayen" });
                _context.Counts.Add(new Count() { CountryName = "Swaziland" });
                _context.Counts.Add(new Count() { CountryName = "Swaziland" });
                _context.Counts.Add(new Count() { CountryName = "Switzerland" });
                _context.Counts.Add(new Count() { CountryName = "Syrian Arab Republic" });
                _context.Counts.Add(new Count() { CountryName = "Taiwan" });
                _context.Counts.Add(new Count() { CountryName = "Tanzania, United Republic of" });
                _context.Counts.Add(new Count() { CountryName = "Thailand" });
                _context.Counts.Add(new Count() { CountryName = "Timor-leste" });
                _context.Counts.Add(new Count() { CountryName = "Togo" });
                _context.Counts.Add(new Count() { CountryName = "Tokelau" });
                _context.Counts.Add(new Count() { CountryName = "Tonga" });
                _context.Counts.Add(new Count() { CountryName = "Trinidad and Tobago" });
                _context.Counts.Add(new Count() { CountryName = "Tunisia" });
                _context.Counts.Add(new Count() { CountryName = "Turkey" });
                _context.Counts.Add(new Count() { CountryName = "Turkmenistan" });
                _context.Counts.Add(new Count() { CountryName = "Turks and Caicos Islands" });
                _context.Counts.Add(new Count() { CountryName = "Tuvalu" });
                _context.Counts.Add(new Count() { CountryName = "Uganda" });
                _context.Counts.Add(new Count() { CountryName = "Ukraine" });
                _context.Counts.Add(new Count() { CountryName = "United Arab Emirate);s" });
                _context.Counts.Add(new Count() { CountryName = "United Kingdom" });
                _context.Counts.Add(new Count() { CountryName = "United States" });
                _context.Counts.Add(new Count() { CountryName = "United States Minor Outlying Islands" });
                _context.Counts.Add(new Count() { CountryName = "Uruguay" });
                _context.Counts.Add(new Count() { CountryName = "Uzbekistan" });
                _context.Counts.Add(new Count() { CountryName = "Vanuatu" });
                _context.Counts.Add(new Count() { CountryName = "Venezuela" });
                _context.Counts.Add(new Count() { CountryName = "Viet Nam" });
                _context.Counts.Add(new Count() { CountryName = "Virgin Islands, British" });
                _context.Counts.Add(new Count() { CountryName = "Virgin Islands, U.S." });
                _context.Counts.Add(new Count() { CountryName = "Wallis and Futuna" });
                _context.Counts.Add(new Count() { CountryName = "Western Sahara" });
                _context.Counts.Add(new Count() { CountryName = "Yemen" });
                _context.Counts.Add(new Count() { CountryName = "Zambia" });
                _context.Counts.Add(new Count() { CountryName = "Zimbabwe" });

                await _context.SaveChangesAsync();
            }

        }
    }
}

