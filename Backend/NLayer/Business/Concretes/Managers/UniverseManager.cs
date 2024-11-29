using Microsoft.EntityFrameworkCore;
using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.UniverseValidation.Create;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.UniverseValidation.Delete;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.UniverseValidation.Update;
using NLayer.Core.Aspect.Autofac.Caching;
using NLayer.Core.Aspect.Autofac.Transaction;
using NLayer.Core.Aspect.Autofac.Validation;
using NLayer.Core.Utilities.Infos;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class UniverseManager : BaseManagerAsync<Universe, IUniverseDal>, IUniverseService
{
    private readonly IGalaxyDal _galaxyDal;
    private readonly IStarDal _starDal;
    private readonly IPlanetDal _planetDal;
    private readonly IThemeSettingDal _themeSettingDal;
    public UniverseManager(IUniverseDal tdal, IGalaxyDal galaxyDal, IStarDal starDal, IPlanetDal planetDal, IThemeSettingDal themeSettingDal) : base(tdal)
    {
        _galaxyDal = galaxyDal;
        _starDal = starDal;
        _planetDal = planetDal;
        _themeSettingDal = themeSettingDal;
    }

    [TransactionScopeAspect(Priority = 2)]
    [ValidationAspect(typeof(CreateUniverseValidator), Priority = 1)]
    public async Task<IReturnType> CreateUniverseAsync(Universe universe)
    {
        return await ExecuteSafely(async () =>
        {
            await AddThemeSettingAsync(universe);
            await _tdal.AddAsync(universe);

            foreach (var galaxy in universe.Galaxies)
            {
                await AddGalaxyAsync(galaxy, universe.Id);
            }
        }, CrudOperation.Add);
    }

    private async Task AddThemeSettingAsync(Universe universe)
    {
        var themeSetting = universe.ThemeSetting;
        await _themeSettingDal.AddAsync(universe.ThemeSetting);
        universe.ThemeSettingId = themeSetting.Id;
    }
    private async Task AddGalaxyAsync(Galaxy galaxy, int universeId)
    {
        var newGalaxy = new Galaxy
        {
            UniverseId = universeId,
            Name = galaxy.Name,
            Stars = new List<Star>()
        };

        await _galaxyDal.AddAsync(newGalaxy);

        foreach (var star in galaxy.Stars)
        {
            await AddStarAsync(star, newGalaxy.Id);
        }
    }
    private async Task AddStarAsync(Star star, int galaxyId)
    {
        var newStar = new Star
        {
            GalaxyId = galaxyId,
            Name = star.Name,
            Planets = new List<Planet>()
        };

        await _starDal.AddAsync(newStar);

        foreach (var planet in star.Planets)
        {
            await AddPlanetAsync(planet, newStar.Id);
        }
    }
    private async Task AddPlanetAsync(Planet planet, int starId)
    {
        var newPlanet = new Planet
        {
            StarId = starId,
            Name = planet.Name,
            PlanetAge = planet.PlanetAge,
            PlanetTemperature = planet.PlanetTemperature,
            PlanetMass = planet.PlanetMass
        };
        await _planetDal.AddAsync(newPlanet);
    }

    [ValidationAspect(typeof(CreateUniverseValidator), Priority = 1)]
    public override Task<IReturnType> AddAsync(Universe value)
    {
        return base.AddAsync(value);
    }
    [ValidationAspect(typeof(UpdateUniverseValidator), Priority = 1)]
    public override Task<IReturnType> UpdateAsync(Universe value)
    {
        return base.UpdateAsync(value);
    }
    [ValidationAspect(typeof(DeleteUniverseValidator), Priority = 1)]
    public override Task<IReturnType> DeleteAsync(Universe value)
    {
        return base.DeleteAsync(value);
    }

    [CacheAspect(duration: 60)]
    public async Task<IDataReturnType<ICollection<Universe>>> GetUserUniversesAsync(int userId)
    {
        return await ExecuteQuerySafelyWithResult(() => 
        _tdal.GetAllAsync(x => x.CreatedBy == userId, include: query => query.Include(q => q.ThemeSetting)),
            CrudOperation.List
        );
    }
    [CacheAspect(duration: 60)]
    public override async Task<IDataReturnType<Universe>> GetAsync(object id)
    {
        return await ExecuteQuerySafelyWithResult(() => _tdal.GetAsync(x => x.Id == Convert.ToInt32(id), include: query => query.Include(q => q.ThemeSetting)),
            CrudOperation.Get
        );
    }
}
