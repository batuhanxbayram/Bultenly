// Core\Bultenly.Domain\Entities\ContentSource.cs
using System;
using System.Collections.Generic;

namespace Bultenly.Domain.Entities
{
    public class ContentSource
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public ContentType ContentType { get; set; }
        public DateTime? LastScannedAt { get; set; }
        public bool IsActive { get; set; }
        public string Category { get; set; }

        public ICollection<Article> Articles { get; set; }
    }

    public enum ContentType
    {
        RssFeed,
        WebsiteScrape,
        Api
    }
}