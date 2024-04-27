﻿using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class AdventureManager : BaseManager<Adventure, IAdventureDal>, IAdventureService
{
    public AdventureManager(IAdventureDal tdal) : base(tdal)
    {
    }
}