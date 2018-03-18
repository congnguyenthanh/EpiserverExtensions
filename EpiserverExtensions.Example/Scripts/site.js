$(document).ready(function () {
    var page = 1;

    $('#searchForm').submit(function (e) {
        e.preventDefault();

        fetch();
    });

    function fetch() {
        $.ajax({
            method: "POST",
            url: "/en/Listing/Search",
            data: JSON.stringify({
                ContentId: parseInt($('#contentId').val()),
                SearchText: $('#keywordSearch').val(),
                Page: page,
            }),
            dataType: "html",
            contentType: "application/json",
            success: function (data) {
                $('.data-result').append(data);
                page++;
            },
        });
    }
});