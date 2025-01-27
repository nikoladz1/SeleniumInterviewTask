using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace SeleniumInterviewTask.Pages
{
    public class AccommodationsPage(IWebDriver driver, int timeoutInSeconds = 10) : BasePage(driver, timeoutInSeconds)
    {
        private By btnSearchAccommodation => By.Id("CB_SearchButton");
        private By btnDatePicker => By.Id("Citybreak_trigger_from");
        private By dropDownAdultGuestsNumber => By.Id("cb_numadults1");
        private By btnDeclineCookies => By.Id("declineButton");
        private By divSearchResult => By.Id("cb_js_search_result");
        private By btnNextMonth = By.CssSelector(".cb-ui-datepicker-next");
        private By btnDay = By.CssSelector(".cb-ui-datepicker-calendar td:not(.cb-ui-datepicker-other-month) a");

        public AccommodationsPage GetPage(string url = "https://www2.destinationgotland.se/en/accommodation")
        {
            NavigateTo(url);
            return this;
        }

        public AccommodationsPage DeclineCookies()
        {
            ClickIfVisible(btnDeclineCookies, "Decline Cookies button");
            return this;
        }

        public AccommodationsPage SelectCheckInDate(DateTime targetDate)
        {
            Click(btnDatePicker,"Date Picker");
            
            DateTime today = DateTime.Today;
            int monthDifference = (targetDate.Year - today.Year) * 12 + targetDate.Month - today.Month;

            for (int i = 0; i < monthDifference; i++)
            {
                Click(btnNextMonth, "Next Month button");
            }

            var days = Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(btnDay));
            foreach (var day in days)
                if (day.Text == targetDate.Day.ToString())
                {
                    day.Click();
                    return this;
                }
            
            throw new Exception($"Target date {targetDate.ToShortDateString()} not found in the date picker.");
        }

        public AccommodationsPage SelectAdultGuestsNumber(string guestNumber)
        {
            var dropdown = WaitForElementVisible(dropDownAdultGuestsNumber, "Adult Guests Dropdown");
            new SelectElement(dropdown).SelectByValue(guestNumber);
            return this;
        }

        public AccommodationsPage SearchAccommodation()
        {
            Click(btnSearchAccommodation, "Search Accommodation button");
            WaitForSearchCompletion();
            return this;
        }

        public void bookFirstOptionInNthAccommodation(int accommodationIndex)
        {
            var accommodations = WaitForElementVisible(divSearchResult, "Search Results")
                .FindElements(By.CssSelector(".Citybreak_AccInfoBasic.hproduct"));

            if (accommodationIndex >= accommodations.Count)
                throw new IndexOutOfRangeException($"Accommodation index {accommodationIndex} is out of range. Found {accommodations.Count} accommodations.");

            var selectedAccommodation = accommodations[accommodationIndex];

            var btnBookNow = WaitForChildElementVisible(selectedAccommodation, By.CssSelector("a[id^='res_ptg-']"), "Book Now button");
            btnBookNow.Click();

            var firstBookBtn = WaitForChildElementVisible(selectedAccommodation, By.CssSelector("tbody input[id^='cb_alternative_book']"), "First Book button");
            firstBookBtn.Click();
        }

        private void WaitForSearchCompletion(String url = "https://www2.destinationgotland.se/en/accommodationsearch/search")
        {
            Wait.Until(driver => driver.Url != url);
        }
    }


}
