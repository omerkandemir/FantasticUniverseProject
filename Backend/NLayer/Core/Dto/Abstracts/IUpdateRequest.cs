﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Dto.Abstracts
{
    public interface IUpdateRequest
    {
        public int Id { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
