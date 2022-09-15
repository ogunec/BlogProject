using BlogPro.MODEL.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPro.MODEL.FluentValidators
{
	public class AuthorValidator : AbstractValidator<Author>
	{
		public AuthorValidator()
		{
			RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Yazar Adı alanı boş bırakılamaz!");
			RuleFor(x => x.AuthorImage).NotEmpty().WithMessage("Resim alanı boş bırakılamaz!");
			RuleFor(x => x.AuthorDetail).NotEmpty().WithMessage("Yazar Hakkında alanı boş bırakılamaz!");
			RuleFor(x => x.AboutShort).NotEmpty().WithMessage("İlgi Alanları alanı boş bırakılamaz!");
			RuleFor(x => x.AuthorMail).NotEmpty().WithMessage("Mail alanı boş bırakılamaz!");
			RuleFor(x => x.AuthorTitle).NotEmpty().WithMessage("Görev alanı boş bırakılamaz!");
			RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş bırakılamaz!");
			RuleFor(x => x.Role).NotEmpty().WithMessage("Rol alanı boş bırakılamaz!");
			RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon alanı boş bırakılamaz!");
		}
	}
}
