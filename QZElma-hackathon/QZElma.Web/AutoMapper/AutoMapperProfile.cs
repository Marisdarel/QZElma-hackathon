using AutoMapper;
using QZElma.Server.Models.Database.DBEntities;
using QZElma.Server.Models.DatabaseModels.DMEntities;
using System.Collections.Generic;


namespace QZElma.Web.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                //----- DMEntity To Entity -----
                cfg.CreateMap<DMRoom, Room>()
                    .ForMember(en => en.Quiz, options => options.MapFrom(dm =>
                        Mapper.Map<DMQuiz, Quiz>(dm.Quiz)))
                    .ForMember(en => en.Users, options => options.MapFrom(dm =>
                        Mapper.Map<IEnumerable<DMUser>, IEnumerable<User>>(dm.Users)));

                cfg.CreateMap<DMRoomUserIds, Room>();

                cfg.CreateMap<DMQuiz, Quiz>()
                    .ForMember(en => en.Questions, options => options.MapFrom(dm =>
                        Mapper.Map<IEnumerable<DMMultipleChoiceQuestion>, IEnumerable<MultipleChoiceQuestion>>(dm.Questions)));

                cfg.CreateMap<DMMultipleChoiceQuestion, MultipleChoiceQuestion>();

                cfg.CreateMap<DMUser, User>();
            });
        }
    }
}
