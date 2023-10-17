//$("#btn_submit").click(function () {
//    alert("The paragraph was clicked.");
//});

$("#btn_submit").click(function () {

    var Title = $('#Title').val();
    var Author = $('#Author').val();
    var Description = $('#Description').val();
    var Category = $('#Category').val();
    var Language = $('#Language').val();
    var TotalPages = $('#TotalPages').val();
    var Address = $('#Address').val();
    var CreatedOn = $('#CreatedOn').val();
    var UpdatedOn = $('#UpdatedOn').val();
    var ImageFile = $("#ImageFile").val();

    $.ajax({
        type: "Post",
        url: "/Book/AddNewBook",
        cache: false,
        data: { "Title": Title, "Author": Author, "Description": Description, "Category": Category, "Language": Language, "Address": Address, "TotalPages": TotalPages, "CreatedOn": CreatedOn, "UpdatedOn": UpdatedOn, "ImageFile": ImageFile },
        datatype: 'application/json',
        success: function () {
            console.log(data);
        },
        error: function (err) {
            console.log(err);
        }
    })
});