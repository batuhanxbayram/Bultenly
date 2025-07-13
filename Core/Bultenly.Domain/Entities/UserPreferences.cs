// Core\Bultenly.Domain\Entities\UserPreferences.cs
using System;
using System.Collections.Generic;

namespace Bultenly.Domain.Entities
{
    public class UserPreferences
    {
        public Guid UserId { get; set; }
        public List<string> PreferredCategories { get; set; }
        public List<string> TrackedKeywords { get; set; }
        public NotificationSettings NotificationSettings { get; set; }
    }

    public class NotificationSettings
    {
        // Bildirim tercihleri detaylarý
    }
}