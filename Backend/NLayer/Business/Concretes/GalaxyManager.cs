using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.Galaxy;
using NLayer.Dto.Responses.Galaxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Business.Concretes
{
    public class GalaxyManager : IGalaxyService
    {
        public CreatedGalaxyResponse Add(CreateGalaxyRequest createRequest)
        {
            throw new NotImplementedException();
        }

        public DeletedGalaxyResponse Delete(DeleteGalaxyRequest deleteRequest)
        {
            throw new NotImplementedException();
        }

        public GetAllGalaxyResponse Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<GetAllGalaxyResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public UpdatedGalaxyResponse Update(UpdateGalaxyRequest updateRequest)
        {
            throw new NotImplementedException();
        }
    }
}
