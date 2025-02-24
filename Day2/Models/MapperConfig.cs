using AutoMapper;
using Day2.Controllers;
using Day2.VewModel;
using Day2_Institute;

namespace Day2.Models
{
    public class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                //Configuring Employee and EmployeeDTO
                cfg.CreateMap<crsResult, TraineeDetails>()
                     .ForMember(dest => dest.TName, opt => opt.MapFrom(src => src.Trainee.Name))
                     .ForMember(dest => dest.CName, opt => opt.MapFrom(src => src.Course.Name))
                     .ForMember(dest => dest.Degree, opt => opt.MapFrom(src => src.Degree));

                cfg.CreateMap<Instructor, InstructorVM>();
                     
            });

            //Create an Instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
