//using Entities.Bodies;
//using Entities.BroadClasses;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MyDatabase.Seeding
//{
//    public class SeedingService
//    {
//        ApplicationDbContext db;

//        public SeedingService(ApplicationDbContext context)
//        {
//            db = context;
//        }

//        #region Broad Seeding
//        public void SeedArticles()
//        {
//            ArticleImage ai1 = new ArticleImage() { Url = "https://i.ytimg.com/vi/sNhhvQGsMEc/sddefault.jpg", AlternativeText = "Fermi Paradox" };
//            db.ArticleImages.Add(ai1);

//            Article a1 = new Article()
//            {
//                Title = "Fermi Paradox",
//                PostDate = new DateTime(2005, 02, 05),
//                PostLikes = 7,
//                ShortDescription = "The Fermi paradox is the conflict between the lack of clear, obvious evidence for extraterrestrial life and various high estimates for their existence.",
//                FullDescription = @"<p>The Fermi paradox can be asked in two ways. The first is, 'Why are no aliens or their artifacts found here on Earth,
//                    or in the Solar System ? '. If interstellar travel is possible, even the 'slow' kind nearly within the reach of Earth technology, then it would only take from 5 million to 50 million years to colonize the galaxy. This is relatively brief on a geological scale, let alone a cosmological one. Since there are many stars older than the Sun, and since intelligent life might have evolved earlier elsewhere, the question then becomes why the galaxy has not been colonized already. Even if colonization is impractical or undesirable to all alien civilizations, large-scale exploration of the galaxy could be possible by probes. These might leave detectable artifacts in the Solar System, such as old probes or evidence of mining activity, but none of these have been observed.</p>
//                    < p > The second form of the question is 'Why do we see no signs of intelligence elsewhere in the universe?'.This version does not assume interstellar travel,
//                    but includes other galaxies as well.For distant galaxies,travel times may well explain the lack of alien visits to Earth,but a sufficiently advanced civilization could potentially be observable over a significant fraction of the size of the observable universe.Even if such civilizations are rare, the scale argument indicates they should exist somewhere at some point during the history of the universe, and since they could be detected from far away over a considerable period of time, many more potential sites for their origin are within range of human observation.It is unknown whether the paradox is stronger for the Milky Way galaxy or for the universe as a whole.</ p >",
//                ArticleCategoryId = 11,
//                ArticleImages = new List<ArticleImage> { ai1 }
//            };
//            db.Articles.Add(a1);
//            db.SaveChanges();
//        }

//        public void SeedArticleCategories()
//        {
//            ArticleCategory ac1 = new ArticleCategory() { Title = "BigBang" };
//            ArticleCategory ac2 = new ArticleCategory() { Title = "Planets" };
//            ArticleCategory ac3 = new ArticleCategory() { Title = "Stars" };
//            ArticleCategory ac4 = new ArticleCategory() { Title = "Moons" };
//            ArticleCategory ac5 = new ArticleCategory() { Title = "Comets" };
//            ArticleCategory ac6 = new ArticleCategory() { Title = "Theory" };
//            ArticleCategory ac7 = new ArticleCategory() { Title = "Other" };
//            List<ArticleCategory> articleCategories = new List<ArticleCategory> { ac1, ac2, ac3, ac4, ac5, ac6, ac7 };

//            db.ArticleCategories.AddRange(articleCategories);
//            db.SaveChanges();
//        }

//        public void SeedEvents()
//        {
//            Event e1 = new Event() { Title = "Winner Sub" };
//            Event e2 = new Event() { Title = "Author of the Month" };
//            Event e3 = new Event() { Title = "GiveAway" };
//            IList<Event> events = new List<Event> { e1, e2, e3 };

//            db.Events.AddRange(events);
//            db.SaveChanges();
//        }

//        #endregion

//    }
//}
