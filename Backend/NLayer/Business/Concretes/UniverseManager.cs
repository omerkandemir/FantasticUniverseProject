using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes;

public class UniverseManager : IUniverseService
{
    private readonly IUniverseDal _universeDal;
    public UniverseManager(IUniverseDal universeDal)
    {
        _universeDal = universeDal;
    }
    public void Add(Universe universe)
    {
        _universeDal.Add(universe);
    }
    public void Update(Universe universe)
    {
        _universeDal.Update(universe);
    }
    public void Delete(Universe universe)
    {
        _universeDal.Delete(universe);
    }
    public Universe Get(int id)
    {
        return _universeDal.Get(x => x.Id == id);
    }
    public List<Universe> GetAll()
    {
        return _universeDal.GetAll();
    }
}
