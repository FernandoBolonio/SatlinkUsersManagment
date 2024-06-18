using Microsoft.EntityFrameworkCore;
using SatlinkUsersManagment1.Data;
using SatlinkUsersManagment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatlinkUsersManagment1.Services
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
            var usersToCreate = users.Where(x => !(_context.Users.Any(y => y.Id == x.Id))).ToList();
            var usersToUpdate = users.Except(usersToCreate);

            //Insertamos los usuarios nuevos
            _context.Users.AddRange(usersToCreate);

            //Iteramos sobre los usuarios que hay que actualizar
            foreach (var userToUpdate in usersToUpdate)
            {
                _context.Users.Attach(userToUpdate);
                _context.Users.Entry(userToUpdate).State = EntityState.Modified;

                _context.Attach(userToUpdate.Company);
                _context.Entry(userToUpdate.Company).State = EntityState.Modified;

                _context.Attach(userToUpdate.Address);
                _context.Entry(userToUpdate.Address).State = EntityState.Modified;

                _context.Attach(userToUpdate.Address.Geo);
                _context.Entry(userToUpdate.Address.Geo).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
        }
    }
}