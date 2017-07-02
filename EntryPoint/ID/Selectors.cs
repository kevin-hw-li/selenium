﻿using System;
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

        //open a testing browser
		IWebDriver driver = new ChromeDriver();

        //search and test element by Name 
		driver.Navigate().GoToUrl(nameUrl);
		IWebElement elementByName = driver.FindElement(By.Name("myName"));
		if (elementByName.Displayed)
		{
			GreenMessage("The element searched by Name is displayed on the page.");
		}
		else
		{
			RedMessage("Something went wrong. The element searched by Name is not displayed.");
		}

		//search and test element by ID
		driver.Navigate().GoToUrl(idUrl);
        IWebElement elementById = driver.FindElement(By.Id("testImage"));
		if (elementById.Displayed)
		{
			GreenMessage("The element searched by ID is displayed on the page.");
		}
		else
		{
			RedMessage("Something went wrong. The element searched by ID is not displayed.");
		}

		//search and test element by Class
		driver.Navigate().GoToUrl(classUrl);
		IWebElement elementByClass = driver.FindElement(By.ClassName("testClass"));
        Console.WriteLine("Inner Text of the testing element is:");
        GreenMessage(elementByClass.Text);

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
