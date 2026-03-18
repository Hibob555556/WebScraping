namespace WebScraping.WebScraper.POMs
{
    internal static class QuotesPage
    {
        public const string QuoteBoxes = "xpath=//div[@itemtype='http://schema.org/CreativeWork']";
        public const string QuoteText = "xpath=.//span[@itemprop='text']";
        public const string QuoteAuthor = "xpath=.//small[@itemprop='author']";
        public const string QuoteAuthorAboutLink = "xpath=.//a[contains(@href, '/author/')]";
        public const string QuoteTags = "xpath=.//meta[@itemprop='keywords']";
    }
}
