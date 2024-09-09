﻿using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repository
{
    public interface IRegionRepository
    {
         Task<List<Region>> GetAllAsync();

         Task<Region?> GetByIdAsync(Guid id);
    }
}
