using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes;

public class SpeciesManager : ISpeciesService
{
    private readonly ISpeciesDal _speciesDal;
    public SpeciesManager(ISpeciesDal speciesDal)
    {
        _speciesDal = speciesDal;
    }
    public void Add(Species species)
    {
        _speciesDal.Add(species);
    }
    public void Update(Species species)
    {
        _speciesDal.Update(species);
    }
    public void Delete(Species species)
    {
        _speciesDal.Delete(species);
    }
    public Species Get(int id)
    {
        return _speciesDal.Get(x => x.Id == id);
    }
    public List<Species> GetAll()
    {
        return _speciesDal.GetAll();
    }
}
