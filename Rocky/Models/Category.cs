using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Rocky.Models
{
    public class Category
    {
        //To add to database, go to db context and add there. Then
        //open package manager console and do 'add-migration Add___ToDatabase
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range( 1, int.MaxValue, ErrorMessage ="Display order for category must be greater than 0" )]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
