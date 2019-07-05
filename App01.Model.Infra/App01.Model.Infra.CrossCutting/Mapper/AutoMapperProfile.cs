using App01.Model.Domain.Entities;
using App01.Model.Infra.CrossCutting.Features.UserFeatures;
using AutoMapper;

namespace App01.Model.Infra.CrossCutting.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();
        }
    }
}