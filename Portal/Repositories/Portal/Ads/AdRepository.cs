using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtomicArcade.DataModels.Portal.Ads;
using AtomicArcade.Repositories.Ads;
using AtomicArcade.DataModels;

namespace AtomicArcade.Repositories.Portal.Ads
{
    public class AdRepository: IAdRepository
    {
        private readonly AADbContext _aaDbContext;

        public AdRepository(AADbContext dbContext)
        {
            _aaDbContext = dbContext;
        }

        public Ad Get(int adId)
        {
            return _aaDbContext.Ads.FirstOrDefault(x => x.AdId == adId);
        }

        public IEnumerable<Ad> GetAllActiveAds(DateTime nowUTC)
        {
            return _aaDbContext.Ads.Where(x => x.Active==true && x.StartDate <= nowUTC && x.ExpirationDate >= nowUTC).ToList();
        }

    }
}
