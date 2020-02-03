$(document).ready(function () {
    manageNumber.init();
});

var manageNumber =
{
    init: function () {
        this.events();

    },
    events: function () {
        $("button").click(function () {
            var inpObj = document.getElementById("txtName");
            if (!inpObj.checkValidity()) {
                document.getElementById("spnNameError").innerHTML = "This is required field please fill name.";
            }
            else {
                $("#spnNameError").html("");

            }

            var inpObj = document.getElementById("txtNumber");
            if (!inpObj.checkValidity()) {
                if (inpObj.value == "") {
                    document.getElementById("spnNumberError").innerHTML = "This is required field please fill number.";
                }
                else {
                    document.getElementById("spnNumberError").innerHTML = "Maximum number range should be 0 to 9999.";
                }
            }
            else {
                $("#spnNumberError").html("");
            }

            if ($("#spnNumberError").html() == "" && $("#spnNameError").html() == "") {
                manageNumber.methods.convertNumberToWords();
            }
        });

        $("#txtNumber").keydown(function () {
            $("#spnNumberError").html("");
        });

        $("#txtName").keydown(function () {
            $("#spnNameError").html("");
        });

    },

    methods: {
        convertNumberToWords: function () {
            var obj = {
                "Name": $("#txtName").val(),
                "Number": parseFloat($("#txtNumber").val())
            }

            $.ajax({
                type: "POST",
                url: '/api/ManageNumber/ConvertToWords',
                data: JSON.stringify(obj),
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    $("#result").html(data.data);
                },
                error: function () {
                    alert("Error while inserting data");
                }
            });
        }
    }
}

