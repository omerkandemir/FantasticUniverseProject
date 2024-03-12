using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes;

public class UnionCharacterManager : IUnionCharacterService
{
    private readonly IUnionCharacterDal _unionCharacterDal;
    public UnionCharacterManager(IUnionCharacterDal unionCharacterDal)
    {
        _unionCharacterDal = unionCharacterDal;
    }
    public void Add(UnionCharacter unionCharacter)
    {
        _unionCharacterDal.Add(unionCharacter);
    }
    public void Update(UnionCharacter unionCharacter)
    {
        _unionCharacterDal.Update(unionCharacter);
    }
    public void Delete(UnionCharacter unionCharacter)
    {
        _unionCharacterDal.Delete(unionCharacter);
    }
    public UnionCharacter Get(int id)
    {
        return _unionCharacterDal.Get(x => x.Id == id);
    }
    public List<UnionCharacter> GetAll()
    {
        return _unionCharacterDal.GetAll();
    }    
}
