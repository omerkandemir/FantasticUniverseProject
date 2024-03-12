using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes;

public class PlanetManager : IPlanetService
{
    private readonly IPlanetDal _planetDal;
    public PlanetManager(IPlanetDal planetDal)
    {
        _planetDal = planetDal;
    }
    public void Add(Planet planet)
    {
        _planetDal.Add(planet);
    }
    public void Update(Planet planet)
    {
        _planetDal.Update(planet);
    }
    public void Delete(Planet planet)
    {
        _planetDal.Delete(planet);
    }
    public Planet Get(int id)
    {
        return _planetDal.Get(x => x.Id == id);
    }
    public List<Planet> GetAll()
    {
     return _planetDal.GetAll();
    }
}
