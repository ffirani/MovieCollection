using AutoMapper;
using MovieCollection.API.Dto;
using MovieCollection.Domain.Models;

namespace MovieCollection.API.Mapper
{
    public class CrudMappingProfile:Profile
    {
        public CrudMappingProfile() 
        {
            CreateMap<MovieDto, Movie>();

        } 
    }
}
