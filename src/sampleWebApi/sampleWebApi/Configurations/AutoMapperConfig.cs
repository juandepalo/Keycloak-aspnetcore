using AutoMapper;


namespace sampleWebApi.Configurations
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;

            });
        }
    }
}