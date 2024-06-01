﻿using BarberFusion.Application.Interfaces.Repositories;
using BarberFusion.Domain.Entities;
using BarberFusion.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BarberFusion.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly BarberFusionContext _context;

        public RoleRepository(BarberFusionContext context)
        {
            _context = context;
        }

        public async Task<Role> GetByIdAsync(Guid id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task AddAsync(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role != null)
            {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
            }
        }
    }
}
