using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using TechTalk.SpecFlow;

namespace MWL.Steps
{
    [Binding]
    public class myTimeOffSteps
    {
        private IWebDriver driver = new ChromeDriver();
        DateTime today = DateTime.Today; // Get today's date

        [Given(@"an employee logs into My Working Life")]
        public void GivenAnEmployeeLogsIntoMyWorkingLife()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://test-myworkinglife.moneypenny.com/Account/Login?ReturnUrl=%2F");
            driver.FindElement(By.Id("UsernameOrEmail")).Click();
            driver.FindElement(By.Id("UsernameOrEmail")).Clear();
            driver.FindElement(By.Id("UsernameOrEmail")).SendKeys("Nadine Davies");
            //driver.FindElement(By.Id("UsernameOrEmail")).SendKeys("Naomi Lloyd");
            // driver.FindElement(By.Id("UsernameOrEmail")).SendKeys("Matthew Regis");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("Myoldpass12!!");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            driver.FindElement(By.Id("MyTimeOff")).Click(); // Click My Time Off btn
        }

        [When(@"the employee goes to the holiday request screen")]
        public void WhenTheEmployeeGoesToTheHolidayRequestScreen()
        {
            driver.FindElement(By.Id("RequestDaysOff")).Click(); // Click Request Day(s) btn
        }

        [When(@"the employee goes to the Lieu request screen")]
        public void WhenTheEmployeeGoesToTheLieuRequestScreen()
        {
            driver.FindElement(By.Id("Lieu")).Click(); // Click Request Day(s) btn
            driver.FindElement(By.Id("RequestLieuDaysOff")).Click(); // Click Request Day(s) btn
        }

        [When(@"the employee goes to the Appointment request screen")]
        public void WhenTheEmployeeGoesToTheAppointmentRequestScreen()
        {
            driver.FindElement(By.Id("Appointment")).Click(); // Click Request Day(s) btn
            driver.FindElement(By.Id("RequestAppointment")).Click(); // Click Request Day(s) btn
        }

