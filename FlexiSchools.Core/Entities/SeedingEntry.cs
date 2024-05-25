using System.ComponentModel.DataAnnotations.Schema;


namespace FlexiSchools.Core.Entities
{
    [Table("__SeedingHistory", Schema = "dbo")]
    public class SeedingEntry
    {
        public string Name { get; set; }
    }
}
