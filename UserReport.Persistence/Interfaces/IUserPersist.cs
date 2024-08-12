namespace UserReport.Persistence.Interfaces;

using UserReport.Domain;

public interface IUserPersist
{
    void Add<T>(T entity)
        where T : class;

    Task<User?> GetUserByIdAsync(Guid userId);

    Task<bool> SaveChangesAsync();
}
