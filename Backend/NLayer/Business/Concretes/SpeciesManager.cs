using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.Species;
using NLayer.Dto.Responses.Species;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Business.Concretes
{
    public class SpeciesManager : ISpeciesService
    {
        public CreatedSpeciesResponse Add(CreateSpeciesRequest createRequest)
        {
            throw new NotImplementedException();
        }

        public DeletedSpeciesResponse Delete(DeleteSpeciesRequest deleteRequest)
        {
            throw new NotImplementedException();
        }

        public GetAllSpeciesResponse Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<GetAllSpeciesResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public UpdatedSpeciesResponse Update(UpdateSpeciesRequest updateRequest)
        {
            throw new NotImplementedException();
        }
    }
}
