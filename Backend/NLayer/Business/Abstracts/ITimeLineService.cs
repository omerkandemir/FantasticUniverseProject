using NLayer.Core.Business.Abstract;
using NLayer.Dto.Requests.TimeLine;
using NLayer.Dto.Responses.TimeLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Business.Abstracts
{
    public interface ITimeLineService : IEntityServiceRepository<
        CreatedTimeLineResponse, CreateTimeLineRequest,
        UpdatedTimeLineResponse, UpdateTimeLineRequest,
        DeletedTimeLineResponse, DeleteTimeLineRequest,
        GetAllTimeLineResponse>
    {
    }
}
