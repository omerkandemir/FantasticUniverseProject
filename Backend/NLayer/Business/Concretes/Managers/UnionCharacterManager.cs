﻿using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class UnionCharacterManager : BaseManager<UnionCharacter, IUnionCharacterDal>, IUnionCharacterService
{
    public UnionCharacterManager(IUnionCharacterDal tdal) : base(tdal)
    {
    }
}