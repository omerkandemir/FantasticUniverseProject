﻿using NLayer.Core.Dto.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Dto.Responses.AdventureCharacter
{
    public class UpdatedAdventureCharacterResponse : IUpdatedResponse
    {
        public int Id { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int AdventureId { get; set; }
        public int CharacterId { get; set; }
    }
}
