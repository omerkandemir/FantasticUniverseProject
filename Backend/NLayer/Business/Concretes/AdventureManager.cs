using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes;

public class AdventureManager : IAdventureService
{
    private readonly IAdventureDal _adventureDal;
    public AdventureManager(IAdventureDal adventureDal)
    {
        _adventureDal = adventureDal;
    }

    public void Add(Adventure adventure)
    {
        _adventureDal.Add(adventure);
    }
    public void Update(Adventure adventure)
    {
        _adventureDal.Update(adventure);
    }
    public void Delete(Adventure adventure)
    {
        _adventureDal.Delete(adventure);
    }
    public Adventure Get(int id)
    {
        return _adventureDal.Get(x => x.Id == id);
    }
    public List<Adventure> GetAll()
    {
        return _adventureDal.GetAll();
    }
}
