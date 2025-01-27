using NUnit.Framework;
using SeleniumInterviewTask.Pages;


namespace SeleniumInterviewTask.Tests
{
    [TestFixture]
    public class BookingTest : BaseTest
    {
        [Test, TestCaseSource(nameof(BookingTestCases))]
        public void BookFirstAccommodation(int checkInDaysFromToday, string numberOfGuests, int accommodationIndex)
        {
            new AccommodationsPage(_driver)
                .GetPage()
                .DeclineCookies()
                .SelectCheckInDate(DateTime.Now.AddDays(checkInDaysFromToday))
                .SelectAdultGuestsNumber(numberOfGuests)
                .SearchAccommodation()
                .bookFirstOptionInNthAccommodation(accommodationIndex);

            Assert.That(_driver.Title.Equals("Basket Destination Gotland"));

            Thread.Sleep(10000);

        }


        public static IEnumerable<TestCaseData> BookingTestCases
        {
            get
            {
                yield return new TestCaseData(1, "2", 0).SetName("BookingTest_Tomorrow_2Guests_FirstOption");

            }
        }
    }
}
