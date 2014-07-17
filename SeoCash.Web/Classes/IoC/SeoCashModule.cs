// 
// 
// Solution: SeoCash
// Project: SeoCash.Web
// File: SeoCashModule.cs
// 
// Created by: ykors_000 at 17.07.2014 15:39
// 
// Property of SoftGears
// 
// ========

using Autofac;
using SeoCash.Web.Classes.DAL;
using SeoCash.Web.Classes.Utils;

namespace SeoCash.Web.Classes.IoC
{
	/// <summary>
	/// Модуль зависимостей 
	/// </summary>
	public class SeoCashModule: Autofac.Module
	{
		/// <summary>
		/// Override to add registrations to the container.
		/// </summary>
		/// <remarks>
		/// Note that the ContainerBuilder parameter is unique to this module.
		/// </remarks>
		/// <param name="builder">The builder through which components can be
		///             registered.</param>
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<SeoCashDataContext>().AsSelf().InstancePerRequest();
			builder.RegisterType<SettingsCache>().AsSelf().SingleInstance();
		}
	}
}