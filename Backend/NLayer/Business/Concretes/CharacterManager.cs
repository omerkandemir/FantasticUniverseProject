using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes;

public class CharacterManager : ICharacterService
{
    private readonly ICharacterDal _characterDal;
    public CharacterManager(ICharacterDal characterDal)
    {
        _characterDal = characterDal;
    }
    public void Add(Character character)
    {
        _characterDal.Add(character);
    }
    public void Update(Character character)
    {
        _characterDal.Update(character);
    }
    public void Delete(Character character)
    {
        _characterDal.Delete(character);
    }
    public Character Get(int id)
    {
       return _characterDal.Get(x => x.Id == id);
    }
    public List<Character> GetAll()
    {
        return _characterDal.GetAll();
    }
}
