namespace SeleniumTests;

[TestFixture]
class SeleniumWebFormTest
{
    IWebDriver driver;

    [SetUp]
    public void preConditions()
    {
        driver = new ChromeDriver();
        driver.Url = "https://www.selenium.dev/selenium/web/web-form.html";
        driver.Manage().Window.Maximize();
    }

    [Test]
    public void TestTitle()
    {
        Assert.That(driver.Title, Is.EqualTo("Web form"));
    }

    [Test]
    public void TestTextInput()
    {
        IWebElement textbox = SeleniumWebFormPage.Textbox(driver);
        textbox.SendKeys("Selenium");
        Assert.That(textbox.GetAttribute("value"), Is.EqualTo("Selenium"));
    }

    [Test]
    public void TestTextPassword()
    {
        IWebElement passbox = SeleniumWebFormPage.Passbox(driver);
        Assert.That(passbox.GetAttribute("type"), Is.EqualTo("password"));
        Assert.That(passbox.GetAttribute("autocomplete"), Is.EqualTo("off"));
    }

    [Test]
    public void TestTextArea()
    {
        IWebElement textarea = SeleniumWebFormPage.Textarea(driver);
        Assert.That(textarea.Enabled, Is.EqualTo(true));
        Assert.That(textarea.GetAttribute("rows"), Is.EqualTo("3"));
        textarea.SendKeys("Selenium is a tool for automating web applications using various browsers.");
    }

    [Test]
    public void TestDisabledInput()
    {
        IWebElement disabledInput = SeleniumWebFormPage.DisabledInput(driver);
        Assert.That(disabledInput.Enabled, Is.EqualTo(false));
    }

    [Test]
    public void TestReadonlyInput()
    {
        IWebElement readonlyInput = SeleniumWebFormPage.ReadonlyInput(driver);
        String readonlyInputTextPrev = readonlyInput.GetAttribute("value");
        Assert.That(readonlyInput.GetAttribute("value"), Is.EqualTo(readonlyInputTextPrev));
    }

    [Test]
    public void TestReturnToIndex()
    {
        IWebElement anchorIndex = SeleniumWebFormPage.AnchorIndex(driver);

        anchorIndex.Click();
        Assert.That(driver.Url, Is.EqualTo("https://www.selenium.dev/selenium/web/index.html"));
        Assert.That(driver.Title, Is.EqualTo("Index of Available Pages"));

        driver.Navigate().Back();
        Assert.That(driver.Url, Is.EqualTo("https://www.selenium.dev/selenium/web/web-form.html"));
        Assert.That(driver.Title, Is.EqualTo("Web form"));
    }

    [Test]
    public void TestSelectDropdown()
    {
        IWebElement select = SeleniumWebFormPage.SelectDropdown(driver);
        SelectElement dropdown = new SelectElement(select);
        for (int i = 1; i < 4; i++)
        {
            String str = i.ToString();
            dropdown.SelectByValue(str);
            Assert.That(select.GetAttribute("value"), Is.EqualTo(str));
        }
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}