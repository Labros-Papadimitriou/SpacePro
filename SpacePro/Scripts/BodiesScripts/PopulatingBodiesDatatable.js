$(document).ready(function () {
    $('#bodiesTable').DataTable({
        ajax: {
            url: "/Bodies/GetBodies",
            type: "GET",
            dataType: "json"
        },
        columns: [
            {
                data: "BodyType"
            },
            {
                data: "Name"
            },
            {
                data: "VolValue"
            },
            {
                data: "MassValue"
            },
            {
                data: "Dimension"
            },
            {
                data: "DiscoveredBy"
            },
            {
                data: "DiscoveryDate", render: function (date) {
                    if (date != null) {
                        let mydate = moment.utc(date);
                        return mydate.format('DD-MM-YYYY');
                    }
                    else {
                        return date;
                    }
                }
            }

        ]
    });
});