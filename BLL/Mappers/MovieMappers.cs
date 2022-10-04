using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLLM = BLL.Models;
using DALM = DAL.Models;

namespace BLL.Mappers
{
    public static class MovieMappers
    {
        public static BLLM.Movie ToBll(this DALM.Movie movie)
        {
            return new BLLM.Movie
            {
                Id = movie.Id,
                Title = movie.Title,
                Synopsis = movie.Synopsis,
                PEGI = movie.PEGI,
                ReleaseYear = movie.ReleaseYear
            };
        }
    }
}
