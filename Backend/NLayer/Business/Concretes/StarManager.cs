using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes;

public class StarManager : IStarService
{
    private readonly IStarDal _starDal;
    public StarManager(IStarDal starDal)
    {
        _starDal = starDal;
    }
    public void Add(Star star)
    {
        _starDal.Add(star);
    }
    public void Update(Star star)
    {
        _starDal.Update(star);
    }
    public void Delete(Star star)
    {
        _starDal.Delete(star);
    }
    public Star Get(int id)
    {
        return _starDal.Get(x => x.Id == id);
    }
    public List<Star> GetAll()
    {
        return _starDal.GetAll();
    }
}
