// 
// 
// Solution: SeoCash
// Project: SeoCash.Web
// File: User.cs
// 
// Created by: ykors_000 at 17.07.2014 15:51
// 
// Property of SoftGears
// 
// ========

using System;
using System.Linq;
using SeoCash.Web.Classes.Utils;

namespace SeoCash.Web.Classes.Entities
{
	/// <summary>
	/// Авторизованный пользователь системы
	/// </summary>
	public partial class User
	{
		/// <summary>
		/// Проверяет, есть ли у пользователя указанное разрешение
		/// </summary>
		/// <param name="requiredPermission"></param>
		/// <returns></returns>
		public bool HasPermission(long requiredPermission)
		{
			return Role.RolePermissions.Any(rp => rp.PermissionId == requiredPermission);
		}

		/// <summary>
		/// Возвращает аватар пользователя или его картринку с Gravatar
		/// </summary>
		/// <returns></returns>
		public string GetPicture()
		{
			return String.Format("http://www.gravatar.com/avatar/{0}?d=monsterid", PasswordUtils.GenerateMD5PasswordHash(Email.Trim().ToLower()).ToLower());
		}
	}
}