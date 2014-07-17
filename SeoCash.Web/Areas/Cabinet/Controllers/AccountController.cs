using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeoCash.Web.Classes.Entities;
using SeoCash.Web.Classes.Enums;
using SeoCash.Web.Classes.Utils;
using SeoCash.Web.Controllers;

namespace SeoCash.Web.Areas.Cabinet.Controllers
{	
	/// <summary>
	/// Контроллер управления авторизационными процедурами на сайте
	/// </summary>
    public class AccountController : BaseController
    {
		#region Авторизация и выход

		/// <summary>
		/// отображает страницу логина в панель управления
		/// </summary>
		/// <returns></returns>
		public ActionResult Login()
		{
			if (IsAuthentificated)
			{
				return RedirectToAction("Index","Dashboard",new {area = "Cabinet"});
			}

			return View();
		}

		/// <summary>
		/// Обрабатывает авторизацию пользователя в панель управления
		/// </summary>
		/// <param name="email">Email</param>
		/// <param name="password">Пароль</param>
		/// <param name="remember">Запомнить</param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult Login(string email, string password, bool remember)
		{
			// Валидируем что пользоатель есть
			var user = DataContext.Users.FirstOrDefault(u => u.Email.ToLower() == email.ToLower() && u.PasswordHash == PasswordUtils.GenerateMD5PasswordHash(password));
			if (user == null)
			{
				return RedirectToAction("Login");
			}

			// Авторизуем
			AuthorizeUser(user, remember);
			user.LastLogin = DateTime.Now;
			DataContext.SubmitChanges();

			// Идем в личный кабинет
			return RedirectToAction("Index", "Dashboard",new {area = "Cabinet"});
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public ActionResult Logout()
		{
			if (!IsAuthentificated)
			{
				return RedirectToAction("Login");
			}

			CloseAuthorization();

			return RedirectToAction("Login");
		}

		#endregion

		#region Регистрация

		/// <summary>
		/// Проверка email на незанятость
		/// </summary>
		/// <param name="email">email</param>
		/// <returns></returns>
		public ActionResult Check(string email)
		{
			if (string.IsNullOrEmpty(email))
			{
				email = String.Empty;
			}
			var exists = DataContext.Users.Any(u => u.Email.ToLower() == email.ToLower());
			return Content(exists ? "\"Такой email уже используется\"" : "true");
		}

		/// <summary>
		/// Проверка email на незанятость
		/// </summary>
		/// <param name="email">email</param>
		/// <returns></returns>
		public ActionResult Check2(string email)
		{
			if (string.IsNullOrEmpty(email))
			{
				email = String.Empty;
			}
			var exists = DataContext.Users.Any(u => u.Email.ToLower() == email.ToLower());
			return Content(!exists ? "\"Такой email не найден\"" : "true");
		}

		/// <summary>
		/// Обработка регистрации пользователя
		/// </summary>
		/// <param name="email">Email</param>
		/// <param name="password">Пароль</param>
		/// <param name="password1">Подтверждение пароля</param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult Register(string email, string password, string password1)
		{
			// Ищем пользователя с таким же Email
			var exists = DataContext.Users.Any(u => u.Email.ToLower() == email.ToLower());
			if (exists)
			{
				return RedirectToAction("Login");
			}

			// Создаем нового пользователя
			var user = new User()
			{
				DateRegistred = DateTime.Now,
				Email = email,
				PasswordHash = PasswordUtils.GenerateMD5PasswordHash(password),
				RoleId = 1,
				Status = (short) UserStatus.Active,
			};
			DataContext.Users.InsertOnSubmit(user);
			DataContext.SubmitChanges();

			// TODO: отправить регистрационное письмо

			// Успешно зарегистрировались, перенаправляемся на профиль
			return RedirectToAction("Profile");
		}

		#endregion
    }
}
