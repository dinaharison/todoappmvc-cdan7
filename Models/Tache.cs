using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace todoappmvc_cdan7.Models
{
    public class Tache
    {
        private int _id;
        private string _nomUtilisateur;
        private string _nomTache;
        private bool _isDone;

        public Tache(string nomTache, bool isDone, string nomUtilisateur)
        {
            NomTache = nomTache;
            IsDone = isDone;
            NomUtilisateur = nomUtilisateur;
        }

        public Tache(string nomTache, string nomUtilisateur)
        {
            NomTache = nomTache;
            NomUtilisateur = nomUtilisateur;
        }

        public Tache(int id, string nomTache, bool isDone, string nomUtilisateur)
        {
            Id = id;
            NomTache = nomTache;
            IsDone = isDone;
            NomUtilisateur = nomUtilisateur;
        }

        public int Id { get => _id; set => _id = value; }
        public string NomTache { get => _nomTache; set => _nomTache = value; }
        public bool IsDone { get => _isDone; set => _isDone = value; }
        public string NomUtilisateur { get => _nomUtilisateur; set => _nomUtilisateur = value; }
    }
}