using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SatlinkUsersManagment2.Data;
using SatlinkUsersManagment2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SatlinkUsersManagment2.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<User> Users { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Users = await _context.Users.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
