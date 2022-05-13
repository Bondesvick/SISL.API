using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SISL.Core.Entities;
using SISL.Core.Interfaces;

namespace SISL.Core.Services
{
    public class SislHistoryRepository : ISislHistoryRepository
    {
        private readonly IRepository<SislHistory> _repository;

        public SislHistoryRepository(IRepository<SislHistory> repository)
        {
            _repository = repository;
        }

        public async Task Add(SislHistory entity)
        {
            await _repository.Add(entity);
        }
    }
}