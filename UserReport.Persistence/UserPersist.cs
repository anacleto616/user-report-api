namespace UserReport.Persistence;

using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserReport.Domain;
using UserReport.Persistence.Contexts;
using UserReport.Persistence.Interfaces;

public class UserReportPersist(UserReportContext context) : IUserPersist
{
    private readonly UserReportContext context = context;

    public void Add<T>(T entity)
        where T : class => this.context.Add(entity);

    public async Task<User?> GetUserByIdAsync(Guid userId)
    {
        IQueryable<User> query = this.context.Users;

        query = query.Where(u => u.UserId == userId);

        return await query.FirstOrDefaultAsync();
    }

    public async Task<bool> SaveChangesAsync() => (await this.context.SaveChangesAsync()) > 0;
}
