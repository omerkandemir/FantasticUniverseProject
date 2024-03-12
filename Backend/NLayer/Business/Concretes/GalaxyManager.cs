using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes;

public class GalaxyManager : IGalaxyService
{
    private readonly IGalaxyDal _galaxyDal;
    public GalaxyManager(IGalaxyDal galaxyDal)
    {
        _galaxyDal = galaxyDal;
    }
    public void Add(Galaxy galaxy)
    {
        _galaxyDal.Add(galaxy);
    }
    public void Update(Galaxy galaxy)
    {
        _galaxyDal.Update(galaxy);
    }
    public void Delete(Galaxy galaxy)
    {
        _galaxyDal.Delete(galaxy);
    }
    public Galaxy Get(int id)
    {
        return _galaxyDal.Get(x => x.Id == id);
    }
    public List<Galaxy> GetAll()
    {
        return _galaxyDal.GetAll();
    }
}
