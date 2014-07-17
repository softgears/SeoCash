using System.Linq;
using System.Web.Mvc;
using SeoCash.Web.Classes.DAL;
using SeoCash.Web.Classes.Enums;
using SeoCash.Web.Classes.IoC;
using SeoCash.Web.Classes.Notifications.UI;
using SeoCash.Web.Controllers;

namespace SeoCash.Web.Classes.Security
{
    /// <summary>
    /// Аспект, валидирующий авторизованность пользователя на выполнение действия
    /// </summary>
    public class AuthorizationCheckAttribute: ActionFilterAttribute
    {
        /// <summary>
        /// Урл, куда происходит редирект если пользователь не авторизован
        /// </summary>
        public string RedirectUrl { get; private set; }

        /// <summary>
        /// Дополнительный пермишен, которым должен обладать пользователь для успешного продолжения авторизация
        /// </summary>
        public long RequiredPermission { get; private set; }

        /// <summary>
        /// Инициализирует новый атрибут, помещающий действие аспектом
        /// </summary>
        /// <param name="requiredPermission">Дополнительное разрешение, которым должен обладать пользователь чтобы пройти авторизацию</param>
        /// <param name="redirectUrl">Урл, куда редиректить неавторизованного пользователя</param>
        public AuthorizationCheckAttribute(long requiredPermission = -1 ,string redirectUrl = "/Dashboard/Login")
        {
            RequiredPermission = requiredPermission;
            RedirectUrl = redirectUrl;
        }

        /// <summary>
        /// Фильтруем действие перед его выполнение
        /// </summary>
        /// <param name="filterContext">Контекст действия</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var currentUser = ((BaseController) filterContext.Controller).CurrentUser;
            if (currentUser == null)
            {
                filterContext.Result = new RedirectResult(this.RedirectUrl);
            } 
            else
            {
                // Проверка того, что пользователь забанен
                if (currentUser.Status == (int)UserStatus.Inactive)
                {
					new UINotificationManager().Error("Вы не активированы, поэтому не можете получить доступ к личному кабинету. Пожалуйста, свяжитесь с вашей компанией, и попросите уполномоченного сотрудника активировать вас.");
                    filterContext.Result = new RedirectResult("/");
                }
                else if (currentUser.Status == (int)UserStatus.Blocked)
                {
                    new UINotificationManager().Error("Вы были заблокированы администратором, поэтому больше не имеете права пользоваться функциями системы");
                    filterContext.Result = new RedirectResult("/");
                } else if (RequiredPermission != -1 && !currentUser.HasPermission(RequiredPermission))
                {
                    // Проверка того что пользователь имеет требуемые разрешения
                    var permission = Locator.GetService<SeoCashDataContext>().Permissions.FirstOrDefault(p => p.Id == RequiredPermission);
					new UINotificationManager().Error(string.Format("Отсутствует необходимая привелегия ({0}) для доступа к указанному разделу", permission.Name));
                    filterContext.Result = new RedirectResult(this.RedirectUrl);    
                }
                else
                {
                    base.OnActionExecuting(filterContext);        
                }
            }
        }
    }
}