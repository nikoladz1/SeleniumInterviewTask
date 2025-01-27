# Selenium Automation Task - Booking Flow

This project demonstrates an automated end-to-end booking flow test using Selenium WebDriver, NUnit, and C#. 

---

## Project Structure

### 1. **Pages**

Encapsulates page-specific interactions and behaviors.

- **BasePage**: Provides utility methods (e.g., waiting for visibility, clicking, navigation).
- **AccommodationsPage**: Handles interactions on the accommodations page (e.g., selecting a check-in date, booking).

### 2. **Tests**

- **BaseTest**: Manages WebDriver setup and teardown.
- **BookingTest**: Implements data-driven booking tests with `TestCaseSource`.

---

## Prerequisites

### 1. **Tools and Frameworks**

- .NET 6.0 SDK or higher
- Selenium WebDriver (NuGet: Selenium.WebDrive,Selenium.Supportrt,DotNetSeleniumExtras.WaitHelpers)
- NUnit (NuGet: NUnit,NUnit3TestAdapter,Microsoft.NET.Test.Sdk)
- ChromeDriver (Selenium.WebDriver.ChromeDriver)
  

### 2. **Browser**

- Google Chrome (latest version)

---

### Booking Flow

- Navigate to the accommodations page.
- Decline cookies.
- Select check-in date.
- Choose number of guests.
- Search accommodations.
- Book the first option in the specified accommodation.

---




