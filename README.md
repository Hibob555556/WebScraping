# WebScraping

A C# web scraping project built with Microsoft Playwright that extracts quotes, authors, author profile links, and tags from <https://quotes.toscrape.com/>, then saves the results to a JSON file.

## Overview

This project launches a headless Chromium browser with Playwright, navigates to the target page, collects quote data, prints the results to the console, and exports the scraped data to `scraped_quotes.json`.

It demonstrates:

- Playwright browser automation
- asynchronous programming with `async/await`
- structured scraping with a Page Object Model
- JSON serialization in C#

## Features

- Scrapes:
  - quote text
  - author name
  - author profile link
  - quote tags
- Uses Playwright with headless Chromium
- Uses a simple Page Object Model for selectors
- Serializes scraped results to formatted JSON
- Prints scraped data to the console

## Tech Stack

- C#
- .NET 10
- Microsoft Playwright

## Project Structure

```
WebScraping/
├── Program.cs
├── WebScraping.csproj
├── WebScraping.sln
├── scraped_quotes.json
└── WebScraper/
    ├── Quote.cs
    ├── WebScraper.cs
    └── POMs/
        └── QuotesPage.cs
```

## How It Works

1. The app creates a scraper instance with the target URL.
2. Playwright launches a headless Chromium browser.
3. The scraper navigates to the page and waits for the DOM to load.
4. Quote containers are collected from the page.
5. Each quote is parsed into a Quote object.
6. The results are printed to the console.
7. The dataset is saved to `scraped_quotes.json`.

## Getting Started

### Prerequisites

- .NET 10 SDK
- PowerShell
- Internet connection

### Installation

```bash
git clone https://github.com/Hibob555556/WebScraping.git
cd WebScraping
dotnet restore
dotnet build
pwsh bin/Debug/net10.0/playwright.ps1 install
```

## Running the Project

```bash
dotnet run
```

## Output

When the scraper runs:

- prints quotes to the console
- creates `scraped_quotes.json`

Example:

```json
[
  {
    "QuoteText": "The world as we have created it is a process of our thinking.",
    "Author": "Albert Einstein",
    "AuthorAboutLink": "https://quotes.toscrape.com/author/Albert-Einstein",
    "Tags": ["change", "deep-thoughts", "thinking", "world"]
  }
]
```

## Code Highlights

- Program.cs: entry point and output handling  
- WebScraper.cs: browser automation and scraping logic  
- Quote.cs: data model  
- QuotesPage.cs: selectors (Page Object Model)  

## Notes

Targets <https://quotes.toscrape.com/>.  
Selectors may need updating if the site changes.

## Future Improvements

- CLI arguments for custom URLs
- pagination support
- CSV export
- improved error handling and logging

## Author

Cayden Lunt  
<https://github.com/Hibob555556>  
<https://www.linkedin.com/in/cayden-lunt-test-engineer>
