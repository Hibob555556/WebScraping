namespace WebScraping.WebScraper
{
    internal class Quote
    {
        public string QuoteText { get; }
        public string Author { get; }
        public string AuthorAboutLink { get; }
        public string[] Tags { get; }

        public Quote(string quoteText, string author, string? authorAboutLink, string[]? tags)
        {
            if (string.IsNullOrWhiteSpace(quoteText))
                throw new ArgumentException("Quote text cannot be null or empty.", nameof(quoteText));

            if (string.IsNullOrWhiteSpace(author))
                throw new ArgumentException("Author cannot be null or empty.", nameof(author));

            QuoteText = quoteText.Trim();
            Author = author.Trim();
            AuthorAboutLink = authorAboutLink?.Trim() ?? string.Empty;
            Tags = tags ?? Array.Empty<string>();
        }
    }
}
