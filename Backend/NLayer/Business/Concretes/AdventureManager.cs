using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.ValidationRules.FluentValidation;
using NLayer.Core.Business.Utilities;
using NLayer.DataAccess.Abstracts;
using NLayer.DataAccess.Concretes.EntityFramework;
using NLayer.Dto.Requests.Ability;
using NLayer.Dto.Requests.Adventure;
using NLayer.Dto.Responses.Ability;
using NLayer.Dto.Responses.Adventure;
using NLayer.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Business.Concretes
{
    public class AdventureManager : IAdventureService
    {
        IAdventureDal _adventureDal;
        IMapper _mapper;
        public AdventureManager(IAdventureDal adventureDal, IMapper mapper)
        {
            _adventureDal = adventureDal;
            _mapper = mapper;
        }

        public CreatedAdventureResponse Add(CreateAdventureRequest createRequest)
        {
            Adventure adventure = new();
            adventure.AdventureName = createRequest.AdventureName;
            adventure.PlanetId = createRequest.PlanetId;
            adventure.Occurrence = createRequest.Occurrence;
            adventure.StartTime = createRequest.StartTime;
            adventure.EndTime = createRequest.EndTime;

            _adventureDal.Add(adventure);

            CreatedAdventureResponse createAdventureResponse = new CreatedAdventureResponse();
            createAdventureResponse.Id = adventure.Id;
            createAdventureResponse.AdventureName = adventure.AdventureName;
            createAdventureResponse.PlanetId = adventure.PlanetId;
            createAdventureResponse.Occurrence = adventure.Occurrence;
            createAdventureResponse.StartTime = adventure.StartTime;
            createAdventureResponse.EndTime = adventure.EndTime;
            createAdventureResponse.CreatedDate = adventure.CreatedDate;
            return createAdventureResponse;
        }

        public DeletedAdventureResponse Delete(DeleteAdventureRequest deleteRequest)
        {
            Adventure adventure = new() { Id = deleteRequest.Id };
            _adventureDal.Delete(adventure);
            DeletedAdventureResponse deletedAdventureResponse = new DeletedAdventureResponse();
            deletedAdventureResponse.Id = adventure.Id;
            return deletedAdventureResponse;
        }

        public UpdatedAdventureResponse Update(UpdateAdventureRequest updateRequest)
        {
            Adventure adventure = new();
            adventure.Id = updateRequest.Id;
            adventure.AdventureName = updateRequest.AdventureName;
            adventure.PlanetId = updateRequest.PlanetId;
            adventure.Occurrence = updateRequest.Occurrence;
            adventure.StartTime = updateRequest.StartTime;
            adventure.EndTime = updateRequest.EndTime;

            _adventureDal.Update(adventure);

            UpdatedAdventureResponse updatedAdventureResponse = new UpdatedAdventureResponse();
            updatedAdventureResponse.Id = adventure.Id;
            updatedAdventureResponse.AdventureName = adventure.AdventureName;
            updatedAdventureResponse.PlanetId = adventure.PlanetId;
            updatedAdventureResponse.Occurrence = adventure.Occurrence;
            updatedAdventureResponse.StartTime = adventure.StartTime;
            updatedAdventureResponse.EndTime = adventure.EndTime;
            updatedAdventureResponse.UpdatedDate = adventure.UpdatedDate;
            return updatedAdventureResponse;
        }

        public GetAllAdventureResponse Get(int id)
        {
            GetAllAdventureResponse getAllAdventureResponse = new GetAllAdventureResponse();
            Adventure adventure = _adventureDal.Get(x => x.Id == id);
            getAllAdventureResponse.Id = adventure.Id;
            getAllAdventureResponse.AdventureName = adventure.AdventureName;
            getAllAdventureResponse.PlanetId = adventure.PlanetId;
            getAllAdventureResponse.Occurrence = adventure.Occurrence;
            getAllAdventureResponse.StartTime = adventure.StartTime;
            getAllAdventureResponse.EndTime = adventure.EndTime;
            getAllAdventureResponse.CreatedDate = adventure.CreatedDate;
            return getAllAdventureResponse;
        }

        public List<GetAllAdventureResponse> GetAll()
        {
            List<Adventure> adventures = _adventureDal.GetAll();

            List<GetAllAdventureResponse> getAllAdventureResponses = new List<GetAllAdventureResponse>();

            foreach (var adventure in adventures)
            {
                GetAllAdventureResponse getAllAdventureResponse = new GetAllAdventureResponse();
                getAllAdventureResponse.Id = adventure.Id;
            getAllAdventureResponse.AdventureName = adventure.AdventureName;
            getAllAdventureResponse.PlanetId = adventure.PlanetId;
            getAllAdventureResponse.Occurrence = adventure.Occurrence;
            getAllAdventureResponse.StartTime = adventure.StartTime;
            getAllAdventureResponse.EndTime = adventure.EndTime;
            getAllAdventureResponse.CreatedDate = adventure.CreatedDate;

                getAllAdventureResponses.Add(getAllAdventureResponse);
            }
            return getAllAdventureResponses;
        }
    }
}
