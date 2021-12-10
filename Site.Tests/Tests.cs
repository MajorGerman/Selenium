using System;
using Framework.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using Site.Pages;

namespace Site.Tests;

public class Tests {
    [SetUp]
    public void BeforeEach() {
        Driver.Init();
        Driver.Current.Manage().Window.Maximize();
    }

    [TearDown]
    public void AfterEach() {
        Driver.Current.Quit();
    }

    [Test]
    public void GeorgInstaCheck() {

        Driver.Current.Url = "https://georglaabe.ru/";
        
        var footerNav = new FooterNav(Driver.Current);
        footerNav.Map.instaLink.Click();

        if (Driver.Current.Url == "https://www.instagram.com/rga_gt/") {
            Assert.Pass();
        } else {
            Assert.Fail();
        }
        
    }

    [Test]
    public void GeorgTransCheck() {

        Driver.Current.Url = "https://georglaabe.ru/trans";
        Console.WriteLine("");

        IWebElement submit = Driver.Current.FindElement(By.CssSelector("button[onclick='trans()']"));
        IWebElement input1 = Driver.Current.FindElement(By.Id("txt1"));
        IWebElement input2 = Driver.Current.FindElement(By.Id("txt2"));

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

            Assert.True(input2.GetAttribute("value") == strings2[i]);

        }
        
    }

    
    public void exec(String script) {
        IJavaScriptExecutor jsEx = (IJavaScriptExecutor) Driver.Current;
        jsEx.ExecuteScript(script);
    }

}