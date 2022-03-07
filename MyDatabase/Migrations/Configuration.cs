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

            //ArticleImage ai1 = new ArticleImage() { Name = "fermiparadox.jpg", Url = "/Content/ArticlesImages/fermiparadox.jpg", AlternativeText = "Fermi Paradox" };
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
            //    ArticleCategoryId = 7,
            //    ArticleImage = ai1
            //};
            //db.Articles.Add(a1);

            //ArticleImage ai2 = new ArticleImage() { Name = "cometsmock.jpg", Url = "/Content/ArticlesImages/cometsmock.jpg", AlternativeText = "Comets" };
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

            //ArticleImage ai3 = new ArticleImage() { Name = "lifeinmoon.jpg", Url = "/Content/ArticlesImages/lifeinmoon.jpg", AlternativeText = "lifeinmoon" };
            //db.ArticleImages.Add(ai3);

            //Article a3 = new Article()
            //{
            //    Title = "Could there be life on Jupiter’s moons?",
            //    PostDate = new DateTime(2022, 03, 07),
            //    PostLikes = 0,
            //    ShortDescription = "The search for life outside of Earth has taken many forms. Mars, our neighbouring world, looks like it was once habitable. Perhaps too Venus, despite its current hellish conditions. But in recent years, scientists’ gazes have been drawn elsewhere. What about the moons of Jupiter?",
            //    FullDescription = @"Three of Jupiter’s four largest moons are icy, and in 1998 NASA’s Galileo spacecraft detected tantalising hints of an ocean beneath one, Europa. Since then, further studies have detected signs of water plumes possibly erupting from this ocean.
            //                        The oceans under these moons are likely large, spanning the entire moons’ circumferences and extending tens of kilometres deep. But they are also trapped under tens of kilometres of ice, making studies of them very difficult.
            //                        One of our best approaches so far has been to look for the effects of salt in the oceans on their electrical conductivity by studying magnetic fields around the moons
            //                        Another important factor regarding the habitability of the moons is how much radiation from Jupiter is hitting them. Jupiter produces a lot of damaging radiation, so much that it can harm spacecraft that get too close.
            //                        One way to study this is to observe aurorae on the moons, produced when charged particles from Jupiter hit magnetic fields around them.",
            //    AuthorName = "Jonathan O’Callaghan",
            //    ArticleCategoryId = 3,
            //    ArticleImage = ai3
            //};
            //db.Articles.Add(a3);
            //db.SaveChanges();

            //ArticleImage ai4 = new ArticleImage() { Name = "asteroidsdangerous.jpg", Url = "/Content/ArticlesImages/asteroidsdangerous.jpg", AlternativeText = "asteroidsdangerous" };
            //db.ArticleImages.Add(ai4);

            //Article a4 = new Article()
            //{
            //    Title = "An asteroid headed our way is dangerous?",
            //    PostDate = new DateTime(2022, 03, 07),
            //    PostLikes = 0,
            //    ShortDescription = "There are a lot of things that pose a threat to our planet – climate change, natural disasters, and solar flares, for example. But one threat in particular often captures public imagination, finding itself popularised in books and films and regularly generating alarming headlines: asteroids.",
            //    FullDescription = @"In our solar system there are millions of space rocks known as asteroids. Ranging in size from a few metres to hundreds of kilometres, these objects are mostly left over from the formation of our planets 4.6 billion years ago. They are building blocks that didn’t quite make it into fully fledged worlds.
            //                        Asteroids and other objects that make a closest approach to our sun of less than 1.3 astronomical units (1 astronomical unit, AU, is the Earth-Sun distance) are known as near-Earth objects (NEOs). These are objects deemed to pose the greatest risk to our planet.
            //                        It is not uncommon for asteroids to hit Earth. Hundreds of meteorites reach the surface of our planet every year, most too small to be of any concern. But occasionally, large rocks can hit and cause damage. In 2013, the Chelyabinsk meteor exploded over Russia, injuring hundreds. At the extreme end of the scale, 66 million years ago, an asteroid wiped out the dinosaurs.",
            //    AuthorName = "Jonathan O’Callaghan",
            //    ArticleCategoryId = 5,
            //    ArticleImage = ai4
            //};
            //db.Articles.Add(a4);
            //db.SaveChanges();

            //ArticleImage ai5 = new ArticleImage() { Name = "asteroidsandcomets.jpg", Url = "/Content/ArticlesImages/asteroidsandcomets.jpg", AlternativeText = "asteroidsandcomets" };
            //db.ArticleImages.Add(ai5);

            //Article a5 = new Article()
            //{
            //    Title = "Asteroids and comets may be more similar?",
            //    PostDate = new DateTime(2022, 03, 07),
            //    PostLikes = 1,
            //    ShortDescription = "As anyone who has ever tried to clean a home knows, ridding yourself of dust is a Sisyphean effort. No surface stays free of it for long. It turns out that space is somewhat similar. Space is filled with interplanetary dust, which the Earth constantly collects as it plods around the sun – in orbit, in the atmosphere, and if it’s large enough, on the ground as micrometeorites.",
            //    FullDescription = @"While specimens may not be large, it turns out such dust particles are reforming scientists’ conception of asteroids and comets and are enough to reconstruct entire scenes in the history of the solar system.
            //                        Asteroids and comets are primitive bodies left over from early in solar system formation, so the more we can know about their composition, the more we know about where they formed. Those asteroids that formed in the same neighbourhood as comets tend to be closer in composition to them.
            //                        Trying to break down the asteroid-comet continuum and categorise how similar asteroids could be to comets is what Dr Pierre Beck is doing in the SOLARYS project at France’s University of Grenoble Alpes.
            //                        There are about a million asteroids registered officially and there should be many more, he explains.
            //                        ‘Traditionally, these objects have been thought of as the most primitive in the solar system. You can look at the ingredients and see what was there, how they were accreted and how they were formed a long time ago.’
            //                        Similar primordial material that formed Earth or Mars has experienced geological activity and been fundamentally changed by conditions like heat, pressure and erosion.
            //                        ‘The most primitive objects therefore don’t come to Earth in the form of rocks, but in the form of dust,’ he said. ‘While the expected (amount) of meteorites that come to Earth in a year may be 5-6 tonnes – for dust it is 40,000 tonnes.’
            //                        Using samples of interplanetary dust collected from high in our stratosphere and micrometeorites from pristine locations like Antarctica, Dr Beck is using a new method of infrared spectroscopy combined with atomic force microscopes to examine their spectra and properties on the micrometre-scale.",
            //    AuthorName = "Ethan Bilby",
            //    ArticleCategoryId = 4,
            //    ArticleImage = ai5
            //};
            //db.Articles.Add(a5);
            //db.SaveChanges();

            //ArticleImage ai6 = new ArticleImage() { Name = "mosquito.jpg", Url = "/Content/ArticlesImages/mosquito.jpg", AlternativeText = "mosquito" };
            //db.ArticleImages.Add(ai6);

            //Article a6 = new Article()
            //{
            //    Title = "Scientists get one step ahead of deadly mosquito",
            //    PostDate = new DateTime(2022, 03, 07),
            //    PostLikes = 1,
            //    ShortDescription = "Each year, nearly three-quarters of a million people die from mosquito-borne diseases, and with climate change the problem is getting worse. EU researchers are giving public health officials the tools they need to take targeted action fast.",
            //    FullDescription = @"Some of the deadliest animals have the smallest bites. It is a stark fact that every year more than a billion people succumb to diseases such as malaria, dengue, Zika and yellow fever. Each year these infections, carried and transmitted by bloodsucking mosquitos, account for some 700,000 deaths globally. Malaria, which represents more than half of these, is tragically most lethal for children aged under five.
            //                        Endemic already across sub-Saharan Africa, Southeast Asia and Latin America, there are warning signs these diseases are coming closer to home for those in Europe. Global trade and travel offer routes for mosquitoes to spread. Changing weather patterns, compounded by climate change, provide the conditions for species once consigned to history books to re-establish populations in Europe.
            //                        Global swarming
            //                        This threat is illustrated most visibly on the dashboard of the Early Warning System for Mosquito Borne Diseases (EYWA). Its charts for malaria, dengue, Zika, Chikungunya and West Nile virus all show a similar, worrying, upward trajectory. Since 2008, malaria cases across Europe have risen by 62%, dengue, Zika and Chikungunya are up by a remarkable 700%, and cases of West Nile virus spiked dramatically in 2018.
            //                        ‘The problem is really big,’ said Dr Haris Kontoes, Research Director at the Institute for Astronomy, Astrophysics, Space Applications and Remote Sensing at the National Observatory of Athens and EYWA network coordinator. ‘It was always a big problem considering that millions of people are affected worldwide, but in the last 10 years these diseases have been increasingly transmitted in Europe, even northern European countries,’ he explained.
            //                        Highlighting recent extreme flooding events, which have seen mosquito numbers swell by up to ten times in Germany, Kontoes believes our changing climate is fuelling this trend, and the problem is growing: ‘In the past, these diseases were known mainly in tropical zones, but the impact of climate change is altering ecosystems and the development of mosquito populations across Europe.’",
            //    AuthorName = "Andrew Dunne",
            //    ArticleCategoryId = 8,
            //    ArticleImage = ai6
            //};
            //db.Articles.Add(a6);
            //db.SaveChanges();

            //ArticleImage ai7 = new ArticleImage() { Name = "goldenage.jpg", Url = "/Content/ArticlesImages/goldenage.jpg", AlternativeText = "goldenage" };
            //db.ArticleImages.Add(ai7);

            //Article a7 = new Article()
            //{
            //    Title = "Is Europe entering a golden age of astronomy?",
            //    PostDate = new DateTime(2022, 03, 07),
            //    PostLikes = 0,
            //    ShortDescription = "Groundbreaking discoveries about gravitational waves, black holes, cosmic rays, neutrinos and other areas of cutting-edge astronomy may soon become more frequent due to the convergence of two major communities of astronomers in a fresh project.",
            //    FullDescription = @"Previously, Europe had two major collaborative networks for ground-based astronomy running over the past couple of decades, known as OPTICON and RadioNet. These focused on observing astronomical phenomena in separate wavelength ranges of the electromagnetic spectrum – the former at optical wavelengths, in a portion of the spectrum that includes visible light; and the latter at longer, radio wavelengths.
            //                        Now, these two domains of astronomy are uniting in a project called the OPTICON RadioNet Pilot (ORP), a consortium of astronomers from 37 institutions and 15 European countries, plus Australia and South Africa.
            //                        Referring to itself as ‘Europe’s largest astronomy network’, the initiative was set up in light of the increasing need for astronomers to have a range of skills in different domains and use complementary techniques to understand phenomena. It also brings together around 20 telescopes and telescope arrays owned by members of the consortium, with the aim of harmonising methods and tools between the two domains, and opening up physical and virtual access to facilities.
            //                        Multi-messenger age
            //                        Dr Cuby elaborated on how the need is growing to foster harmonisation between domains in the current age of so-called multi-messenger astronomy. This involves the observation of various ‘messenger’ particles – such as gravitational waves, neutrinos and cosmic rays – that can reveal different information about the same sources, potentially giving unprecedented insight into the universe and its origins.
            //                        Harmonisation is also key for time-domain astronomy, which explores how astronomical events vary over time. Events now being explored are frequently transient, with many, like fast radio bursts, lasting mere milliseconds. Capturing multiple aspects of them thus requires rapid deployment of telescopes and facilities, which can again be aided by collaboration. ‘This time-domain astronomy is going to explode in the coming years,’ said Dr Cuby. ‘This is really the golden age of astronomy.’",
            //    AuthorName = "Gareth Willmer",
            //    ArticleCategoryId = 8,
            //    ArticleImage = ai7
            //};
            //db.Articles.Add(a7);
            //db.SaveChanges();

            //ArticleImage ai8 = new ArticleImage() { Name = "plantesevolution.jpg", Url = "/Content/ArticlesImages/plantesevolution.jpg", AlternativeText = "plantesevolution" };
            //db.ArticleImages.Add(ai8);

            //Article a8 = new Article()
            //{
            //    Title = "Planetary evolution reveals a volatile history",
            //    PostDate = new DateTime(2022, 03, 07),
            //    PostLikes = 1,
            //    ShortDescription = "Just as human beings and all other living things exist in a vast number of different forms thanks to their genetic makeup, so different types of planets occur due to the chemical processes at work in the dusty regions surrounding newborn stars.",
            //    FullDescription = @"It appears that nature has a fondness for forming exoplanets – planets beyond our own Solar System. Over the last 20 years, scientists have realised that exoplanets are far more common in our corner of the cosmos and the universe in general than previously believed.
            //                        To deepen our understanding of planet formation scientists must find and observe the formation of many such systems. But watching a planet evolve in real time would take millions of years. Instead, astronomers peer into certain regions of space, piecing together like a puzzle the different clues they observe and simulating the results in the laboratory.
            //                        The most widely accepted model for planet formation, known as the nebular hypothesis, begins with a swirling disc of gas and dust – left over material from the birth of a nearby star. At some point in time, gravity triumphs over the pressure supporting this cosmic dust, which then starts to rotate, quickly collapsing under its own gravity.
            //                        This amplifies any small amount of rotation, much like how a figure skater spins faster as they draw in their arms. This causes the formation of a protoplanetary disc surrounding the young star, which then becomes a crucible for the formation of a planetary system.
            //                        Although astronomers are now well aware of how planets begin, the precise chemical processes that unfold during the formation of a new world remain elusive.
            //                        The Moon is the clue
            //                        Although most scientists believe that Earth-sized exoplanets formed gradually over the course of millions of years from a mass of gas and dust, many of the processes involved are still little understood.
            //                        Our own Moon may be able to provide some answers. In a recent study, researchers found that it has undergone melting and evaporation, explaining why important chemical elements, known as volatiles, have been significantly depleted.
            //                        ‘Volatile elements play a major role in terrestrial planets, including their ability to develop and sustain life and the geochemical properties that make each planet unique,’ said Frederic Moynier, professor at the Institut de Physique du globe de Paris at the University of Paris.",
            //    AuthorName = "Eri Markopoulou",
            //    ArticleCategoryId = 2,
            //    ArticleImage = ai8
            //};
            //db.Articles.Add(a8);
            //db.SaveChanges();

            //ArticleImage ai9 = new ArticleImage() { Name = "newasteroid.jpg", Url = "/Content/ArticlesImages/newasteroid.jpg", AlternativeText = "newasteroid" };
            //db.ArticleImages.Add(ai9);

            //Article a9 = new Article()
            //{
            //    Title = "A new, huge asteroid in the neighbourhood",
            //    PostDate = new DateTime(2022, 03, 07),
            //    PostLikes = 1,
            //    ShortDescription = "A recent discovery left astronomers pretty excited: using the SOAR Telescope in Chile, a team spotted the largest Earth trojan asteroid ever found. This type of asteroid is made of material dating back to the birth of our Solar System – and could give us clues about the building blocks of our planet. ",
            //    FullDescription = @"You might be wondering what exactly are trojan asteroids. These types of asteroids are companions, or ‘neighbours’, to a planet, sharing the same orbit of this planet around the Sun. They can be ‘parked’ in a place where the force of gravity pulling them towards the planet and pushing them away are in balance – the so-called Lagrange points.
            //                        In the case of this specific asteroid, 2020 XL5, we’re talking about an Earth trojan asteroid, as it is a companion to our Earth. 
            //                        It is the second Earth trojan asteroid found until now, and also the largest we’ve ever seen. 2020 XL5 is about 1.2 kilometres (0.73 miles) in diameter, or about three times as wide as 2010 TK7, the first asteroid of this kind found a decade ago. 2010 TK7 is less than 400 metres (or yards) across, so you can imagine how big 2020 XL5 is!
            //                        And how did astronomers find out that 2020 XL5 is actually an Earth trojan asteroid and not a simple near-Earth object? The team used previous data from the Dark Energy Survey to understand the asteroid’s orbit. Images from 2012 and 2019 gave a better idea of 2020 XL5’s path.
            //                        Astronomers believe the asteroid will not be a Trojan forever: it will remain stable where it is for another 4,000 years, and eventually it will wander through space because of a perturbation in its gravity. ",
            //    AuthorName = "M. Zamani",
            //    ArticleCategoryId = 5,
            //    ArticleImage = ai9
            //};
            //db.Articles.Add(a9);
            //db.SaveChanges();

            //ArticleImage ai10 = new ArticleImage() { Name = "cosmingammaray.jpg", Url = "/Content/ArticlesImages/cosmingammaray.jpg", AlternativeText = "cosmingammaray" };
            //db.ArticleImages.Add(ai10);

            //Article a10 = new Article()
            //{
            //    Title = "This ‘cosmic spider’ spews gamma-rays!",
            //    PostDate = new DateTime(2022, 03, 07),
            //    PostLikes = 1,
            //    ShortDescription = "A team of astronomers has just found a bright “spider” in the sky – a very unusual binary system, or a system in which two stars orbit each other, some 2,600 light-years away from us. ",
            //    FullDescription = @"This binary system is unlike almost any other because one of the stars, about to become a white dwarf, is orbiting a neutron star… that has just turned into a pulsar! Astronomers nicknamed binary systems like these “spiders” because the pulsar usually “eats” the outer parts of its neighbour as it turns into a white dwarf. 
            //                        The system – called 4FGL J1120.0-2204 – is the first example of a cosmic “spider” discovered until now. It is the second brightest source of gamma-rays ever found and scientists did not know it was a binary system until recently.
            //                        Using the 4.1-meter SOAR Telescope in Chile, a team of astronomers could get closer to a mysterious source of gamma rays they knew before but did not know exactly what it was. They then found out that it is made of a millisecond pulsar (a pulsar that twirls extremely fast, about hundreds of times per second) and a star about to become a very low-mass white dwarf. 
            //                        The strong gamma-rays and X-rays gave away the pulsar, and astronomers analysing its visible light spectrum found that light would shift from red to blue – objects that are closer to us appear bluer, while objects that are moving away from us appear redder due to the Doppler effect. This is how the astronomers found a white dwarf was orbiting a massive pulsar.
            //                        A white dwarf is born from the death of stars with a mass equal or lower than our Sun. When a star like our Sun runs out of hydrogen, it starts “burning” helium to continue with the nuclear fusion that powers the star. It then heats up and contracts, to “swell” later into a red giant. As nuclear fusion ceases, the swollen star becomes a white dwarf about the size of Earth at blistering temperatures – over 100,000 °C (180,000 °F)! It will take some two billion years for the white dwarf in our 4FGL J1120.0-2204 spider to evolve to this point.
            //                        Millisecond pulsars spin about every 10 milliseconds – resulting in hundreds of twirls every second! They get their fuel by “swallowing” matter from a neighbouring star – in this case, the one about to become a white dwarf. Millisecond pulsars “spew” gamma rays and X-rays especially when pulsar wind hits material emitted by its neighbouring star. 
            //                        The discovery could be the “missing link” to our understanding of how binary systems evolve!",
            //    AuthorName = "M. Zamani",
            //    ArticleCategoryId = 6,
            //    ArticleImage = ai10
            //};
            //db.Articles.Add(a10);
            //db.SaveChanges();

            //ArticleImage ai11 = new ArticleImage() { Name = "reusablerocket.jpg", Url = "/Content/ArticlesImages/reusablerocket.jpg", AlternativeText = "reusablerocket" };
            //db.ArticleImages.Add(ai11);

            //Article a11 = new Article()
            //{
            //    Title = "China wants astronaut launches to be reusable",
            //    PostDate = new DateTime(2022, 03, 07),
            //    PostLikes = 2,
            //    ShortDescription = "China is planning for its next-generation crew launch vehicle for missions to its space station and the moon to have a reusable first stage. ",
            //    FullDescription = @"The new rocket would allow a reusable launch option for sending astronauts or cargo to China's new Tiangong space station, while a larger version would allow China to send crew on lunar and deep space missions. 
            //                        It will also be capable of carrying a new, larger spacecraft than the Shenzhou currently used by the China National Space Administration for crewed missions, according to the China Aerospace Science and Technology Corporation (CASC), the country's main space contractor.
            //                        The rocket currently goes by the cumbersome placeholder name of 'New - Generation Manned Launch Vehicle.' After completing its launch role, the first stage will restart its engines to help it decelerate, using grid fins for guidance, much like the pioneering Falcon 9 rockets flown by SpaceX. ",
            //    AuthorName = " Andrew Jones",
            //    ArticleCategoryId = 8,
            //    ArticleImage = ai11
            //};
            //db.Articles.Add(a11);
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
