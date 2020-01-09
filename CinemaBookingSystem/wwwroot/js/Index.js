var TicketId = [];
var UnBookTickets = [];

//Function For Open The UserInformation Dialog From Book Now Button
function BookingTicket() {
  if (TicketId.length !== 0) {
        UserInfoDialogClean();
        $("#SelectedTicketNumber").text("You have picked these seat number " + TicketId);
        $('#UserInformation').modal('show');
  } else {
      swal({
          title: "Not Selected!",
          text: "Please Select Any Ticket!!",
          type: "warning",
          showCancelButton: true,
          confirmButtonClass: "btn-danger",
          confirmButtonText: "OK",
          cancelButtonText: "Close",
          closeOnConfirm: false,
          closeOnCancel: false
      },
          function (isConfirm) {
              if (isConfirm) {
                  window.location.href = "/Cinema/Index";
              } else {
                  window.location.href = "/Cinema/Index";
              }
          });
  }
   
}

//Function For Clean The UserInformation Dialog
function UserInfoDialogClean() {
    $("#Name").val("");
    $("#Email").val("");
}

//Funtion For Check Seat Status And Select For Ticket Booked or UnBooked
function SeatStatus(SeatNumber, BookingStatus) {
    if (BookingStatus === 0) {
        if (TicketId.includes(SeatNumber)) {
            TicketId = jQuery.grep(TicketId, function (value) {
                return value !== SeatNumber;
            });
            $("#btn_" + SeatNumber).css("background-color", "grey");
        } else {
            TicketId.push(SeatNumber);
            $("#btn_" + SeatNumber).css("background-color", "coral");
        }

    } else {

        $("#SecretKeyInformation").modal('show');
        $("#NumberSeat").val(SeatNumber);
    }

}


//Function For Ajax Calling Book The Seat Basis Of Selected Seat 
function BookNow() {
    var UserName = $("#Name").val();
    var Email = $("#Email").val();

    if (UserName === "" && Email === "") {

        $("#ErrorUserMsg").text("Please Filled This User Name Field").css("color", "red");
        $("#ErrorEmailMsg").text("Please Filled This Email Field").css("color", "red");
        return false;
    }

    var RequestData = { "UserName": UserName, "Email": Email, "SeatNumber": TicketId };
    $.ajax({
        type: "POST",
        url: "/Cinema/BookTicket/",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(RequestData),
        dataType: "json",
        success: function (data) {
            if (data === 1) {
                swal({
                    title: "Booked!!",
                    text: "Your Ticket Has Been Booked",
                    type: "success",
                    showCancelButton: true,
                    confirmButtonClass: "btn-danger",
                    confirmButtonText: "OK",
                    cancelButtonText: "Close",
                    closeOnConfirm: false,
                    closeOnCancel: false
                },
                    function (isConfirm) {
                        if (isConfirm) {
                            window.location.href = "/Cinema/Index";
                        } else {
                            window.location.href = "/Cinema/Index";
                        }
                    });

            } else {
                swal({
                    title: "Already Booked Ticket !!",
                    text: "This Ticket is Already Booked,Try With New One",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonClass: "btn-danger",
                    confirmButtonText: "OK",
                    cancelButtonText: "Close",
                    closeOnConfirm: false,
                    closeOnCancel: false
                },
                    function (isConfirm) {
                        if (isConfirm) {
                            window.location.href = "/Cinema/Index";
                        } else {
                            window.location.href = "/Cinema/Index";
                        }
                    });
            }
        },

        failure: function (data) {
            console.log(data.responseText);
        },
        error: function (data) {
            console.log(data.responseText);
        }

    });

}

//Function For Ajax Call For Check An Enter Secret Key  
function KeyCheck() {

    var SecretKeyVal = $("#secretCode").val();

    if (SecretKeyVal === "") {
        $("#ErrorCodeMsg").text("Please Fill This Box").css("color", "red");
    }
    var TicketNumber = $("#NumberSeat").val();
    //$("#btn_" +TicketNumber).trigger('click');

    var RequestData = { "SecretCode": SecretKeyVal, "TicketNumber": TicketNumber };
        $.ajax({
        type: "POST",
        url: "/Cinema/CheckSecretCode/",
        data: { "SecretCode": SecretKeyVal, "TicketNumber": TicketNumber },
        dataType: "json",
            success: function (data) {
                if (data === true) {

                    $("#WrongSecretCode").text("");
                    $("#seatNumber").text(TicketNumber);
                    $("#SeatDetails").show();
                    $("#WrongSecretCode").text("");

                } else {
                    $("#seatNumber").text(TicketNumber);
                    $("#SeatDetails").hide();
                    $("#WrongSecretCode").text("Please Enter Correct Secret Code");
                }
            },

        failure: function (data) {
            console.log(data.responseText);
        },
        error: function (data) {
            console.log(data.responseText);
        }

    });

}

//Function For Ajax Calling To UnBook Ticket Basis Of Selected Seat  
function Unbook() {
      swal({
            title: "Are you sure?",
            text: "Are you sure you want to unbook this ticket?",
            type: "warning",
            showCancelButton: true,
            showCloseButton: true,
            confirmButtonClass: "btn-danger",
            confirmButtonText: "Yes!",
            cancelButtonText: "No, cancel it!",
            closeOnConfirm: false,
            closeOnCancel: false

        },
            function (isConfirm) {
                if (isConfirm) {
                  $.ajax({
                        type: "POST",
                        url: "/Cinema/UnBookTicket/",
                        data: { "SeatNumber": $("#NumberSeat").val()},
                        dataType: "json",
                        success: function (data) {
                            if (data===1) {
                                swal({
                                    title: "Cancelled",
                                    text: "You Ticket Has Been Cancelled",
                                    type: "success",
                                    showCancelButton: true,
                                    showCloseButton: true,
                                    confirmButtonClass: "btn-danger",
                                    confirmButtonText: "Ok!",
                                    cancelButtonText: "Close!",
                                    closeOnConfirm: false,
                                    closeOnCancel: false

                                },
                                    function (isConfirm) {
                                        if (isConfirm) {
                                            window.location.href = "/Cinema/Index";
                                        } else {
                                            window.location.href = "/Cinema/Index";
                                        }
                                    });
                            }
                            
                        },

                        failure: function (data) {
                            console.log(data.responseText);
                        },
                        error: function (data) {
                            console.log(data.responseText);
                        }

                    });

                } else {
                    window.location.href = "/Cinema/Index";
                }
            });
}

//Function For Close Dialog
function CloseDialog() {
    $("#SeatDetails").hide();
    $("#seatNumber").text("");
}

//Function For Clean UserDialog

function ClearUserDialog() {
    $("#ErrorUserMsg").text("");

    $("#ErrorEmailMsg").text("");
    $.each(TicketId, function (index, value) {
        $("#btn_" + value).css("background-color", "grey");
    });
    TicketId = [];
    $("#SelectedTicketNumber").text("");

}

$('#secretCode').keyup(function () {
    $("#WrongSecretCode").text("");
});