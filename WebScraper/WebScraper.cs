using Microsoft.Playwright;
using WebScraping.WebScraper.POMs;

namespace WebScraping.WebScraper
{
    internal class Scraper(string page = "")
    {
        private string _url = page ?? string.Empty;

        public async Task<List<Quote>> Execute()
        {
            if (string.IsNullOrWhiteSpace(_url))
                throw new InvalidOperationException("URL is not set.");

            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true
            });

            var pageHandle = await browser.NewPageAsync();
            await pageHandle.GotoAsync(_url, new PageGotoOptions
            {
                WaitUntil = WaitUntilState.DOMContentLoaded
            });

            return await GetQuotes(pageHandle);
        }

        public void SetUrl(string url)
        {
            _url = url ?? string.Empty;
        }

        private async Task<List<Quote>> GetQuotes(IPage page)
        {
            var quoteBoxes = await page.QuerySelectorAllAsync(QuotesPage.QuoteBoxes);
            var quotes = new List<Quote>(quoteBoxes.Count);

            foreach (var quoteBox in quoteBoxes)
            {
                string quoteText = await GetRequiredInnerText(quoteBox, QuotesPage.QuoteText);
                string author = await GetRequiredInnerText(quoteBox, QuotesPage.QuoteAuthor);
                string authorAboutLink = await GetAuthorAboutLink(quoteBox);
                string[] tags = await GetQuoteTags(quoteBox);

                quotes.Add(new Quote(quoteText, author, authorAboutLink, tags));
            }

            return quotes;
        }

        private async Task<string> GetRequiredInnerText(IElementHandle scope, string selector)
        {
            var element = await scope.QuerySelectorAsync(selector)
                ?? throw new InvalidOperationException($"Required element not found for selector: {selector}");

            string text = await element.InnerTextAsync();

            if (string.IsNullOrWhiteSpace(text))
                throw new InvalidOperationException($"Element text was empty for selector: {selector}");

            return text.Trim();
        }

        private async Task<string> GetAuthorAboutLink(IElementHandle quoteBox)
        {
            var linkElement = await quoteBox.QuerySelectorAsync(QuotesPage.QuoteAuthorAboutLink);
            if (linkElement == null)
                return string.Empty;

            string? href = await linkElement.GetAttributeAsync("href");
            if (string.IsNullOrWhiteSpace(href))
                return string.Empty;

            return Uri.TryCreate(new Uri(_url), href, out Uri? absoluteUri)
                ? absoluteUri.ToString()
                : href;
        }

        private async Task<string[]> GetQuoteTags(IElementHandle quoteBox)
        {
            var tagElement = await quoteBox.QuerySelectorAsync(QuotesPage.QuoteTags);
            if (tagElement == null)
                return Array.Empty<string>();

            string? tagContent = await tagElement.GetAttributeAsync("content");
            if (string.IsNullOrWhiteSpace(tagContent))
                return Array.Empty<string>();

            return tagContent.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        }
    }
}
