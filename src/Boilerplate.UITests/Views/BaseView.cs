using Boilerplate.Shared;
using Xamarin.UITest;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace Boilerplate.UITests
{
    public abstract class BaseView
    {
        protected readonly Query Loading;

        protected BaseView(IApp app, string pageTitle, string pageIcon)
        {
            App = app;
            Title = pageTitle;
            Icon = pageIcon;
            Loading =  x => x.Marked(AutomationId.Loading);
        }
        
        protected IApp App { get; }
        public string Title { get; }
        public string Icon { get; }

        public virtual void WaitForViewToLoad() => App.WaitForElement(Title);
        public virtual void WaitForLoading() => App.WaitForElement(Loading);
        public virtual void WaitForLoadingFinish() => App.WaitForNoElement(Loading);
    }
}
