// Core\Bultenly.Domain\Entities\Notification.cs
using System;

namespace Bultenly.Domain.Entities
{
    public class Notification
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid? ArticleId { get; set; }
        public Article Article { get; set; }
        public MessageType MessageType { get; set; }
        public string Content { get; set; }
        public DateTime? SentDate { get; set; }
        public bool IsRead { get; set; }
    }

    public enum MessageType
    {
        NewArticle,
        KeywordMatch,
        SystemMessage
    }
}