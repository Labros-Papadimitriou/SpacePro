namespace MyDatabase.Migrations
{
    using Entities.BroadClasses;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MyDatabase.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MyDatabase.ApplicationDbContext db)
        {
            #region SeedArticles
            //ArticleCategory ac1 = new ArticleCategory() { Title = "BigBang" };
            //ArticleCategory ac2 = new ArticleCategory() { Title = "Planets" };
            //ArticleCategory ac3 = new ArticleCategory() { Title = "Stars" };
            //ArticleCategory ac4 = new ArticleCategory() { Title = "Moons" };
            //ArticleCategory ac5 = new ArticleCategory() { Title = "Comets" };
            //ArticleCategory ac6 = new ArticleCategory() { Title = "Theory" };
            //ArticleCategory ac7 = new ArticleCategory() { Title = "Other" };
            //List<ArticleCategory> articleCategories = new List<ArticleCategory> { ac1, ac2, ac3, ac4, ac5, ac6, ac7 };

            //db.ArticleCategories.AddRange(articleCategories);
            //db.SaveChanges();

            //ArticleImage ai1 = new ArticleImage() { Url = "https://i.ytimg.com/vi/sNhhvQGsMEc/sddefault.jpg", AlternativeText = "Fermi Paradox" };
            //db.ArticleImages.Add(ai1);

            //Article a1 = new Article()
            //{
            //    Title = "Fermi Paradox",
            //    PostDate = new DateTime(2005, 02, 05),
            //    PostLikes = 7,
            //    ShortDescription = "The Fermi paradox is the conflict between the lack of clear, obvious evidence for extraterrestrial life and various high estimates for their existence.",
            //    FullDescription = @"The Fermi paradox can be asked in two ways. The first is, 'Why are no aliens or their artifacts found here on Earth,
            //        or in the Solar System ? If interstellar travel is possible, even the 'slow' kind nearly within the reach of Earth technology, then it would only take from 5 million to 50 million years to colonize the galaxy. This is relatively brief on a geological scale, let alone a cosmological one. Since there are many stars older than the Sun, and since intelligent life might have evolved earlier elsewhere, the question then becomes why the galaxy has not been colonized already. Even if colonization is impractical or undesirable to all alien civilizations, large-scale exploration of the galaxy could be possible by probes. These might leave detectable artifacts in the Solar System, such as old probes or evidence of mining activity, but none of these have been observed.
            //        The second form of the question is 'Why do we see no signs of intelligence elsewhere in the universe?'.This version does not assume interstellar travel,
            //        but includes other galaxies as well.For distant galaxies,travel times may well explain the lack of alien visits to Earth,but a sufficiently advanced civilization could potentially be observable over a significant fraction of the size of the observable universe.Even if such civilizations are rare, the scale argument indicates they should exist somewhere at some point during the history of the universe, and since they could be detected from far away over a considerable period of time, many more potential sites for their origin are within range of human observation.It is unknown whether the paradox is stronger for the Milky Way galaxy or for the universe as a whole.",
            //    AuthorName = "Enrico Fermi",
            //    ArticleCategoryId = 6,
            //    ArticleImage = ai1
            //};
            //db.Articles.Add(a1);

            //ArticleImage ai2 = new ArticleImage() { Url = "https://ec.europa.eu/research-and-innovation/sites/default/files/styles/w1108/public/hm/field/image/pia00330_modest.jpg?itok=ndI38m2N", AlternativeText = "Comets" };
            //db.ArticleImages.Add(ai2);

            //Article a2 = new Article()
            //{
            //    Title = "How scientists are ‘looking’ inside asteroids",
            //    PostDate = new DateTime(2022, 01, 03),
            //    PostLikes = 10,
            //    ShortDescription = "Asteroids can pose a threat to life on Earth but are also a valuable source of resources to make fuel or water to aid deep space exploration.",
            //    FullDescription = @"Asteroids can pose a threat to life on Earth but are also a valuable source of resources to make fuel or water to aid deep space exploration. Devoid of geological and atmospheric processes, these space rocks provide a window onto the evolution of the solar system. But to really understand their secrets, scientists must know what’s inside them.
            //                        Only four spacecraft have ever landed on an asteroid – most recently in October 2020 – but none has peered inside one. Yet understanding the internal structures of these cosmic rocks is crucial for answering key questions about, for example, the origins of our own planet.
            //                        ‘Asteroids are the only objects in our solar system that are more or less unchanged since the very beginning of the solar system’s formation,’ said Dr Fabio Ferrari, who studies asteroid dynamics at the University of Bern, Switzerland. ‘If we know what’s inside asteroids, we can understand a lot about how planets formed, how everything that we have in our solar system has formed and might evolve in the future.’
            //                        Then are also more practical reasons for knowing what’s inside an asteroid, such as mining for materials to facilitate human exploration of other celestial bodies, but also defending against an Earth-bound rock.
            //                        NASA’s upcoming Double Asteroid Redirection Test (DART) mission, expected to launch later this year, will crash into the 160m in diameter asteroid moon Dimorphos in 2022, with the aim of changing its orbit. The experiment will demonstrate for the first time whether humans can deflect a potentially dangerous asteroid.
            //                        But scientists have only rough ideas about how Dimorphos will respond to the impact as they know very little about both this asteroid moon, and its parent asteroid, Didymos.
            //                        To better address such questions, scientists are investigating how to remotely tell what’s inside an asteroid and discern its type.
            //                        Types
            //                        There are many types of asteroids. Some are solid blocks of rock, rugged and sturdy, others are conglomerates of pebbles, boulders and sand, products of many orbital collisions, held together only by the power of gravity. There are also rare metallic asteroids, heavy and dense.
            //                        ‘To deflect the denser monolithic asteroids, you would need a bigger spacecraft, you would need to travel faster,’ said Dr Hannah Susorney, a research fellow in planetary science at the University of Bristol, the UK. ‘The asteroids that are just bags of material – we call them rubble piles – can, on the other hand, blow apart into thousands of pieces. Those pieces could by themselves become dangerous.’
            //                        Dr Susorney is exploring what surface features of an asteroid can reveal about the structure of its interior as part of a project called EROS.  
            //                        This information could be useful for future space mining companies who would want to know as much as possible about a promising asteroid before investing into a costly prospecting mission as well as knowing more about potential threats.
            //                        ‘There are thousands of near-Earth asteroids, those whose trajectories could one day intersect with that of the Earth,’ she said. ‘We have only visited a handful of them. We know close to nothing about the vast majority.’",
            //    AuthorName = "Tereza Pultarova",
            //    ArticleCategoryId = 5,
            //    ArticleImage = ai2
            //};
            //db.Articles.Add(a2);
            //db.SaveChanges();
        }
    }
}
