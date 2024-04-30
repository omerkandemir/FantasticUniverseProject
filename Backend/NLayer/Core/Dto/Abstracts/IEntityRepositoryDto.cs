using NLayer.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Dto.Abstracts
{
    public interface IEntityRepositoryDto<TAddRequest, TUpdateRequest, TDeleteRequest, TResponse>
        where TAddRequest : class, ICreateRequest, new()
        where TUpdateRequest : class, IUpdateRequest, new()
        where TDeleteRequest : class, IDeleteRequest, new()
        where TResponse : class, IGetResponse, new()
    {
        ICreatedResponse Add(TAddRequest request);
        IUpdatedResponse Update(TUpdateRequest request);
        IDeletedResponse Delete(TDeleteRequest request);
        List<TResponse> GetAll();
        IGetResponse Get(object id);
    }
}
