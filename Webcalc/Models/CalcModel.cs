using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;


namespace Webcalc.Models
{
    /// <summary>
    /// Модель для расчета значений
    /// </summary>
    public class CalcModel
    {
        [Required]
        [Display(Name ="Первая переменная")]
        public double x { get; set; }

        [Required]
        public double y { get; set; }

        [Display(Name = "Результат")]
        public double result { get; set; }

        [Required]
        [Display(Name = "Действие")]
        public List<SelectListItem> Reason { get; set; }

        [Required]
        public string actions { get; set; }


    }
}