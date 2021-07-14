using Domain.Common;

namespace Domain.Entities
{
    public class Brand : CommonEntity
    {
        public string Name { get; set; }
        public string LogoPath { get; set; }
        public int SlNo { get; set; }
    }
}
