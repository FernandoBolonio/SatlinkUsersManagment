using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SatlinkUsersManagment2.Data;
using SatlinkUsersManagment2.Models;

namespace SatlinkUsersManagment2.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;

        public DetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public User User { get; set; }
        public int? UserId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserId = id;

            User = await _context.Users
                .Include(u => u.Address)
                .ThenInclude(a => a.Geo)
                .Include(u => u.Company)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (User == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string name)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var userToUpdate = await _context.Users
                   .Include(u => u.Address)
                   .ThenInclude(a => a.Geo)
                   .Include(u => u.Company)
                   .FirstOrDefaultAsync(m => m.Id == id);

            if (userToUpdate == null)
            {
                return NotFound();
            }

            // Actualizar solo los campos necesarios
            userToUpdate.Name = name;

            // Adjuntar y marcar como modificado
            _context.Attach(userToUpdate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (id != null && !UserExists(id.Value))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Details", new { id = id });
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
