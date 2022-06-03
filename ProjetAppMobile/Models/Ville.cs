using System;

namespace ProjetAppMobile.Models
{
    public class Ville
    {
        public string Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string CodePostal { get; set; }
        public Pays PaysVille { get; set; }
    }
}
