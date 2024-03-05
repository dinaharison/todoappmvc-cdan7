using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace todoappmvc_cdan7.Models
{
    public static class DBConnection
    {
        public static readonly NpgsqlConnection connectionString = new NpgsqlConnection(
                ConfigurationManager.ConnectionStrings["tacheDBConnection"].ConnectionString
            );
        public static bool IsUserInDB(Utilisateur user)
        {
            var req = $"Select * from public.\"User\" where " +
                $"username = '{user.NomUtilisateur}' and " +
                $"password='{user.MotDePasse}'";
            connectionString.Open();

            var cmd = new NpgsqlCommand(req, connectionString);
            NpgsqlDataReader dataReader = cmd.ExecuteReader();

            var isUserThere = dataReader.HasRows;

            connectionString.Close();

            return isUserThere;
        }

        public static void InsertUser(Utilisateur user)
        {
            var req = $"insert into public.\"User\"(username,password) values('{user.NomUtilisateur}','{user.MotDePasse}')";
            ExecuteQuerry(req);
        }

        public static List<Tache> GetTaches(string username)
        {
            List<Tache> taches = new List<Tache>();

            var req = $"select * from public.\"Tache\" where username = '{username}' group by tacheid";
            connectionString.Open();

            var cmd = new NpgsqlCommand(req, connectionString);
            var dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                taches.Add(new Tache(
                        dataReader.GetInt32(0),
                        dataReader.GetString(2),
                        dataReader.GetBoolean(3),
                        dataReader.GetString(1)

                        ));
            }
            connectionString.Close();

            return taches;
        }

        public static void InsertTache(Tache tache)
        {
            var req = $"insert into public.\"Tache\"(username, description) " +
                $"values('{tache.NomUtilisateur}','{tache.NomTache}')";
            ExecuteQuerry(req);
        }

        public static void ModifierTache(Tache tache)
        {
            var req = $"Update public.\"Tache\" set state={tache.IsDone}, description='{tache.NomTache}' where tacheid={tache.Id}";
            ExecuteQuerry(req);
        }

        public static void SupprimerTache(int id)
        {
            var req = $"delete from public.\"Tache\" where tacheid={id}";
            ExecuteQuerry(req);
        }

        private static void ExecuteQuerry(string req)
        {
            connectionString.Open();
            var cmd = new NpgsqlCommand(req, connectionString);
            cmd.ExecuteNonQuery();
            connectionString.Close();
        }
    }
}