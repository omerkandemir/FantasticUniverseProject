using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes;

//Eğer veri yoksa ilk eklenen veriyi UnionLeader yapmayı düşün
public class UnionManager : IUnionService
{
    private readonly IUnionDal _unionDal;
    public UnionManager(IUnionDal unionDal)
    {
        _unionDal = unionDal;
    }
    public void Add(Union union)
    {
        _unionDal.Add(union);
    }
    public void Update(Union union)
    {
        _unionDal.Update(union);
    }
    public void Delete(Union union)
    {
        _unionDal.Delete(union);
    }
    public Union Get(int id)
    {
        return _unionDal.Get(x => x.Id == id);
    }
    public List<Union> GetAll()
    {
        return _unionDal.GetAll();
    }
}
