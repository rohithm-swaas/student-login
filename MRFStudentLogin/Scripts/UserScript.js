var edit = 0;
var Userid = 0;



$(document).ready(function () {
  
    loadData();
});

function loadData() {
 
    $.ajax({
        
        url: "/User/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            var html = '';
            $.each(result, function (key, item) {


                html += '<tr>';
              
                html += '<td><a href="#" onclick="getedit(' + item.id + ')">Edit</a > | <a href="#" onclick="Delete(' + item.id + ')">Delete</a></td > ';
                //html += '<td>' + item.id + '</td>';
                html += '<td>' + item.username + '</td>';
                html += '<td>' + item.positionName + '</td>';
                html += '<td>' + item.Vacancy_for + '</td>';
                html += '<td>' + item.Territotry + '</td>';

                html += '</tr>';
            });
            $('#tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    });

}
function Delete(id) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/User/Delete/" + id,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}
function getedit(id) {
    edit = 1;
    window.location = "/MRFLogin/Edit?id=" + id + "&edit=" + edit;
}

function getbyID(id) {
   
    Userid = id;
    $.ajax({
        url: "/User/GetbyID/" + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#id').val(result.id);
            $('#PositionName').val(result.PositionName);
            $('#CreatedBy').val(result.Created_by);
         

            
            var createddate = result.CreatedDate;
            var date = new Date(parseInt(createddate.substr(6)));
            $('#CreatedDate').val(date.toISOString().substring(0, 10));

            var beforedate = result.PositionFilledBefore;
            var positionfilledbeforedate = new Date(parseInt(beforedate.substr(6)));
            $('#PositionFilledBefore').val(positionfilledbeforedate.toISOString().substring(0, 10));

            $('input:radio[id="Vacantfor"][value=' + result.VacancyFor + ']').attr('checked', true);
            $('input:radio[id="VacentType"][value=' + result.VacancyType + ']').attr('checked', true);

           
            $('#Territotry').val(result.Territotry);
            $('#DivisionName').val(result.DivisionName);
            $('#MinExp').val(result.MinExp);
            $('#MaxExp').val(result.MaxExp);
            $('#MinCTCPerAnnum').val(result.MinCTCPerAnnum);
            $('#MaxCTCPerAnnum').val(result.MaxCTCPerAnnum);
            $('#AdditionalRequirement').val(result.AdditionalRequirement);


           
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}


function Update() {
   
    var MRFuser = {
        id: Userid,
        PositionName: $('#PositionName').val(),
        Createdby: $('#CreatedBy').val(),
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
       
        url: "/User/Update",
        
        data: JSON.stringify(MRFuser),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#result').html('Record Updated Successfully!');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


     



























   