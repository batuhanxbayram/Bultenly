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
        public List<Guid> SelectedContentSourceIds { get; private set; }


        public void UpdatePreferredCategories(List<string> categories)
        {
            PreferredCategories = categories ?? new List<string>();
        }

        public void UpdateTrackedKeywords(List<string> keywords)
        {
            TrackedKeywords = keywords ?? new List<string>();
        } 

        public void UpdateSelectedSources(List<Guid> sourceIds) 
        {
            SelectedContentSourceIds = sourceIds ?? new List<Guid>();
        }


    }

    public class NotificationSettings
    {
        
    }
}