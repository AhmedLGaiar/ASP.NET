using AutoMapper;
using Day2.Controllers;
using Day2.VewModel;
using Institute;

namespace Day2.Models
{
    public class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<crsResult, TraineeDetails>()
                     .ForMember(dest => dest.TName, opt => opt.MapFrom(src => src.Trainee.Name))
                     .ForMember(dest => dest.CName, opt => opt.MapFrom(src => src.Course.Name))
                     .ForMember(dest => dest.Degree, opt => opt.MapFrom(src => src.Degree));

                cfg.CreateMap<Instructor, InstructorVM>().ReverseMap();

                cfg.CreateMap<Course, CourseVM>().ReverseMap();
      
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
