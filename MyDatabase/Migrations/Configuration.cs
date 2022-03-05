namespace MyDatabase.Migrations
{
    using Entities.Bodies;
    using Entities.BroadClasses;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

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

            //ArticleImage ai1 = new ArticleImage() { Name = "fermiparadox.jpg" Url = "/Content/ArticlesImages/fermiparadox.jpg", AlternativeText = "Fermi Paradox" };
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

            //ArticleImage ai2 = new ArticleImage() { Name = "cometsmock.jpg" Url = "/Content/ArticlesImages/cometsmock.jpg", AlternativeText = "Comets" };
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
            #endregion

            #region SeedBodyImages
            //stars
            BodyImage sun = new BodyImage() { Url = "/Content/BodiesImages/Stars/Sun.jpg", AlternativeText = "Sun" };
            //planets
            BodyImage earth = new BodyImage() { Url = "/Content/BodiesImages/PlanetsImages/Earth.jpg", AlternativeText = "Earth" };
            BodyImage jupiter = new BodyImage() { Url = "/Content/BodiesImages/PlanetsImages/Jupiter.jpg", AlternativeText = "Jupiter" };
            BodyImage mars = new BodyImage() { Url = "/Content/BodiesImages/PlanetsImages/Mars.jpg", AlternativeText = "Mars" };
            BodyImage mercury = new BodyImage() { Url = "/Content/BodiesImages/PlanetsImages/Mercury.jpg", AlternativeText = "Mercury" };
            BodyImage neptune = new BodyImage() { Url = "/Content/BodiesImages/PlanetsImages/Neptune.jpg", AlternativeText = "Neptune" };
            BodyImage pluto = new BodyImage() { Url = "/Content/BodiesImages/PlanetsImages/Pluto.jpg", AlternativeText = "Pluto" };
            BodyImage saturn = new BodyImage() { Url = "/Content/BodiesImages/PlanetsImages/Saturn.jpg", AlternativeText = "Saturn" };
            BodyImage uranus = new BodyImage() { Url = "/Content/BodiesImages/PlanetsImages/Uranus.jpg", AlternativeText = "Uranus" };
            BodyImage venus = new BodyImage() { Url = "/Content/BodiesImages/PlanetsImages/Venus.jpg", AlternativeText = "Venus" };

            //moons
            BodyImage adrastea = new BodyImage() { Url = "/Content/BodiesImages/Moons/Adrastea.jpg", AlternativeText = "Adrastea" };
            BodyImage amalthea = new BodyImage() { Url = "/Content/BodiesImages/Moons/Amalthea.jpg", AlternativeText = "Amalthea" };
            BodyImage ariel = new BodyImage() { Url = "/Content/BodiesImages/Moons/Ariel.jpg", AlternativeText = "Ariel" };
            BodyImage callisto = new BodyImage() { Url = "/Content/BodiesImages/Moons/Callisto.jpg", AlternativeText = "Callisto" };
            BodyImage calypso = new BodyImage() { Url = "/Content/BodiesImages/Moons/Calypso.png", AlternativeText = "Calypso" };
            BodyImage charon = new BodyImage() { Url = "/Content/BodiesImages/Moons/Charon.jpg", AlternativeText = "Charon" };
            BodyImage deimos = new BodyImage() { Url = "/Content/BodiesImages/Moons/Deimos.jpg", AlternativeText = "Deimos" };
            BodyImage dione = new BodyImage() { Url = "/Content/BodiesImages/Moons/Dione.jpg", AlternativeText = "Dione" };
            BodyImage enceladus = new BodyImage() { Url = "/Content/BodiesImages/Moons/Enceladus.jpg", AlternativeText = "Enceladus" };
            BodyImage epimetheus = new BodyImage() { Url = "/Content/BodiesImages/Moons/Epimetheus.jpg", AlternativeText = "Epimetheus" };
            BodyImage europa = new BodyImage() { Url = "/Content/BodiesImages/Moons/Europa.jpg", AlternativeText = "Europa" };
            BodyImage ganymede = new BodyImage() { Url = "/Content/BodiesImages/Moons/Ganymede.jpg", AlternativeText = "Ganymede" };
            BodyImage hyperion = new BodyImage() { Url = "/Content/BodiesImages/Moons/Hyperion.jpg", AlternativeText = "Hyperion" };
            BodyImage iapetus = new BodyImage() { Url = "/Content/BodiesImages/Moons/Iapetus.jpg", AlternativeText = "Iapetus" };
            BodyImage io = new BodyImage() { Url = "/Content/BodiesImages/Moons/Io.jpg", AlternativeText = "Io" };
            BodyImage lalune = new BodyImage() { Url = "/Content/BodiesImages/Moons/LaLune.jpg", AlternativeText = "LaLune" };
            BodyImage mimas = new BodyImage() { Url = "/Content/BodiesImages/Moons/Mimas.jpg", AlternativeText = "Mimas" };
            BodyImage nix = new BodyImage() { Url = "/Content/BodiesImages/Moons/Nix.jpg", AlternativeText = "Nix" };
            BodyImage oberon = new BodyImage() { Url = "/Content/BodiesImages/Moons/Oberon.jpg", AlternativeText = "Oberon" };
            BodyImage phobos = new BodyImage() { Url = "/Content/BodiesImages/Moons/Phobos.jpg", AlternativeText = "Phobos" };
            BodyImage prometheus = new BodyImage() { Url = "/Content/BodiesImages/Moons/Prometheus.jpg", AlternativeText = "Prometheus" };
            BodyImage rhea = new BodyImage() { Url = "/Content/BodiesImages/Moons/Rhea.jpg", AlternativeText = "Rhea" };
            BodyImage titan = new BodyImage() { Url = "/Content/BodiesImages/Moons/Titan.jpg", AlternativeText = "Titan" };
            BodyImage titania = new BodyImage() { Url = "/Content/BodiesImages/Moons/Titania.jpg", AlternativeText = "Titania" };
            BodyImage triton = new BodyImage() { Url = "/Content/BodiesImages/Moons/Triton.jpg", AlternativeText = "Triton" };
            BodyImage umbriel = new BodyImage() { Url = "/Content/BodiesImages/Moons/Umbriel.jpg", AlternativeText = "Umbriel" };

            //asteroids
            BodyImage asbolus = new BodyImage() { Url = "/Content/BodiesImages/Asteroids/Asbolus.jpg", AlternativeText = "Asbolus" };
            BodyImage ceres = new BodyImage() { Url = "/Content/BodiesImages/Asteroids/Ceres.jpg", AlternativeText = "Ceres" };
            BodyImage chiron = new BodyImage() { Url = "/Content/BodiesImages/Asteroids/Chiron.jpg", AlternativeText = "Chiron" };
            BodyImage hector = new BodyImage() { Url = "/Content/BodiesImages/Asteroids/Hector.jpg", AlternativeText = "Hector" };
            BodyImage itokawa = new BodyImage() { Url = "/Content/BodiesImages/Asteroids/Itokawa.jpg", AlternativeText = "Itokawa" };
            BodyImage ixion = new BodyImage() { Url = "/Content/BodiesImages/Asteroids/Ixion.png", AlternativeText = "Ixion" };
            BodyImage junon = new BodyImage() { Url = "/Content/BodiesImages/Asteroids/Junon.jpg", AlternativeText = "Junon" };
            BodyImage lutetia = new BodyImage() { Url = "/Content/BodiesImages/Asteroids/Lutetia.png", AlternativeText = "Lutetia" };
            BodyImage mathilde = new BodyImage() { Url = "/Content/BodiesImages/Asteroids/Mathilde.png", AlternativeText = "Mathilde" };
            BodyImage pholus = new BodyImage() { Url = "/Content/BodiesImages/Asteroids/Pholus.jpg", AlternativeText = "Pholus" };
            BodyImage quaoar = new BodyImage() { Url = "/Content/BodiesImages/Asteroids/Quaoar.jpg", AlternativeText = "Quaoar" };
            BodyImage steins = new BodyImage() { Url = "/Content/BodiesImages/Asteroids/Steins.png", AlternativeText = "Steins" };
            BodyImage toutaris = new BodyImage() { Url = "/Content/BodiesImages/Asteroids/Toutatis.jpg", AlternativeText = "Toutatis" };
            BodyImage varuna = new BodyImage() { Url = "/Content/BodiesImages/Asteroids/Varuna.png", AlternativeText = "Varuna" };
            BodyImage vesta = new BodyImage() { Url = "/Content/BodiesImages/Asteroids/Vesta.jpg", AlternativeText = "Vesta" };

            //Comets
            BodyImage neowise = new BodyImage() { Url = "/Content/BodiesImages/Comets/C2020F3(NEOWISE).jpg", AlternativeText = "NEOWISE" };
            BodyImage halley = new BodyImage() { Url = "/Content/BodiesImages/Comets/Halley.jpg", AlternativeText = "Halley" };
            BodyImage hyakutake = new BodyImage() { Url = "/Content/BodiesImages/Comets/Hyakutake.jpg", AlternativeText = "Hyakutake" };
            BodyImage levy = new BodyImage() { Url = "/Content/BodiesImages/Comets/Levy.png", AlternativeText = "Levy" };

            List<BodyImage> bodyImages = new List<BodyImage>() { sun,levy,hyakutake,halley,neowise,vesta,varuna,toutaris,steins,quaoar,pholus,mathilde,lutetia,junon,ixion,itokawa,
            hector,chiron,ceres,asbolus,umbriel,triton,titan,titania,rhea,prometheus,phobos,oberon,nix,mimas,lalune,io,iapetus,hyperion,ganymede,europa,epimetheus,enceladus,dione,deimos,
            charon,calypso,callisto,ariel,amalthea,adrastea,venus,uranus,saturn,pluto,neptune,mercury,mars,jupiter,earth};

            db.BodyImages.AddRange(bodyImages);
            db.SaveChanges();
            //Planets
            var ur = db.Planets.Where(x => x.PlanetId == 1).SingleOrDefault();
            ur.BodyImages.Add(uranus);
            var ne = db.Planets.Where(x => x.PlanetId == 2).SingleOrDefault();
            ne.BodyImages.Add(neptune);
            var ju = db.Planets.Where(x => x.PlanetId == 3).SingleOrDefault();
            ju.BodyImages.Add(jupiter);
            var ma = db.Planets.Where(x => x.PlanetId == 4).SingleOrDefault();
            ma.BodyImages.Add(mars);
            var me = db.Planets.Where(x => x.PlanetId == 5).SingleOrDefault();
            me.BodyImages.Add(mercury);
            var sa = db.Planets.Where(x => x.PlanetId == 6).SingleOrDefault();
            sa.BodyImages.Add(saturn);
            var ea = db.Planets.Where(x => x.PlanetId == 7).SingleOrDefault();
            ea.BodyImages.Add(earth);
            var ve = db.Planets.Where(x => x.PlanetId == 8).SingleOrDefault();
            ve.BodyImages.Add(venus);

            uranus.Planet = ur;
            neptune.Planet = ne;
            jupiter.Planet = ju;
            mars.Planet = ma;
            mercury.Planet = me;
            saturn.Planet = sa;
            earth.Planet = ea;
            venus.Planet = ve;

            //Moons
            var ad = db.Moons.Where(x => x.MoonId == 17).SingleOrDefault();
            var am = db.Moons.Where(x => x.MoonId == 7).SingleOrDefault();
            var ar = db.Moons.Where(x => x.MoonId == 127).SingleOrDefault();
            var cali = db.Moons.Where(x => x.MoonId == 6).SingleOrDefault();
            var caly = db.Moons.Where(x => x.MoonId == 78).SingleOrDefault();
            var dei = db.Moons.Where(x => x.MoonId == 1).SingleOrDefault();
            var dio = db.Moons.Where(x => x.MoonId == 68).SingleOrDefault();
            var ence = db.Moons.Where(x => x.MoonId == 66).SingleOrDefault();
            var epi = db.Moons.Where(x => x.MoonId == 75).SingleOrDefault();
            var eu = db.Moons.Where(x => x.MoonId == 4).SingleOrDefault();
            var gan = db.Moons.Where(x => x.MoonId == 5).SingleOrDefault();
            var hype = db.Moons.Where(x => x.MoonId == 71).SingleOrDefault();
            var iomoon = db.Moons.Where(x => x.MoonId == 3).SingleOrDefault();
            var mim = db.Moons.Where(x => x.MoonId == 65).SingleOrDefault();
            var ob = db.Moons.Where(x => x.MoonId == 130).SingleOrDefault();
            var pho = db.Moons.Where(x => x.MoonId == 1).SingleOrDefault();
            var pro = db.Moons.Where(x => x.MoonId == 80).SingleOrDefault();
            var rhe = db.Moons.Where(x => x.MoonId == 69).SingleOrDefault();
            var ti = db.Moons.Where(x => x.MoonId == 70).SingleOrDefault();
            var tit = db.Moons.Where(x => x.MoonId == 129).SingleOrDefault();
            var trit = db.Moons.Where(x => x.MoonId == 154).SingleOrDefault();
            var um = db.Moons.Where(x => x.MoonId == 128).SingleOrDefault();

            adrastea.Moon = ad;
            amalthea.Moon = am;
            ariel.Moon = ar;
            callisto.Moon = cali;
            calypso.Moon = caly;
            deimos.Moon = dei;
            dione.Moon = dio;
            enceladus.Moon = ence;
            epimetheus.Moon = epi;
            europa.Moon = eu;
            ganymede.Moon = gan;
            hyperion.Moon = hype;
            io.Moon = iomoon;
            mimas.Moon = mim;
            oberon.Moon = ob;
            phobos.Moon = pho;
            prometheus.Moon = pro;
            rhea.Moon = rhe;
            titan.Moon = ti;
            titania.Moon = tit;
            triton.Moon = trit;
            umbriel.Moon = um;

            //Asteroids
            var asb = db.Asteroids.Where(x => x.AsteroidId == 37).SingleOrDefault();
            var cer = db.Asteroids.Where(x => x.AsteroidId == 1).SingleOrDefault();
            var chi = db.Asteroids.Where(x => x.AsteroidId == 26).SingleOrDefault();
            var hec = db.Asteroids.Where(x => x.AsteroidId == 11).SingleOrDefault();
            var ito = db.Asteroids.Where(x => x.AsteroidId == 32).SingleOrDefault();
            var ixi = db.Asteroids.Where(x => x.AsteroidId == 29).SingleOrDefault();
            var jun = db.Asteroids.Where(x => x.AsteroidId == 14).SingleOrDefault();
            var lut = db.Asteroids.Where(x => x.AsteroidId == 16).SingleOrDefault();
            var mat = db.Asteroids.Where(x => x.AsteroidId == 17).SingleOrDefault();
            var phol = db.Asteroids.Where(x => x.AsteroidId == 9).SingleOrDefault();
            var qu = db.Asteroids.Where(x => x.AsteroidId == 6).SingleOrDefault();
            var ste = db.Asteroids.Where(x => x.AsteroidId == 7).SingleOrDefault();
            var tout = db.Asteroids.Where(x => x.AsteroidId == 5).SingleOrDefault();
            var varu = db.Asteroids.Where(x => x.AsteroidId == 38).SingleOrDefault();
            var ves = db.Asteroids.Where(x => x.AsteroidId == 39).SingleOrDefault();

            asbolus.Asteroid = asb;
            ceres.Asteroid = cer;
            chiron.Asteroid = chi;
            hector.Asteroid = hec;
            itokawa.Asteroid = ito;
            ixion.Asteroid = ixi;
            junon.Asteroid = jun;
            lutetia.Asteroid = lut;
            mathilde.Asteroid = mat;
            pholus.Asteroid = phol;
            quaoar.Asteroid = qu;
            steins.Asteroid = ste;
            toutaris.Asteroid = tout;
            varuna.Asteroid = varu;
            vesta.Asteroid = ves;

            //Comets
            var neo = db.Comets.Where(x => x.CometId == 4).SingleOrDefault();
            var hyu = db.Comets.Where(x => x.CometId == 2).SingleOrDefault();
            var hal = db.Comets.Where(x => x.CometId == 3).SingleOrDefault();
            var lev = db.Comets.Where(x => x.CometId == 1).SingleOrDefault();

            neowise.Comet = neo;
            hyakutake.Comet = hyu;
            halley.Comet = hal;
            levy.Comet = lev;

            //Star
            var s = db.Stars.SingleOrDefault();
            sun.Star = s;
            #endregion
        }
    }
}
