using Microsoft.EntityFrameworkCore;
using SatlinkUsersManagment3.Data;
using SatlinkUsersManagment3.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SatlinkUsersManagment3.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task SaveUsers(List<User> users)
        {
            // Lista para almacenar los IDs de usuarios existentes
            var existingUserIds = _context.Users.Select(u => u.Id).ToList();

            // Filtrar usuarios nuevos y existentes
            var usersToCreate = users.Where(u => !existingUserIds.Contains(u.Id)).ToList();
            var usersToUpdate = users.Except(usersToCreate).ToList();

            // Insertar nuevos usuarios
            await _context.Users.AddRangeAsync(usersToCreate);

            // Actualizar usuarios existentes
            foreach (var userToUpdate in usersToUpdate)
            {
                _context.Entry(userToUpdate).State = EntityState.Modified;
                _context.Entry(userToUpdate.Company).State = EntityState.Modified;
                _context.Entry(userToUpdate.Address).State = EntityState.Modified;
                _context.Entry(userToUpdate.Address.Geo).State = EntityState.Modified;
            }

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();

            // Desvincular todas las entidades del contexto
            DetachAllEntities(_context);
        }

        private void DetachAllEntities(AppDbContext context)
        {
            // Obtener todas las entidades rastreadas en el contexto y desvincularlas
            var trackedEntities = context.ChangeTracker.Entries().ToList();
            foreach (var entity in trackedEntities)
            {
                context.Entry(entity.Entity).State = EntityState.Detached;
            }
        }
    }
}
