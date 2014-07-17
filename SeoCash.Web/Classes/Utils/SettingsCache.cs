// 
// 
// Solution: OFFT
// Project: OFFT.Web
// File: SettingsCache.cs
// 
// Created by: ykors_000 at 02.07.2014 10:30
// 
// Property of SoftGears
// 
// ========

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using SeoCash.Web.Classes.DAL;
using SeoCash.Web.Classes.IoC;

namespace SeoCash.Web.Classes.Utils
{
	/// <summary>
	/// Кеширующий класс для настроек
	/// </summary>
	public class SettingsCache
	{
		/// <summary>
		/// Внутренний кеш
		/// </summary>
		private Dictionary<string,string>  InnerCache { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:System.Object"/> class.
		/// </summary>
		public SettingsCache()
		{
			// Заполняем изначальными настройками
			using (var scope = Locator.BeginNestedHttpRequestScope())
			{
				var dc = Locator.GetService<SeoCashDataContext>();

				InnerCache = dc.Settings.ToDictionary(s => s.Key, s => s.Value);
			}
		}

		/// <summary>
		/// Получает настройку в виде строки
		/// </summary>
		/// <param name="name">Имя-ключ настройки</param>
		/// <returns></returns>
		public string GetValue(string name)
		{
			if (!InnerCache.ContainsKey(name))
			{
				return String.Empty;
			}
			return InnerCache[name];
		}

		/// <summary>
		/// Получает настройку, конвертирую ее в указанный тип
		/// </summary>
		/// <typeparam name="T">Тип настройки, к которому конвертировать</typeparam>
		/// <param name="name">Имя-ключ настройки</param>
		/// <returns></returns>
		public T GetValue<T>(string name)
		{
			string val = GetValue(name);
			var converter = TypeDescriptor.GetConverter(typeof(T));
			return (T)converter.ConvertFrom(val);
		}

		/// <summary>
		/// Обновляет новое значение настройки
		/// </summary>
		/// <param name="name">Ключ настройки</param>
		/// <param name="newValue">Новое значение</param>
		public void UpdateValue(string name, string newValue)
		{
			if (InnerCache.ContainsKey(name))
			{
				lock (InnerCache)
				{
					InnerCache[name] = newValue;	
				}
			}
		}
	}
}