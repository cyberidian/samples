using AtomicArcade.ViewModels.Portal.Ads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicArcade.Services.Portal.Ads
{
    public interface IAdService
    {
        IList<AdViewModel> GetAds(string page);
    }
}
