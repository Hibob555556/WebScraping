# WebScraping - C# Playwright Scraper

## Overview

This project is a C# web scraper built using Microsoft Playwright. It extracts quotes, authors, author links, and tags from <https://quotes.toscrape.com>.

## Features

- Scrapes quote text, author, author profile link, and tags
- Uses Playwright for browser automation
- Uses a simple Page Object Model (POM)
- Exports scraped data to JSON

## Tech Stack

- C#
- .NET
- Microsoft Playwright

## How to Run

1. Install dependencies:

```bash
dotnet build
pwsh bin/Debug/net8.0/playwright.ps1 install
