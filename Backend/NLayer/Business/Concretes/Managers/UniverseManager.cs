﻿using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class UniverseManager : BaseManager<Universe, IUniverseDal>, IUniverseService
{
    public UniverseManager(IUniverseDal tdal) : base(tdal)
    {
    }
}