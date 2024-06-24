namespace PageObjectModels
{

    public static class SeleniumWebFormPage
    {
        public static IWebElement Textbox(IWebDriver driver)
        {
            return driver.FindElement(By.Name("my-text"));
        }

        public static IWebElement Passbox(IWebDriver driver)
        {
            return driver.FindElement(By.Name("my-password"));
        }

        public static IWebElement Textarea(IWebDriver driver)
        {
            return driver.FindElement(By.Name("my-textarea"));
        }

        public static IWebElement DisabledInput(IWebDriver driver)
        {
            return driver.FindElement(By.Name("my-disabled"));
        }

        public static IWebElement ReadonlyInput(IWebDriver driver)
        {
            return driver.FindElement(By.Name("my-readonly"));
        }

        public static IWebElement AnchorIndex(IWebDriver driver)
        {
            return driver.FindElement(By.CssSelector(".form-group a"));
        }

        public static IWebElement SelectDropdown(IWebDriver driver)
        {
            return driver.FindElement(By.Name("my-select"));
        }
    }

}