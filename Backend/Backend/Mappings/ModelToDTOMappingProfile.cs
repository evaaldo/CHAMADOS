using AutoMapper;
using Backend.DTOs;
using Backend.Models;

namespace Backend.Mappings
{
    public class ModelToDTOMappingProfile : Profile
    {
        public ModelToDTOMappingProfile() 
        {
            CreateMap<Costumer, CostumerDTO>().ReverseMap();
        }
    }
}
