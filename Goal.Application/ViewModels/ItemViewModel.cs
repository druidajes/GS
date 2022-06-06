using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goal.Application.ViewModels
{
    public class ItemViewModel
    {
        public ItemViewModel()
        {

        }
        public ItemViewModel(Guid itemId, string type, string name, DateTime expiration)
        {
            Id = itemId.ToString();
            Type = type;
            Name = name;
            Expiration = expiration;
        }

        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Type is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Type")]
        public string Type { get; set; } = "";

        [Required(ErrorMessage = "The Expiration is Required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Expiration format invalid")]
        [DisplayName("Expiration")]
        public DateTime Expiration { get; set; }
    }


}
