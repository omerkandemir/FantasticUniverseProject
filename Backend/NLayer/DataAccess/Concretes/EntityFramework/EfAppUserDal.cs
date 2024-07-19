using NLAyer.Core.DataAccess.Concretes.EntityFramework;
using NLayer.DataAccess.Abstracts;
using NLayer.Core.Entities.Authentication;
using Microsoft.EntityFrameworkCore;

namespace NLayer.DataAccess.Concretes.EntityFramework;

public class EfAppUserDal : EfEntityRepositoryBase<AppUser, FantasticUniverseProjectContext>, IAppUserDal
{
    private readonly FantasticUniverseProjectContext _context;
    public EfAppUserDal(FantasticUniverseProjectContext context)
    {
        _context = context;
    }
    public async Task<AppUser> GetByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<bool> UpdateAsync(AppUser user)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                await transaction.RollbackAsync();
                _context.Entry(user).Reload(); // Veriyi yeniden yükleme
                return false;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                return false;
            }
        }
    }
}
