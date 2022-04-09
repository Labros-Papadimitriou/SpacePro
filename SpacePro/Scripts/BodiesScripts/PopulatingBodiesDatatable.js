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
                data: "VolValue", render: function (vol) {
                    return vol != null ? vol : "No given volume";
                }
            },
            {
                data: "MassValue", render: function (mass) {
                    return mass != null ? mass : "No given mass";
                }
            },
            {
                data: "Dimension", render: function (dim) {
                    return dim != null ? dim : "No given dimension";
                }
            },
            {
                data: "DiscoveredBy", render: function (name) {
                    return name != null ? name : "No given name";
                }
            },
            {
                data: "DiscoveryDate", render: function (date) {
                    if (date != null) {
                        let mydate = moment.utc(date);
                        return mydate.format('DD-MM-YYYY');
                    }
                    else {
                        return "No given date";
                    }
                }
            }

        ],
        initComplete: function () {
            // Apply the search
            this.api().columns().every(function () {
                var that = this;

                $('input', this.footer()).on('keyup change clear', function () {
                    if (that.search() !== this.value) {
                        that
                            .search(this.value)
                            .draw();
                    }
                });
            });
        }
    });
    $('#bodiesTable tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" class="bodiesTable-input" placeholder="Search ' + title + '" />');
    });
});