using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Bultenly.Domain.Entities
{
    public class User:IdentityUser<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string FirstName { get; set; }
        public string LastName { get; set; }
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
