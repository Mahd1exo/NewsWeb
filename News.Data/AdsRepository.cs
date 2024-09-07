using NewsWeb.EF;
using NewsWeb.Entittes;
using System.Collections.Generic;
using System.Linq;


namespace NewsWeb.Data
{
    public class AdsRepository
    {
        private readonly MainContext context;

        public AdsRepository(MainContext context)
        {
            this.context = context;
        }

        public List<Ads> GetAds()
        {
            return context.Advertisments.ToList();
        }
        public void AddAds(Ads ads)
        {
            context.Advertisments.Add(ads);
            context.SaveChanges();
        }
        public void DeleteAds(int id)
        {
            var cm = context.Advertisments.Find(id);
            context.Advertisments.Remove(cm);
            context.SaveChanges();
        }
    }
}
