using Microsoft.AspNetCore.Mvc;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Core.Entities.Authentication;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.Universe;
using System.Text.Json;

namespace Test.PresentationLayer.Controllers
{
    public class UniverseController : Controller
    {
        private readonly IUniverseDto _universeDto;
        private readonly IUniverseService _universeService;
        private readonly IAppUserDto _appUserDto;
        public UniverseController(IUniverseDto universeDto, IUniverseService universeService, IAppUserDto appUserDto)
        {
            _universeDto = universeDto;
            _universeService = universeService;
            _appUserDto = appUserDto;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateUniverseRequest createUniverseRequest)
        {
            if (!string.IsNullOrEmpty(createUniverseRequest.GalaxiesJson))
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true  // Küçük/büyük harf duyarlılığını kapatır
                };

                createUniverseRequest.Galaxies = JsonSerializer.Deserialize<List<NLayer.Entities.Concretes.Galaxy>>(createUniverseRequest.GalaxiesJson, options);
            }

            if (!ModelState.IsValid)
                return View(createUniverseRequest);

            var result = await _universeDto.CreateUniverseAsync(createUniverseRequest);

            if (result.Success)
            {
                ViewBag.SuccessMessage = "Evren başarıyla oluşturuldu.";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Evren oluşturulurken bir hata oluştu.");
            }
            return View(createUniverseRequest);
        }


        [HttpGet]
        public async Task<IActionResult> MyUniverses()
        {

            // Giriş yapan kullanıcının ID'sini alıyoruz
            var user = await _appUserDto.GetUserByNameAsync(User.Identity.Name) as SuccessResponse<AppUser>;
            
            if (user == null)
            {
                return Unauthorized(); // Giriş yapılmamışsa yetkisiz durumu
            }

            var universeList = await _universeDto.GetUserUniversesAsync(user.Entity.Id);

            return View(universeList);
        }

        // Seçilen evrenin detay sayfası
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var universe = await _universeDto.GetUniverseDetailAsync(id);
            if (universe == null)
            {
                return NotFound();
            }
            return View(universe);
        }
    }
}
