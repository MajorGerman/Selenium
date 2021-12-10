using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Site.Pages;

namespace Site.Tests;

public class Tests {

    IWebDriver driver;
    
    [SetUp]
    public void BeforeEach() {
        driver = new ChromeDriver(Path.GetFullPath(@"../../../../" + "_drivers"));
        driver.Manage().Window.Maximize();
    }

    [TearDown]
    public void AfterEach() {
        driver.Quit();
    }

    [Test]
    public void GeorgInstaCheck() {

        driver.Url = "https://georglaabe.ru/";
        
        var footerNav = new FooterNav(driver);
        footerNav.Map.instaLink.Click();
        
        if (driver.Url == "https://www.instagram.com/rga_gt/") {
            Assert.Pass();
        } else {
            Assert.Fail();
        }
        
    }

    [Test]
    public void GeorgTransCheck() {

        driver.Url = "https://georglaabe.ru/trans";
        Console.WriteLine("");

        IWebElement submit = driver.FindElement(By.CssSelector("button[onclick='trans()']"));
        IWebElement input1 = driver.FindElement(By.Id("txt1"));
        IWebElement input2 = driver.FindElement(By.Id("txt2"));

        string[] strings = {"Эстония - крутая страна!", 
                            "Люблю работать в 'Энергии'",
                            "18 лЕт я жИву в этОм мирЕ"};

        string[] strings2 = {"Estoniya - krutaya strana!",
                            "Ljublju rabotat v Energii",
                            "18 lEt ya zhIvu v etOm mirE"};

        for (int i = 0; i < strings.GetLength(0); i++) {
            exec("document.getElementById('txt1').value = '';");
            input1.SendKeys(strings[i]);
            submit.Click();

            Console.WriteLine(input2.GetAttribute("value"));
            Console.WriteLine(strings2[i]);

            if (input2.GetAttribute("value") != strings2[i]) {
                Assert.Fail();
            }
        }

        Assert.Pass();

    }

    
    public void exec(String script) {
        IJavaScriptExecutor jsEx = (IJavaScriptExecutor) driver;
        jsEx.ExecuteScript(script);
    }

}