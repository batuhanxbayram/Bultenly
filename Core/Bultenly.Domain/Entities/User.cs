using System;
using System.Collections.Generic;

namespace Bultenly.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public UserPreferences Preferences { get; set; }
        public bool IsActive { get; set; }
        
        public ICollection<Notification> Notifications { get; set; }
    }
}
