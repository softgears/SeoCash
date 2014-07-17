namespace SeoCash.Web.Classes.Notifications.UI
{
    /// <summary>
    /// ������� � ����� �����������
    /// </summary>
    public class UINotificationItem
    {
        /// <summary>
        /// ��� �������� �����������: ������, �����, ��������������
        /// </summary>
        public NotificationItemType ItemType { get; set; }

        /// <summary>
        /// ��������� �����������
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// ����������� �� ���������
        /// </summary>
        /// <param name="itemType">��� �����������</param>
        /// <param name="message">���������</param>
        public UINotificationItem(NotificationItemType itemType, string message)
        {
            ItemType = itemType;
            Message = message;
        }
    }
}