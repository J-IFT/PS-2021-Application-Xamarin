using System.Text;
using ProjetAppMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetAppMobile.Services
{
    public class PaysMockDataStore : PaysIDataStore<Pays>
    {
        readonly List<Pays> payss;

        public PaysMockDataStore()
        {
            payss = new List<Pays>()
            {
                new Pays { Id = Guid.NewGuid().ToString(), Descrpt = "Pays :", Name ="France" },
                new Pays { Id = Guid.NewGuid().ToString(), Descrpt = "Pays :", Name ="Angleterre" },
                new Pays { Id = Guid.NewGuid().ToString(), Descrpt = "Pays :", Name ="Espagne" }
            };
        }

        public async Task<bool> AddPaysAsync(Pays pays)
        {
            payss.Add(pays);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdatePaysAsync(Pays pays)
        {
            var oldPays = payss.Where((Pays arg) => arg.Id == pays.Id).FirstOrDefault();
            payss.Remove(oldPays);
            payss.Add(pays);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeletePaysAsync(string id)
        {
            var oldPays = payss.Where((Pays arg) => arg.Id == id).FirstOrDefault();
            payss.Remove(oldPays);

            return await Task.FromResult(true);
        }

        public async Task<Pays> GetPaysAsync(string id)
        {
            return await Task.FromResult(payss.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Pays>> GetAllPaysAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(payss);
        }
    }
}

