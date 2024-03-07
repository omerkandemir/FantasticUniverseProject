using NLayer.Core.Dto.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Business.Abstract
{
    public interface IEntityServiceRepository<
        TCreateResponse,TCreateRequest,
        TUpdateResponse,TUpdateRequest,
        TDeleteReponse,TDeleteRequest,
        TGet>
        where TCreateResponse : class, ICreatedResponse, new()
        where TCreateRequest : class, ICreateRequest,new()
        where TUpdateResponse : class, IUpdatedResponse,new()
        where TUpdateRequest : class, IUpdateRequest,new()
        where TDeleteReponse : class, IDeletedResponse,new()
        where TDeleteRequest : class, IDeleteRequest,new()
        where TGet : class, new()
    {
        TCreateResponse Add(TCreateRequest ability);
        TUpdateResponse Update(TUpdateRequest ability);
        TDeleteReponse Delete(TDeleteRequest Ability);
        List<TGet> GetAll();
        TGet Get(int id);
    }
}
