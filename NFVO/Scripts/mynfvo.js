$(function () {
    $("#topology_tab_network_ul").hide();
    $("#topology_tab_nfvo_ul").hide();

    $("#topology_tab_network").click(function () {
        $("#topology_tab_network_ul").slideToggle("fast");
    });

    $("#topology_tab_nfvo").click(function () {
        $("#topology_tab_nfvo_ul").slideToggle("fast");
    });
});