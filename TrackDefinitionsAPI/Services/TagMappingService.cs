using Microsoft.Extensions.Configuration;

namespace TrackDefinitionsAPI.Services
{
    public class TagMappingService : ITagMappingService
    {
        private readonly Dictionary<string, Type> tagDepartmentMappings = new Dictionary<string, Type>
        {
            { "techno", typeof(EDMDepartment) },
            //{ "trance", typeof(TranceDepartment) },
            //{ "acid", typeof(AcidDepartment) },
        };

        public Type GetDepartmentType(string tag)
        {
            if (tagDepartmentMappings.TryGetValue(tag.ToLower(), out var departmentType))
            {
                return departmentType;
            }
            else
            {
                return typeof(DefaultDepartment);
            }
        }

    }
}
