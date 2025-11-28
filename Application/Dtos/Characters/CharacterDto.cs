using System;

namespace Application.Dtos.Characters
{
    public struct CharacterDto
    {
        public Guid CharacterId { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
    }
}

