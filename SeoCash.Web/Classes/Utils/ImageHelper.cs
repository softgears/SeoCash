// 
// 
// Solution: Forward
// Project: Forward.Web
// File: ImageHelper.cs
// 
// Created by: ykors_000 at 20.02.2014 12:17
// 
// Property of SoftGears
// 
// ========

using System.Web;
using System.Web.Helpers;

namespace SeoCash.Web.Classes.Utils
{
    /// <summary>
    /// Класс помогающий сохранять изображения
    /// </summary>
    public static class ImageHelper
    {
        /// <summary>
        /// Сохраняет файл по указанному пути, преобразуя его в JPEG формат
        /// </summary>
        /// <param name="file">Файл</param>
        /// <param name="fullPath">путь</param>
        public static void SaveAs(HttpPostedFileBase file, string fullPath)
        {
            var webImage = new WebImage(file.InputStream);
            webImage.Save(fullPath, "jpeg");
        }

        /// <summary>
        /// Сохраняет файл по указанному пути, преобразуя его в PNG формат
        /// </summary>
        /// <param name="file">Файл</param>
        /// <param name="fullPath">путь</param>
        public static void SaveAsPng(HttpPostedFileBase file, string fullPath)
        {
            var webImage = new WebImage(file.InputStream);
            webImage.Save(fullPath, "png");
        }
    }
}