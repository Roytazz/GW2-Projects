namespace GuildWars2.Web.Classes
{
    public class Notification
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public NotificationType Type { get; set; }
    }

    public enum NotificationType
    {
        Succes,
        Warning,
        Error
    }
}
