using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class History
    {
        public virtual Guid Id { get; set; }

        [Required]
        [Display(Name = "X")]
        public virtual double X { get; set; }

        [Required]
        [Display(Name = "Y")]
        public virtual double Y { get; set; }

        [Display(Name = "Result")]
        public virtual double Result { get; set; }

        [Display(Name = "Operations")]
        public virtual string Operation { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата создание")]
        public virtual DateTime CreationDate { get; set; }

    }
}
