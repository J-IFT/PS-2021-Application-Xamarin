using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetAppMobile.Services
{
    public interface PaysIDataStore<T>
    {
        Task<bool> AddPaysAsync(T pays);
        Task<bool> UpdatePaysAsync(T pays);
        Task<bool> DeletePaysAsync(string id);
        Task<T> GetPaysAsync(string id);
        Task<IEnumerable<T>> GetAllPaysAsync(bool forceRefresh = false);
    }
}