using Entities.Bodies;
using Entities.BroadClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDatabase.Seeding
{
    public class SeedingService
    {
        ApplicationDbContext db;

        public SeedingService(ApplicationDbContext context)
        {
            db = context;
        }

        #region Bodies Seedings
        public void SeedPlanets()
        {
            Planet p1 = new Planet() { Name = "Mercury" };
            Planet p2 = new Planet() { Name = "Venus" };
            Planet p3 = new Planet() { Name = "Earth" };
            IList<Planet> planets = new List<Planet> { p1, p2, p3 };

            db.Planets.AddRange(planets);
            db.SaveChanges();
        }
        #endregion

        #region Broad Seeding
        public void SeedArticles()
        {
            Article a1 = new Article() { Title = "Bing-Bang Theory" };
            Article a2 = new Article() { Title = "Fermi Paradox" };
            Article a3 = new Article() { Title = "The End of Earth" };
            IList<Article> articles = new List<Article> { a1, a2, a3 };

            db.Articles.AddRange(articles);
            db.SaveChanges();
        }

        public void SeedArticleCategories()
        {
            ArticleCategory ac1 = new ArticleCategory() { Title = "BigBang" };
            ArticleCategory ac2 = new ArticleCategory() { Title = "Planets" };
            ArticleCategory ac3 = new ArticleCategory() { Title = "Stars" };
            ArticleCategory ac4 = new ArticleCategory() { Title = "Comets" };
            ArticleCategory ac5 = new ArticleCategory() { Title = "Other" };
            IList<ArticleCategory> articleCategories = new List<ArticleCategory> { ac1, ac2, ac3, ac4, ac5 };

            db.ArticleCategories.AddRange(articleCategories);
            db.SaveChanges();
        }

        public void SeedEvents()
        {
            Event e1 = new Event() { Title = "Winner Sub" };
            Event e2 = new Event() { Title = "Author of the Month" };
            Event e3 = new Event() { Title = "GiveAway" };
            IList<Event> events = new List<Event> { e1, e2, e3 };

            db.Events.AddRange(events);
            db.SaveChanges();
        }

        public void SeedImages()
        {
            Image i1 = new Image() { Url = "~/Template/sash/assets/images/media/1.jpg" };
            Image i2 = new Image() { Url = "~/Template/sash/assets/images/media/3.jpg" };
            Image i3 = new Image() { Url = "~/Template/sash/assets/images/media/7.jpg" };
            IList<Image> images = new List<Image> { i1, i2, i3 };

            db.Images.AddRange(images);
            db.SaveChanges();
        }
        #endregion

    }
}
