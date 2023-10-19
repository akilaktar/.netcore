//$("#btn_submit").click(function () {
//    alert("The paragraph was clicked.");
//});

$("#btn_submit").click(function () {
    if (window.FormData == undefined)
        alert("Error: FormData is undefined");

    var a = $("#File").get(0);
    var files = a.files;
    var result = files[0].name

    var Title = $('#Title').val();
    var Author = $('#Author').val();
    var Description = $('#Description').val();
    var Category = $('#Category').val();
    var Language = $('#Language').val();
    var Address = $('#Address').val();
    var TotalPages = $('#TotalPages').val();
    var CreatedOn = $('#CreatedOn').val();
    var UpdatedOn = $('#UpdatedOn').val();
    var FileName = result;
    var Files = files;
    $.ajax({
        type: "Post",
        url: "/Book/AddNewBook",
        cache: false,
        data: {
            "Title": Title, "Author": Author, "Description": Description, "Category": Category, "Language": Language, "Address": Address, "TotalPages": TotalPages, "CreatedOn": CreatedOn, "UpdatedOn": UpdatedOn, "FileName": FileName, "File": Files
        },
        datatype: 'application/json',
        success: function () {
            $("#btn_AddNewBook")[0].reset();
        },
        error: function (err) {
            console.log(err);
        }
    })
});