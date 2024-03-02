$(document).ready(function () {
    $("#rightNCDs option").prop("selected", true);
    $('#rightAllergies option').prop("selected", true);

    $("#addNCDButton").on('click', function (e) {
        e.preventDefault();
        let selectedItems = $("#leftNCDs option:selected");
        selectedItems.detach().appendTo("#rightNCDs");
    });

    $("#removeNCDButton").on('click', function (e) {
        e.preventDefault();
        let selectedItems = $("#rightNCDs option:selected");
        selectedItems.detach().appendTo("#leftNCDs");
        $("#rightNCDs option").prop("selected", true);
    });

    $("#addAlButton").on('click', function (e) {
        e.preventDefault();
        let selectedItems = $("#leftAllergies option:selected");
        selectedItems.detach().appendTo("#rightAllergies");
    });

    $("#removeAlButton").on('click', function (e) {
        e.preventDefault();
        let selectedItems = $("#rightAllergies option:selected");
        selectedItems.detach().appendTo("#leftAllergies");
        $('#rightAllergies option').prop("selected", true);
    });

});
