﻿using BLL.Interface;
using BLL.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Mappers;

namespace BLL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepo _movieRepo;

        public MovieService(IMovieRepo movieRepo)
        {
            _movieRepo = movieRepo;
        }

         public void Create(Movie m)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetAll()
        {
            return _movieRepo.GetAll().Select(item => item.ToBll());
        }

        public Movie GetById(int id)
        {
            return _movieRepo.GetById(id).ToBll();
        }

        public void Update(Movie m)
        {
            throw new NotImplementedException();
        }
    }
}
