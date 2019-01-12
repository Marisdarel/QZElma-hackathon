using AutoMapper;


namespace QZElma.Web.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
            });
        }
    }
}
