using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtomicArcade.DataModels.Portal.Ads;
using AtomicArcade.Repositories;

namespace AtomicArcade.Repositories.Ads
{
    public interface IAdRepository: IBaseRepository
    {
        IEnumerable<Ad> GetAllActiveAds(DateTime nowUTC);
    }
}
