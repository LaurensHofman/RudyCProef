$(document).ready(function () {
    $('[data-toggle="popover"][data-trigger="click"]').popover({
        delay: { show: "0", hide: "0" }
    });

    $('[data-toggle="popover"][data-trigger="hover"]').popover({
        delay: { show: "800", hide: "200"}
    });
});