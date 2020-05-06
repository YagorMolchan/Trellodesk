using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrelloDesk.Models.ViewModels
{
    public class CourseViewModel
    {
        [Required(ErrorMessage ="Укажите название курса!")]
        [Display(Name="Название курса")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Добавьте описание курса!")]
        [Display(Name="Описание курса")]
        public string Description { get; set; }     
    }
}