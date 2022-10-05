using DAL.Interface;
using DAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class MovieRepo : IMovieRepo
    {
        private string _connectionString;

        public MovieRepo(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("default");
        }

        protected Movie Converter(IDataReader reader)
        {
            return new Movie
            {
                Id = (int)reader["Id"],
                Title = reader["Title"].ToString(),
                Synopsis = reader["Synopsis"].ToString(),
                ReleaseYear = (int)reader["ReleaseYear"],
                PEGI = (int)reader["PEGI"]
            };
        }

        public void Create(Movie m)
        {
            using(SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Movie (Title, Synopsis, ReleaseYear, PEGI) VALUES(@Title, @Synopsis, @ReleaseYear, @PEGI)";
                    cmd.Parameters.AddWithValue("Title", m.Title);
                    cmd.Parameters.AddWithValue("Synopsis", m.Synopsis);
                    cmd.Parameters.AddWithValue("ReleaseYear", (int) m.ReleaseYear);
                    cmd.Parameters.AddWithValue("PEGI", (int) m.PEGI);

                    cnx.Open();
                    cmd.ExecuteNonQuery();
                    cnx.Close();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Movie WHERE id = @Id";
                    cmd.Parameters.AddWithValue("Id", id);
                    cnx.Open();
                    cmd.ExecuteNonQuery();
                    cnx.Close();
                }
            }
        }

        public IEnumerable<Movie> GetAll()
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Movie";
                    cnx.Open();
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return Converter(reader);
                        }
                    }
                }
            }
        }

        public Movie GetById(int id)
        {
            using(SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Movie WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("Id", id);
                    cnx.Open();
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            throw new NullReferenceException("Movie inexistant");
                        }
                        return Converter(reader);
                    }
                }
            }
        }

        public void Update(Movie m)
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Movie SET Title = @Title, Synopsis = @Synopsis, ReleaseYear = @ReleaseYear, PEGI = @pegi WHERE id = @id";
                    cmd.Parameters.AddWithValue("Title", m.Title);
                    cmd.Parameters.AddWithValue("Synopsis", m.Synopsis);
                    cmd.Parameters.AddWithValue("ReleaseYear", (int)m.ReleaseYear);
                    cmd.Parameters.AddWithValue("PEGI", (int)m.PEGI);
                    cmd.Parameters.AddWithValue("id", (int)m.Id);

                    cnx.Open();
                    cmd.ExecuteNonQuery();
                    cnx.Close();
                }
            }
        }
    }
}
