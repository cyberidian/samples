using AtomicArcade.DataModels.Portal.Ads;
using AtomicArcade.ViewLogic.Shared;
using AtomicArcade.ViewModels.Portal.Ads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicArcade.ViewLogic.Portal.Ads
{
    public interface IAdCycleEngine: ICycleEngine
    {
        IEnumerable<AdViewModel> GetAds(IEnumerable<Ad> adList);
    }
}
