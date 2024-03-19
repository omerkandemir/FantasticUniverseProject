﻿using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes;

public class PlanetManager : BaseManager<Planet, IPlanetDal>, IPlanetService
{
    public PlanetManager(IPlanetDal tdal) : base(tdal)
    {
    }
}