        [When(@"selects a day to book off")]
        public void WhenSelectsADayToBookOff()
        {
            DateTime fourthDayOfMonth = new DateTime(today.Year, today.Month, 1).AddMonths(1).AddDays(-4); // Date of the fourth day before the end of the month
            int fourthDayOfMonthInt = (int)fourthDayOfMonth.DayOfWeek; // Get the day of the week for fourthDayOfMonth

            DateTime thirdDayOfMonth = new DateTime(today.Year, today.Month, 1).AddMonths(1).AddDays(-3); // Date of the third day before the end of the month
            int thirdDayOfMonthInt = (int)thirdDayOfMonth.DayOfWeek; // Get the day of the week for thirdDayOfMonth	

            DateTime secondDayOfMonth = new DateTime(today.Year, today.Month, 1).AddMonths(1).AddDays(-2); // Date of the second day before the end of the month
            int secondDayOfMonthInt = (int)secondDayOfMonth.DayOfWeek; // Get the day of the week for secondDayOfMonth

            DateTime lastDayOfMonth = new DateTime(today.Year, today.Month, 1).AddMonths(1).AddDays(-1); // Date of the last day before the end of the month
            int lastDayOfMonthInt = (int)lastDayOfMonth.DayOfWeek; // Get the day of the week for lastDayOfMonth

            int todaysDayInt = (int)today.DayOfWeek; // Get the day of the week for lastDayOfMonth
            DateTime todayPlusTwo = today.AddDays(2); // Add 2 to Mon Tue Wed
            DateTime todayPlusFour = today.AddDays(4); // Add 4 to Thur Fri

            if (today == fourthDayOfMonth && (fourthDayOfMonthInt == 4 || fourthDayOfMonthInt == 5))      // Check that today's if date matches fourthDayOfMonth and is Thurs or Fri
            {
                driver.FindElement(By.ClassName("datepicker-inline")).Click(); // Click the the next month of the Calendar
                DateTime fourthDayOfMonthPlusFive = fourthDayOfMonth.AddDays(5); // Add 5 to fourthDayOfMonth
                string fourthDayOfMonthPlusFiveDay = fourthDayOfMonthPlusFive.ToString("%d"); // Get the day of fourthDayOfMonthPlusFive
                driver.FindElement(By.XPath("//div[@data-date='{fourthDayOfMonthPlusFiveDay}']")).Click(); // Click the fourthDayOfMonthPlusFive in Calendar
            }
            if (today == thirdDayOfMonth && (thirdDayOfMonthInt == 4 || thirdDayOfMonthInt == 5))      // Check that today's if date matches thirdDayOfMonth and is Thurs or Fri
            {
                driver.FindElement(By.ClassName("datepicker-inline")).Click(); // Click the the next month of the Calendar
                DateTime thirdDayOfMonthPlusFive = thirdDayOfMonth.AddDays(5); // Add 5 to thirdDayOfMonth
                string thirdDayOfMonthPlusFiveDay = thirdDayOfMonthPlusFive.ToString("%d"); // Get the day of thirdDayOfMonthPlusFive
                driver.FindElement(By.XPath("//div[@data-date='{thirdDayOfMonthPlusFiveDay}']")).Click(); // Click the thirdDayOfMonthPlusFiveDay in Calendar
            }
            if (today == secondDayOfMonth && (secondDayOfMonthInt == 4 || secondDayOfMonthInt == 5))      // Check that today's if date matches secondDayOfMonth and is Thurs or Fri
            {
                driver.FindElement(By.ClassName("datepicker-inline")).Click(); // Click the the next month of the Calendar
                DateTime secondDayOfMonthPlusFive = secondDayOfMonth.AddDays(5); // Add 5 to secondDayOfMonth
                string secondDayOfMonthPlusFiveDay = secondDayOfMonthPlusFive.ToString("%d"); // Get the day of secondDayOfMonthPlusFive
                driver.FindElement(By.XPath("//div[@data-date='{secondDayOfMonthPlusFiveDay}']")).Click(); // Click the secondDayOfMonthPlusFiveDay in Calendar
            }
            if (today == lastDayOfMonth && (lastDayOfMonthInt == 4 || lastDayOfMonthInt == 5))      // Check that today's if date matches lastDayOfMonth and is Thurs or Fri
            {
                driver.FindElement(By.ClassName("datepicker-inline")).Click(); // Click the the next month of the Calendar
                DateTime lastDayOfMonthPlusFive = lastDayOfMonth.AddDays(5); // Add 5 to lastDayOfMonth
                string lastDayOfMonthPlusFiveDay = lastDayOfMonthPlusFive.ToString("%d"); // Get the day of lastDayOfMonthPlusFive
                driver.FindElement(By.XPath("//div[@data-date='{secondDayOfMonthPlusFiveDay}']")).Click(); // Click the secondDayOfMonthPlusFiveDay in Calendar
            }
            if (today == lastDayOfMonth && (lastDayOfMonthInt == 1 || lastDayOfMonthInt == 2 || lastDayOfMonthInt == 3))      // Check that today's if date matches lastDayOfMonth and is Mon, Tue or Wed
            {
                driver.FindElement(By.ClassName("datepicker-inline")).Click(); // Click the the next month of the Calendar
                DateTime lastDayOfMonthPlusTwo = lastDayOfMonth.AddDays(2); // Add 2 to lastDayOfMonth
                string lastDayOfMonthPlusTwoDay = lastDayOfMonthPlusTwo.ToString("%d"); // Get the day of lastDayOfMonthPlusTwo
                driver.FindElement(By.XPath("//div[@data-date='{lastDayOfMonthPlusTwoDay}']")).Click(); // Click the secondDayOfMonthPlusFiveDay in Calendar
            }

            if (todaysDayInt == 1 || todaysDayInt == 2 || todaysDayInt == 3)      // Check that todays is Mon, Tue or Wed and add 2 days
            {
                string todaysDayPlusTwoDay = todayPlusTwo.ToString("%d"); // Get the day of lastDayOfMonthPlusTwo
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
                bool staleElement = true;
                while (staleElement)
                {
                    try
                    {
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
                        driver.FindElement(By.XPath("//div[@data-date='" + todaysDayPlusTwoDay + "']")).Click(); // Click the Calendar
                        //string cssColor = driver.FindElement(By.XPath("//div[@data-date='" + todaysDayPlusTwoDay + "']//span[1]")).GetCssValue("background-color");

                        //cssColor = cssColor.Trim(); // Brake apart css color should be mainly GREEN color = rgba(49, 202, 200, 1)
                        //int left = cssColor.IndexOf('(');
                        //int right = cssColor.IndexOf(')');
                        //string noBrackets = cssColor.Substring(left + 1, right - left - 1);
                        //string[] parts = noBrackets.Split(',');

                        //int r = int.Parse(parts[0], CultureInfo.InvariantCulture);
                        //int g = int.Parse(parts[1], CultureInfo.InvariantCulture);
                        //int b = int.Parse(parts[2], CultureInfo.InvariantCulture);
                        //int a = int.Parse(parts[3], CultureInfo.InvariantCulture);

                        //Assert.AreEqual(49, r);
                        //Assert.AreEqual(202, g);
                        //Assert.AreEqual(200, b);
                        //Assert.AreEqual(1, a);

                        staleElement = false;
                    }
                    catch (StaleElementReferenceException e)
                    {
                        staleElement = true;
                    }
                }
            }
            else      // Today's is Thur, Fri and add 4 days
            {
                string todaysDayPlusFourDay = todayPlusFour.ToString("%d"); // Get the day of the booking
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
                bool staleElement2 = true;
                while (staleElement2)
                {
                    try
                    {
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
                        driver.FindElement(By.XPath("//div[@data-date='" + todaysDayPlusFourDay + "']")).Click(); // Click the Calendar
                        staleElement2 = false;
                    }
                    catch (StaleElementReferenceException e)
                    {
                        staleElement2 = true;
                    }
                }
            }
        }

