using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

//Eğer veri yoksa ilk eklenen veriyi UnionLeader yapmayı düşün
public class UnionManager : BaseManager<Union, IUnionDal>, IUnionService
{
    public UnionManager(IUnionDal tdal) : base(tdal)
    {
    }
}
