using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using TrelloDesk.Infrastructures.Validators;

namespace TrelloDesk.Models.ViewModels
{
    [Validator(typeof(PersonValidator))]
    public class PersonViewModel
    {
        public string Firstname { get; set; }

        public string Secondname { get; set; }
    }
}