        [When(@"enters Reason for the Appointment")]
        public void WhenEntersReasonForTheAppointment()
        {
            driver.FindElement(By.Id("ReasonId")).Click();
            new SelectElement(driver.FindElement(By.Id("ReasonId"))).SelectByText("Doctor");
        }

        [When(@"enters Notes about the Appointment")]
        public void WhenEntersNotesAboutTheAppointment()
        {
            driver.FindElement(By.Id("Notes")).Click();
            driver.FindElement(By.Id("Notes")).Clear();
            driver.FindElement(By.Id("Notes")).SendKeys("Test Notes");
            driver.FindElement(By.XPath("//input[@value='Request']")).Click();             // Click the submit button
        }
        [Then(@"books the Time Off")]
        public void ThenBooksTheTimeOff()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.FindElement(By.XPath("//input[@value='Request']")).Click();             // Click the submit button
            // Check the date of the booked holiday
            //string todayPlusTwoFormatted = todayPlusTwo.ToString("ddd dd MMM yyyy");
            //Assert.AreEqual("Fri 12 Sep 2020", driver.FindElement(By.XPath("//div[@id='exceptionsContainer']/div[5]/div[4]/div")).Text);
        }

        [Then(@"the employee fails to book the same day again")]
        public void ThenTheEmployeeFailsToBookTheSameDayAgain()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath("//input[@value='Request']")).Click();             // Click the submit button
            Thread.Sleep(10000); // using a sleep
            Assert.IsTrue(IsElementPresent(By.Id("validationWarning")));

            bool? IsElementPresent(By by)
            {
                try
                {
                    driver.FindElement(by);
                    return true;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }

        [Then(@"cancels a booked holiday")]
        public void ThenCancelsABookedHoliday()
        {
            driver.FindElement(By.XPath("//button[@class='btn-cancel _cancel']")).Click();
            driver.FindElement(By.LinkText("Yes")).Click();
        }

        [Then(@"cancels the booked Time In Lieu")]
        public void ThenCancelstheBookedTimeInLieu()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.FindElement(By.XPath("//button[@class='btn-cancel _cancel']")).Click();
            driver.FindElement(By.LinkText("Yes")).Click();
        }

        [Then(@"cancels the booked Appointment")]
        public void ThenCancelsTheBookedAppointment()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath("(//button[@class='btn-cancel _cancel'])[2]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.LinkText("Yes")).Click();
        }

        [Then(@"the employee logs out")]
        public void ThenTheEmployeeLogsOut()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            string xpath5 = "//button[@class='btn btn-logout']";
            bool staleElement2 = true;
            while (staleElement2)
            {
                try
                {
                    driver.FindElement(By.XPath(xpath5)).Click();
                    staleElement2 = false;

                }
                catch (StaleElementReferenceException e)
                {
                    staleElement2 = true;
                }
            }
            driver.Close();
        }
    }
}
