using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.TimeLine;
using NLayer.Dto.Responses.TimeLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Business.Concretes
{
    public class TimeLineManager : ITimeLineService
    {
        public CreatedTimeLineResponse Add(CreateTimeLineRequest createRequest)
        {
            throw new NotImplementedException();
        }

        public DeletedTimeLineResponse Delete(DeleteTimeLineRequest deleteRequest)
        {
            throw new NotImplementedException();
        }

        public GetAllTimeLineResponse Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<GetAllTimeLineResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public UpdatedTimeLineResponse Update(UpdateTimeLineRequest updateRequest)
        {
            throw new NotImplementedException();
        }
    }
}
