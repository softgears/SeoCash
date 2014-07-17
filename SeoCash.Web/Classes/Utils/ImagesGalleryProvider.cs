using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SeoCash.Web.Classes.Utils
{
    /// <summary>
    /// Провайдер галлереи изображений хранимых на диске
    /// </summary>
    public class ImagesGalleryProvider
    {
        /// <summary>
        /// Инициализирует новый инстанс 
        /// </summary>
        public ImagesGalleryProvider()
        {
            this.GalleryRootPath = System.Configuration.ConfigurationManager.AppSettings["GalleryRootPath"];
        }

        /// <summary>
        /// Корневой путь к физическому хранилищу корневой папки с галлереями
        /// </summary>
        public string GalleryRootPath { get; private set; }

        /// <summary>
        /// Список разрешенных разрешений файлов для галлереи
        /// </summary>
        public static List<string> AllowedExstensions = new List<string>(){".jpg",".jpeg",".png"}; 

        /// <summary>
        /// Получает все содержимое галереи изображений по указанному урл
        /// </summary>
        /// <param name="galleryUrl">URL галереи</param>
        /// <returns>Коллекция элементов галереи</returns>
        public IEnumerable<ImageGalleryItem> GetGalleryItems(string galleryUrl)
        {
            // Ищем если такая папка на диске
            var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Galleries", galleryUrl);
            if (!Directory.Exists(fullPath))
            {
                throw new Exception(string.Format("Галерея с именем {0} не найдена", galleryUrl));
            }

            // Перебираем содержимое галлереи и сразу отдаем LINQ выражением
            return from file in Directory.GetFiles(fullPath)
                   let ext = Path.GetExtension(file)
                   where AllowedExstensions.Contains(ext.ToLower())
                   select new ImageGalleryItem()
                              {
                                  FileName = Path.GetFileName(file),
                                  GalleryName = galleryUrl,
                                  Title = Path.GetFileNameWithoutExtension(file)
                              };
        }
    }
}