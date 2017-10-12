using AtomicArcade.DataModels;
using AtomicArcade.DataModels.Portal.Ads;
using AtomicArcade.Repositories;
using AtomicArcade.Repositories.Ads;
using AtomicArcade.Repositories.Portal.Ads;
using AtomicArcade.ViewLogic.Portal.Ads;
using AtomicArcade.ViewLogic.Shared.TimeZoneHelper;
using AtomicArcade.ViewModels.Portal.Ads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicArcade.Services
{
    public class AdService
    {

        public AdService()
        {

        }

        public IList<AdViewModel> GetAds(string page)
        {
            //Business Logic - determine correct start and end dates based on time zone and now
            var tzHelper = new TimeZoneHelper();
            var nowUTC = tzHelper.GetUTCDateTime(DateTime.Now, TimeZoneInfo.Local);

            var unitOfWork = new AAPortalUnitOfWork();
            var adsRepository = unitOfWork.GetRepository<AdRepository>();
            var ads = adsRepository.GetAllActiveAds(nowUTC);

            var adEngine = new AdCycleEngine();
            var adList = adEngine.GetAds(ads).ToList<AdViewModel>();

            return adList;
        }

    }
}
