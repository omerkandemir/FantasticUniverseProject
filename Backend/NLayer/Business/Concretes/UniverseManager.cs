using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.Universe;
using NLayer.Dto.Responses.Universe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Business.Concretes
{
    public class UniverseManager : IUniverseService
    {
        public CreatedUniverseResponse Add(CreateUniverseRequest createRequest)
        {
            throw new NotImplementedException();
        }

        public DeletedUniverseResponse Delete(DeleteUniverseRequest deleteRequest)
        {
            throw new NotImplementedException();
        }

        public GetAllUniverseResponse Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<GetAllUniverseResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public UpdatedUniverseResponse Update(UpdateUniverseRequest updateRequest)
        {
            throw new NotImplementedException();
        }
    }
}
