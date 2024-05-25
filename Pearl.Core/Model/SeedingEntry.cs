using System.ComponentModel.DataAnnotations.Schema;


namespace Pearl.Core.Model
{
    [Table("__SeedingHistory", Schema = "dbo")]
    public class SeedingEntry
    {
        public string Name { get; set; }
    }
}
