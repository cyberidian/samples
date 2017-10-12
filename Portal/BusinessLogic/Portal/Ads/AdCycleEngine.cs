using AtomicArcade.DataModels.Portal.Ads;
using AtomicArcade.ViewModels.Portal.Ads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicArcade.ViewLogic.Portal.Ads
{
    public class AdCycleEngine: IAdCycleEngine
    {

        public IEnumerable<AdViewModel> GetAds(IEnumerable<Ad> adList)
        {

            var adVMList = new List<AdViewModel>();
            //change this to LINQ projection
            foreach (Ad ad in adList)
            {
                var adVM = new AdViewModel()
                {
                    AdId = ad.AdId,
                    Name = ad.Name,
                    Link = ad.Link,
                    BannerFile = ad.BannerGraphicFile
                };
                adVMList.Add(adVM);
            }

            //Business Logic - sort based on configuration.AdCycle, Priority or Random


            return adVMList;

        }
    }
}
