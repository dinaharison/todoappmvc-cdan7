using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace todoappmvc_cdan7.Models
{
    public class Utilisateur
    {
        private string _nomUtilisateur;
        private string _motDePasse;

        public Utilisateur()
        {
        }
        public Utilisateur(string nomUtilisateur, string motDePasse)
        {
            NomUtilisateur = nomUtilisateur;
            MotDePasse = motDePasse;
        }
        public string NomUtilisateur { get => _nomUtilisateur; set => _nomUtilisateur = value; }
        public string MotDePasse { get => _motDePasse; set => _motDePasse = value; }
    }
}