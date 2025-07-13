// Core\Bultenly.Domain\Entities\Article.cs
using System;
using System.Collections.Generic;

namespace Bultenly.Domain.Entities
{
    public class Article
    {
        public Guid Id { get; set; }
        public Guid ContentSourceId { get; set; }
        public ContentSource ContentSource { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Summary { get; set; }
        public string FullContent { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime ScannedDate { get; set; }
        public List<string> Keywords { get; set; }
        public string Category { get; set; }
    }
}