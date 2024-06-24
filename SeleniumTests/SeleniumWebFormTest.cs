namespace SeleniumTests;

[TestFixture]
class SeleniumWebFormTest
{
    IWebDriver driver;

    [SetUp]
    public void PreConditions()
    {
        driver = new ChromeDriver();
        driver.Url = TestData.SeleniumWebFormTestData.FormUrl;
        driver.Manage().Window.Maximize();
    }

    [Test]
    public void TestTitle()
    {
        Assert.That(driver.Title, Is.EqualTo(TestData.SeleniumWebFormTestData.FormTitle));
    }

    [Test]
    public void TestTextInput()
    {
        IWebElement textbox = SeleniumWebFormPage.Textbox(driver);
        textbox.SendKeys("Selenium");
        Assert.That(textbox.GetAttribute("value"), Is.EqualTo(TestData.SeleniumWebFormTestData.MyTextInput));
    }

    [Test]
    public void TestTextPassword()
    {
        IWebElement passbox = SeleniumWebFormPage.Passbox(driver);
        Assert.That(passbox.GetAttribute("type"), Is.EqualTo(TestData.SeleniumWebFormTestData.PasswordInput));
        Assert.That(passbox.GetAttribute("autocomplete"), Is.EqualTo("off"));
    }

    [Test]
    public void TestTextArea()
    {
        IWebElement textarea = SeleniumWebFormPage.Textarea(driver);
        Assert.That(textarea.Enabled, Is.EqualTo(true));
        Assert.That(textarea.GetAttribute("rows"), Is.EqualTo("3"));
        textarea.SendKeys(TestData.SeleniumWebFormTestData.TextAreaInput);
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
        Assert.That(driver.Url, Is.EqualTo(TestData.SeleniumWebFormTestData.IndexTitle));
        Assert.That(driver.Title, Is.EqualTo(TestData.SeleniumWebFormTestData.IndexUrl));

        driver.Navigate().Back();
        Assert.That(driver.Url, Is.EqualTo(TestData.SeleniumWebFormTestData.FormUrl));
        Assert.That(driver.Title, Is.EqualTo(TestData.SeleniumWebFormTestData.FormTitle));
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