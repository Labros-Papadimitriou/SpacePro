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
        $(this).html('<input class="text-white bg-gray-dark-darker  border-white" type="text" placeholder="Search ' + title + '" />');
    });
});