using System;
using Framework;
using Framework.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using Site.Pages;

namespace Site.Tests;

public class Tests {

    [OneTimeSetUp]
    public void BeforeAll() {
        FW.CreateOutputDirectory();
    }

    [SetUp]
    public void BeforeEach() {
        FW.SetLogger();
        Driver.Init();
        Driver.Current.Manage().Window.Maximize();
    }

    [TearDown]
    public void AfterEach() {
        Driver.Quit();
    }

    [Test]
    public void GeorgInstaCheck() {

        Driver.GoTo("georglaabe.ru");
    
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

        Driver.GoTo("georglaabe.ru/trans");
        Console.WriteLine("");

        IWebElement submit = Driver.FindElement(By.CssSelector("button[onclick='trans()']"));
        IWebElement input1 = Driver.FindElement(By.Id("txt1"));
        IWebElement input2 = Driver.FindElement(By.Id("txt2"));

        string[] strings = {"Эстония - крутая страна!", 
                            "Люблю работать в 'Энергии'",
                            "18 лЕт я жИву в этОм мирЕ"};

        string[] strings2 = {"Estoniya - krutaya strana!",
                            "Ljublju rabotat v Energii",
                            "18 lEt ya zhIvu v etOm mirE"};

        for (int i = 0; i < strings.GetLength(0); i++) {
            
            string script = "document.getElementById('txt1').value = '';";
            exec(script);
            FW.Log.Step("Script was executed: >>> " + script + " <<< ");
            
            input1.SendKeys(strings[i]);
            FW.Log.Step("Keys (" + strings[i] + ") were sent to element with ID: " + input1.GetAttribute("id"));
                        
            submit.Click();
            FW.Log.Step("Clicked on element with ID: " + submit.GetAttribute("id"));

            Assert.True(input2.GetAttribute("value") == strings2[i]);
            FW.Log.Step("Compared values: >>> " + input2.GetAttribute("value") + " <<< & >>> " + strings2[i] + " <<< ");

        }

        FW.Log.Info("Tests were passed successfully!");

    }

    
    public void exec(String script) {
        IJavaScriptExecutor jsEx = (IJavaScriptExecutor) Driver.Current;
        jsEx.ExecuteScript(script);
    }

}