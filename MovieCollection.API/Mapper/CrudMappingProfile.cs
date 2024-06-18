using AutoMapper;
using MovieCollection.API.Commands.Dto;
using MovieCollection.Domain.Models;

namespace MovieCollection.API.Mapper
{
    public class CrudMappingProfile:Profile
    {
        public CrudMappingProfile() 
        {
            CreateMap<MovieDto, Movie>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<MovieSelectionDto, MovieSelection>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PersonDto, Person>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<GenreDto, Genre>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<MovieRoleDto, MovieRole>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<CastAndCrewDto, CastAndCrew>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        } 
    }
}
