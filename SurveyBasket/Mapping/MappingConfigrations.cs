namespace SurveyBasket.Mapping
{
    public class MappingConfigrations : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Student, StudentResponse>()
                .Map(des => des.Fullname, src => $"{src.FristName} {src.MiddileName} {src.LastName}");
        }
    }
}
