using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SISL.Core.Entities;

namespace SISL.Core.Interfaces
{
    public interface ISislHistoryRepository
    {
        Task Add(SislHistory entity);
    }
}