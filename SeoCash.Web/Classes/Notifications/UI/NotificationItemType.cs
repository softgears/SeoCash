using SeoCash.Web.Classes.Enums;

namespace SeoCash.Web.Classes.Notifications.UI
{
    /// <summary>
    /// ��� �������� �����������
    /// </summary>
    public enum NotificationItemType
    {
        /// <summary>
        /// ��������� �� ������
        /// </summary>
        [EnumDescription("success-notification")]
        Success,

        /// <summary>
        /// ��������� �� ������
        /// </summary>
        [EnumDescription("error-notification")]
        Error,

        /// <summary>
        /// ��������������
        /// </summary>
        [EnumDescription("warning-notification")]
        Warning
    }
}