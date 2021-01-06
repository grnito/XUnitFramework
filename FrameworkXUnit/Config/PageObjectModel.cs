namespace FrameworkXUnit1.Config
{
    public abstract class PageObjectModel
    {
        protected readonly SeleniumHelper Helper;

        protected PageObjectModel(SeleniumHelper helper)
        {
            Helper = helper;
        }

        public string GetUrl()
        {
            return Helper.GetUrl();
        }

        public void NavigateToUrl(string url)
        {
            Helper.GoToUrl(url);
        }
    }
}
