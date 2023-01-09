$(document).ready(function () {
    $('table.display').DataTable();

    $('.js-example-basic-single').select2(); 
    
});
$(document).ready(function () {

    $('#listCategory').change(function () {
        let id = $('#listCategory').val();
        console.log("ID = " + id);
        $("#result").load("/Product/LoadProduct/" + id);
    });
});