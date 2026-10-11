namespace Summary.IdealCrm
{
    using Microsoft.Extensions.Localization;
    using Core.Navigation;
    using System;
    using System.Threading.Tasks;

    public class Menu : INavigationProvider
    {
        private readonly IStringLocalizer<Menu> _localizer;

        public Menu(IStringLocalizer<Menu> localizer)
        {
            _localizer = localizer;
        }

        public Task BuildNavigationAsync(string name, NavigationBuilder builder)
        {
            if (!String.Equals(name, "admin", StringComparison.OrdinalIgnoreCase)) 
                return Task.CompletedTask;
            builder.Add(_localizer["Configuration"], configuration =>
            {
                configuration.Add(_localizer["Settings"], settings =>
                {
                    settings.Add(_localizer["سی آر ام ایده آل"], _localizer["سی آر ام ایده آل"], itemBuilder =>
                    {
                        itemBuilder.Action("Index", "Admin", new { area = "Core.Settings", groupId = "IdealCrm" })
                            .Permission(Permissions.ManageIdealCrmSettings)
                            .LocalNav();
                    });
                });
            });
            return Task.CompletedTask;
        }
    }
}