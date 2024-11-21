using Abp.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AbpCompanyName.AbpProjectName.Web.Views.Shared.Components.LanguageSelection
{
    public class LanguageSelectionViewComponent : ViewComponent
    {
        private readonly ILanguageManager _languageManager;

        public LanguageSelectionViewComponent(ILanguageManager languageManager)
        {
            _languageManager = languageManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new LanguageSelectionViewModel
            {
                CurrentLanguage = _languageManager.CurrentLanguage,
                Languages = _languageManager.GetLanguages(),
                CurrentUrl = Request.Path
            };

            return await Task.FromResult(View(model));
        }
    }
}
