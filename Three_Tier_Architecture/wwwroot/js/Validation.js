

$(document).ready(function (e) {
    // Prevent default form submission on submit event
    $('#myForm').on("submit", function (e) {
        e.preventDefault();  // Prevent the form from being submitted via GET or POST

         //Validate each field
        var boolf = ValidateFirstName();
        var booll = ValidateLastName();
        var boole = ValidateEmail();

        // If any validation fails, show an alert and stop form submission
        if (!boolf || !booll || !boole) {
            alert('Please fix the errors before submitting.');
            return; // Don't proceed with the AJAX call if validation fails
        }

        // Call AJAX to submit the form data
        CallAjax();
    });


        //-- FirstName Validation
    $('#FirstName').on("keyup", function () {
        ValidateFirstName();
        });

        function ValidateFirstName() {
            var firstname = $("#FirstName").val();
            var regex = /^[A-Za-z]+$/;
            if (firstname === '' ) {
                $('#ErrorFirstName').text("FirstName cann't be blank").css('color', 'red');
                return false;
            } 
            if (!regex.test(firstname)) {
                $('#ErrorFirstName').text("Please enter valid FirstName").css('color', 'red');
                return false;
            } 
             else {
                $('#ErrorFirstName').text("FirstName entered sucessfully").css('color', 'green');
                return true;
            }

         }

        //-- LastName Validation

        $('#LastName').on("keyup", function () {     
        ValidateLastName();
        });

        function ValidateLastName() {
            var lastname = $("#LastName").val();
            var regex = /^[A-Za-z]+$/;
            if (lastname == '') {
                $('#ErrorLastName').text("LastName cann't be blank").css('color', 'red');
                return false;
            }
            if (!regex.test(lastname)) {
                $('#ErrorLastName').text("Please enter valid LastName").css('color', 'red');
                return false;
            } 
            else {               
                $('#ErrorLastName').text("LastName entered successfully").css('color', 'green');
                return true;
            }
           
        }

        //-- Email Validation

        $('#Email').on("keyup", function () {
        ValidateEmail();
        });

        function ValidateEmail() {
            var email = $("#Email").val();
            var emailReg = /^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$/;

            if (!emailReg.test(email)) {
                $('#ErrorEmail').text('You entered an Invalid E-Mail-address').css('color', 'red');
                return false;
            }
            else {
                $('#ErrorEmail').text('Great, you entered an valid E-Mail-address').css('color', 'green');
                return true;
                
            }
    }

    function CallAjax() {
        var formData = {
            FirstName: $('#FirstName').val(),
            LastName: $('#LastName').val(),
            Email: $('#Email').val()
        };
        console.log("FormData:", formData);

        // AJAX call to submit form data to the server

       
        $.ajax({
            url: '/Students/AddStudentPost',  // Hardcoded URL
            type: 'POST',  // Ensure the request is sent as JSON
            data: formData,   // Send the form data as a JSON string
            success: function (response) {

                console.log(response);  // Log the response

                if (response.status === 'success') {

                    // SweetAlert success message
                    Swal.fire({
                        icon: 'success',               // Icon type: success
                        title: 'Success',              // Title of the popup
                        text: response.message,        // The message returned from the server
                        showConfirmButton: false,      // Optionally hide the confirm button
                        timer: 1500                    // Optionally set a timer to auto close the alert (in ms)
                    }).then(function () {
                        // Redirect after SweetAlert closes
                        window.location.href = '/Students/StudentsList'; // Redirect to the Students List page
                    });

                  
                } else {
                    // SweetAlert error message
                    Swal.fire({
                        icon: 'error',                // Icon type: error
                        title: 'Oops...',             // Title of the popup
                        text: response.message,       // The error message returned from the server
                        showConfirmButton: true       // Show the confirm button for error
                    });
                }
            },
            error: function (xhr, status, error) {
                // SweetAlert error message for AJAX failure
                Swal.fire({
                    icon: 'error',                  // Icon type: error
                    title: 'Error',                 // Title of the popup
                    text: 'There was an error submitting the form.', // Custom error message
                    showConfirmButton: true         // Show the confirm button
                });
            }
        });

    }





    var antiForgeryToken = $('input[name="__RequestVerificationToken"]').val();

    function bindDropdown(selectedValue, antiForgeryToken) {
        $('#loadingSpinner').show();
        $.ajax({
            url: '@Url.Action("BindDropdown", "Admin")',
            type: 'GET',
            data: {
                selectedValue: selectedValue,
                __RequestVerificationToken: antiForgeryToken
            },
            success: function (data) {
                $('#claimListContainer').html(data);
                $('#searchClaimTableId').DataTable({
                    "processing": true,
                    "initComplete": function (settings, json) {
                        $('#loadingSpinner').hide();
                    }
                });
            },
            error: function () {
                alert('Failed to retrieve data.');
                $('#loadingSpinner').hide();
            }
        });
    }

    $('#ddlswticher').change(function () {
        var selectedValue = $(this).val();
        $('#loadingSpinner').show();
        bindDropdown(selectedValue, antiForgeryToken);
    });
});
