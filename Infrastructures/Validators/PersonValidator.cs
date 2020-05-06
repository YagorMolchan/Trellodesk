using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrelloDesk.Models.ViewModels;

namespace TrelloDesk.Infrastructures.Validators
{
    public class PersonValidator:AbstractValidator<PersonViewModel>
    {
        public PersonValidator()
        {
            RuleFor(m => m.Firstname).NotNull().WithName("Имя").WithMessage("Имя обязательно должно быть заполнено!");
            RuleFor(m => m.Secondname).NotNull().WithName("Фамилия").WithMessage("Фамилия обязательно должна быть заполнена!");
        }
    }
}