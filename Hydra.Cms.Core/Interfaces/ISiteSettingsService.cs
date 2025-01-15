using Hydra.Cms.Core.Models;
using Hydra.Infrastructure.GeneralModels;


namespace Hydra.Cms.Core.Interfaces
{
    public interface ISiteSettingsService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Result<SiteSettingsModel> GetSettings();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Result<SiteSettingsModel> AddOrUpdate(SiteSettingsModel siteSettingsModel);

    }
}
