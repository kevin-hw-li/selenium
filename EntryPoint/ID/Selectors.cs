using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

class Selectors
{
    static void Main()
    {
        //declaring URL variables
        string nameUrl = "http://testing.todorvachev.com/selectors/name";
        string idUrl = "http://testing.todorvachev.com/selectors/id";
        string classUrl = "http://testing.todorvachev.com/selectors/class-name";
        string cssPathUrl = "http://testing.todvachev.com/selectors/css-path/";
       
        //open a testing browser
        IWebDriver driver = new ChromeDriver();

        //search and test element by Name
        driver.Navigate().GoToUrl(nameUrl);
        IWebElement nameElement;

        try
        {
            nameElement = driver.FindElement(By.Name("myName"));

            if (nameElement.Displayed)
            {
                GreenMessage("The element searched by Name is displayed on the page.");
            }
        }
        catch (NoSuchElementException)
        {
            RedMessage("Something went wrong. The element searched by Name is not displayed.");
        }

        //search and test element by ID
        driver.Navigate().GoToUrl(idUrl);
        IWebElement idElement;

		try
		{
			idElement = driver.FindElement(By.Id("testImage"));

			if (idElement.Displayed)
			{
				GreenMessage("The element searched by ID is displayed on the page.");
			}
		}
		catch (NoSuchElementException)
		{
			RedMessage("Something went wrong. The element searched by ID is not displayed.");
		}

        //search and test element by Class
        driver.Navigate().GoToUrl(classUrl);
        IWebElement classElement = driver.FindElement(By.ClassName("testClass"));
        Console.WriteLine("Inner Text of the testing element is:");
        GreenMessage(classElement.Text);

        //search and test element by CSS Path
        driver.Navigate().GoToUrl(cssPathUrl);
        IWebElement CssPathElement;

		try
		{
            CssPathElement = driver.FindElement(By.CssSelector("#post-108 > div > figure > img"));
            //to test the catch block, use the below:
			//CssPathElement = driver.FindElement(By.CssSelector("#post-108 > div > figure > div"));

			if (CssPathElement.Displayed)
			{
				GreenMessage("The element searched by CSS Path is displayed on the page.");
			}
		}
		catch (NoSuchElementException)
		{
			RedMessage("Something went wrong. The element searched by CSS Path is not displayed.");
		}

        //exit testing browser
        driver.Quit();
    }

    private static void RedMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    private static void GreenMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}
