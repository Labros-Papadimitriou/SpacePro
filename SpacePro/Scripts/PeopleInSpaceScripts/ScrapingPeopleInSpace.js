const PORT = process.env.PORT || 9000;
const express = require("express");
const axios = require("axios");
const cheerio = require("cheerio");
const { response } = require("express");
const res = require("express/lib/response");

const app = express();
const sites = [
    {
        name: "howmanypeopleareinspacerightnow",
        address:
            "https://www.howmanypeopleareinspacerightnow.com/",
        base: "",
    }
];
const people = [];
sites.forEach((site) => {
    axios
        .get(site.address)
        .then((response) => {
            const html = response.data;
            const $ = cheerio.load(html);
            $('a:contains("wikipedia")', html).each(function () {
                const name = $(this).children().find('.item').children().find('.person-name').children().first().text();
                const fieldOfWork = $(this).children().find('.item').children().find('.person-name').children()[1].text();
                const daysInSpace = $(this).children().find('.item').children().find('.person-days').children().first().text();
                people.push({
                    name,
                    fieldOfWork: fieldOfWork,
                    daysInSpace: daysInSpace,
                });
            });
        })
        .catch((err) => console.log(err));
});
app.get("/", (req, res) => {
    res.json("Welcome to my People In Space API");
});
app.get("/people", (req, res) => {
    res.json(people);
});


app.listen(PORT, () => console.log(`server running on PORT ${PORT}`));