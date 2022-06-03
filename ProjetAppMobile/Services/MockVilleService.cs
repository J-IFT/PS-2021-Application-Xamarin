using ProjetAppMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetAppMobile.Services
{
    public class MockVilleService : VilleService<Ville>
    {
        readonly List<Ville> villes;

        public MockVilleService()
        {
            villes = new List<Ville>()
            {
                new Ville { Id = Guid.NewGuid().ToString(), Nom = "Grenoble", Description="Ville de la région Rhône-Alpes du sud-est de la France, se trouve au pied des montagnes entre le Drac et l'Isère."},
                new Ville { Id = Guid.NewGuid().ToString(), Nom = "Paris", Description="Capitale de la France, c'est une grande ville européenne et un centre mondial de l'art, de la mode, de la gastronomie et de la culture." },
                new Ville { Id = Guid.NewGuid().ToString(), Nom = "Lyon", Description="Ville française de la région historique Rhône-Alpes, se trouve à la jonction du Rhône et de la Saône." },
                new Ville { Id = Guid.NewGuid().ToString(), Nom = "Madrid", Description="Située au centre de l'Espagne, Madrid, sa capitale, est une ville dotée d'élégants boulevards et de vastes parcs très bien entretenus comme le Retiro." },
                new Ville { Id = Guid.NewGuid().ToString(), Nom = "Londres", Description="La capitale de l'Angleterre et du Royaume-Uni, est une ville moderne dont l'histoire remonte à l'époque romaine." }
            };
        }

        public async Task<bool> AjouterVilleAsync(Ville ville)
        {
            villes.Add(ville);

            return await Task.FromResult(true);
        }

        public async Task<bool> ModifierVilleAsync(Ville ville)
        {
            var oldVille = villes.Where((Ville arg) => arg.Id == ville.Id).FirstOrDefault();
            villes.Remove(oldVille);
            villes.Add(ville);

            return await Task.FromResult(true);
        }

        public async Task<bool> SupprimerVilleAsync(string id)
        {
            var oldVille = villes.Where((Ville arg) => arg.Id == id).FirstOrDefault();
            villes.Remove(oldVille);

            return await Task.FromResult(true);
        }

        public async Task<Ville> GetVilleAsync(string id)
        {
            return await Task.FromResult(villes.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Ville>> GetVillesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(villes);
        }
    }
}
