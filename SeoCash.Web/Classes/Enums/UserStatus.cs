// 
// 
// Solution: CityTimer
// Project: CityTimer.Domain
// File: UserStatus.cs
// 
// Created by: ykors_000 at 15.07.2014 14:09
// 
// Property of SoftGears
// 
// ========

namespace SeoCash.Web.Classes.Enums
{
	/// <summary>
	/// Статус пользователя
	/// </summary>
	public enum UserStatus: short
	{	
		/// <summary>
		/// Пользователь активен
		/// </summary>
		[EnumDescription("Активен")]
		Active = 1,

		/// <summary>
		/// Пользователь заблокирован
		/// </summary>
		[EnumDescription("Заблокирован")]
		Blocked = 2,

		/// <summary>
		/// Пользователь неактивен
		/// </summary>
		[EnumDescription("Пользователь неактивен")]
		Inactive = 3
	}
}