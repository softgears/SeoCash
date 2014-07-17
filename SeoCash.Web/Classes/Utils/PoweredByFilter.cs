// 
// 
// Solution: DeliveryPlus
// Project: DeliveryPlus.Web
// File: PowerebByFilter.cs
// 
// Created by: ykors_000 at 06.02.2014 11:38
// 
// Property of SoftGears
// 
// ========

using System.Web.Mvc;

namespace SeoCash.Web.Classes.Utils
{
    /// <summary>
    /// Фильтр MVC
    /// </summary>
    public class PoweredByFilter: ActionFilterAttribute
    {
        /// <summary>
        /// Called by the ASP.NET MVC framework before the action method executes.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Добавляем копирайт в заголовки ответа
            filterContext.RequestContext.HttpContext.Response.AddHeader("X-Powered-by", "SoftGears Engine v1.7");
            filterContext.RequestContext.HttpContext.Response.AddHeader("X-Programmed-by", "Yuri Korshev");
            filterContext.RequestContext.HttpContext.Response.AddHeader("X-Vendor", "SoftGears");
            filterContext.RequestContext.HttpContext.Response.AddHeader("X-Vendor-url", "http://softgears.ru");
            base.OnActionExecuting(filterContext);
        }
    }
}