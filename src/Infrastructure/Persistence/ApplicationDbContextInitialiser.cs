using parsage_test.Domain.Entities;
using parsage_test.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace parsage_test.Infrastructure.Persistence;

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
            if (!string.IsNullOrWhiteSpace(administratorRole.Name))
            {
                await _userManager.AddToRolesAsync(administrator, new [] { administratorRole.Name });
            }
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

        Manufacturer gt = new Manufacturer {Id = 3, Name ="GT"};
        Manufacturer specialized = new Manufacturer {Id = 1, Name ="Specialized"};
        if (!_context.Manufacturers.Any())
        {
            _context.Manufacturers.Add(specialized);
            _context.Manufacturers.Add(gt);

            await _context.SaveChangesAsync();
        }
        
        if (!_context.Manufacturers.Any())
        {
            _context.Manufacturers.Add(specialized);
            _context.Manufacturers.Add(new Manufacturer {Id = 2, Name ="Canyon"});
            _context.Manufacturers.Add(gt);
            _context.Manufacturers.Add(new Manufacturer {Id = 4, Name ="Trek"});
            
            await _context.SaveChangesAsync();
        }
        
        if (!_context.Bikes.Any())
        {
            _context.Bikes.Add(new Bike
            {
                Id = 1,
                Manufacturer = gt,
                ManufacturerId = gt.Id,
                Model = "Aggressor",
                FrameSize = 19,
                Price = 299.98m
            });
            
            _context.Bikes.Add(new Bike
            {
                Id = 2,
                Manufacturer = specialized,
                ManufacturerId = specialized.Id,
                Model = "Rockhopper",
                FrameSize = 17,
                Price = 499.99m
            });
            
            await _context.SaveChangesAsync();
        }
    }
}
