﻿using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes;

public class SpeciesManager : BaseManager<Species, ISpeciesDal>, ISpeciesService
{
    public SpeciesManager(ISpeciesDal tdal) : base(tdal)
    {
    }
}
