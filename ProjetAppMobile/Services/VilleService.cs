using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetAppMobile.Services
{
    public interface VilleService<T> 
    {
        Task<bool> AjouterVilleAsync(T ville);
        Task<bool> ModifierVilleAsync(T ville);
        Task<bool> SupprimerVilleAsync(string id);
        Task<T> GetVilleAsync(string id);
        Task<IEnumerable<T>> GetVillesAsync(bool forceRefresh = false);
    }
}
