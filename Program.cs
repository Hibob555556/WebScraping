using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using WebScraping.WebScraper;

namespace WebScraping
{
    internal static class Program
    {
        private const string DefaultUrl = "https://quotes.toscrape.com/";
        private const string OutputFileName = "scraped_quotes.json";

        public static async Task Main(string[] args)
        {
            var scraper = new Scraper(DefaultUrl);
            var quotes = await scraper.Execute();

            foreach (var quote in quotes)
            {
                Console.WriteLine($"Quote: {quote.QuoteText}");
                Console.WriteLine($"Author: {quote.Author}");

                if (!string.IsNullOrWhiteSpace(quote.AuthorAboutLink))
                    Console.WriteLine($"About Link: {quote.AuthorAboutLink}");

                Console.WriteLine($"Tags: {string.Join(", ", quote.Tags)}");
                Console.WriteLine();
            }

            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), OutputFileName);
            var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(quotes, jsonOptions);

            await File.WriteAllTextAsync(outputPath, json);
            Console.WriteLine($"Saved {quotes.Count} quotes to {outputPath}");
        }
    }
}
