



function Add() {

    var mrfObj = {

        PositionName: $('#PositionName').val(),
        Created_by: $('#CreatedBy').val(),
        CreatedDate: $('#CreatedDate').val(),
        PositionFilledBefore: $('#PositionFilledBefore').val(),
        VacancyFor: $('input[name="one"]:checked').val(),
        VacancyType: $('input[name="Two"]:checked').val(),
        Territotry: $('#Territotry').val(),
        DivisionName: $('#DivisionName').val(),
        MinExp: $('#MinExp').val(),
        MaxExp: $('#MaxExp').val(),
        MinCTCPerAnnum: $('#MinCTCPerAnnum').val(),
        MaxCTCPerAnnum: $('#MaxCTCPerAnnum').val(),
        AdditionalRequirement: $('#AdditionalRequirement').val(),
    };
    $.ajax({
        url: "/MRFLogin/Add",
        data: JSON.stringify(mrfObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data != null || data == 1) {
                $('#data').html('Record Saved Successfully!');
                
            }
            else {
                alert('Error in save!');
            }
        },
        
    });
}
function Details() {
    window.location ="/User/use"
}