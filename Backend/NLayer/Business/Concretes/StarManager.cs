﻿using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.Star;
using NLayer.Dto.Responses.Star;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Business.Concretes
{
    public class StarManager : IStarService
    {
        public CreatedStarResponse Add(CreateStarRequest createRequest)
        {
            throw new NotImplementedException();
        }

        public DeletedStarResponse Delete(DeleteStarRequest deleteRequest)
        {
            throw new NotImplementedException();
        }

        public GetAllStarResponse Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<GetAllStarResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public UpdatedStarResponse Update(UpdateStarRequest updateRequest)
        {
            throw new NotImplementedException();
        }
    }
}