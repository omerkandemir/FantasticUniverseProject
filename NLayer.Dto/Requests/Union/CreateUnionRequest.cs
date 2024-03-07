﻿using NLayer.Core.Dto.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Dto.Requests.Union
{
    public class CreateUnionRequest : ICreateRequest
    {
        public string Name { get; set; }
        public string Target { get; set; }
        public int? UnionLeaderId { get; set; }
        public int UniverseId { get; set; }

    }
}