using AutoMapper;
using StudentCRUD.Models.Entities;
using StudentCRUD.Models.ViewModels;

namespace StudentCRUD.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Student, StudentCreateVM>().ReverseMap();
        CreateMap<Student, StudentUpdateVM>().ReverseMap();
    }
}