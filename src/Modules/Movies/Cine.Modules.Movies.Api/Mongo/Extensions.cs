using System;
using System.Linq;
using Cine.Modules.Movies.Api.DTO;
using Cine.Modules.Movies.Api.Mongo.Documents;

namespace Cine.Modules.Movies.Api.Mongo
{
    public static class Extensions
    {
        public static MovieDto AsDto(this MovieDocument document)
            => new MovieDto
            {
                Id = document.Id,
                Title = document.Title,
                Description = document.Description,
                Length = document.Length,
                PremiereDate = document.PremiereDate,
                Genres = document.Genres.ToString().Split(','),
                Director = new PersonDto
                {
                    FirstName = document.Director.FirstName,
                    LastName = document.Director.LastName
                },
                Stars = document.Stars.Select(s => new PersonDto
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName
                })
            };

        public static MovieDocument AsDocument(this MovieDto dto)
            => new MovieDocument
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                Length = dto.Length,
                PremiereDate = dto.PremiereDate,
                Genres = Enum.Parse<Genre>(string.Concat(dto.Genres)),
                Director = new PersonDocument
                {
                    FirstName = dto.Director.FirstName,
                    LastName = dto.Director.LastName
                },
                Stars = dto.Stars.Select(s => new PersonDocument
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName
                })
            };
    }
}