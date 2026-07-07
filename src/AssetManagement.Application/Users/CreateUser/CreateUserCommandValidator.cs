//using FluentValidation;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace AssetManagement.Application.Users.CreateUser;

//public sealed class CreateUserCommandValidator
//    : AbstractValidator<CreateUserCommand>
//{
//    public CreateUserCommandValidator()
//    {
//        RuleFor(c => c.FirstName)
//            .NotEmpty();

//        RuleFor(c => c.LastName)
//            .NotEmpty();

//        RuleFor(c => c.Email)
//            .NotEmpty();
//    }
//}