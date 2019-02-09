$(function () {

    var selected;

    $(".content > div").click(function () {
        // get selected field and change colour
        selected = $(this);
        $(".content > div").css('background', 'transparent');
        $(this).css('background-color', 'lightblue');
        $('#menu').popup('open', { positionTo: selected });
    });

    $("#create").click(function () {
        $('#menu').popup('close');

        setTimeout(function () {
            $('#createApp').popup('open', { positionTo: selected });
        }, 500);
    });

    $("#submit").click(function () {
        // get user input
        var userInput = $('#text').val();

        $(selected).append('<img id="icon" src="images/icon.png" />')

        // adds data to selected fields array if exists, if not create array
        if ($(selected).data('text')) {
            $(selected).data('text').push(userInput);
        } else {
            $(selected).data('text', [userInput]);
        }
        // clear text field
        $('#text').val('');
        $('#createApp').popup('close');

        return false;
    });

    $("#view").click(function () {
        $('#menu').popup('close');

        setTimeout(function () {
            $('#viewApp').popup('open', { positionTo: selected });
        }, 500);

        if ($(selected).data("text")) {
            $('#appointments').html('<h3>Appointments</h3><ol></ol>');
            // add appointments to list and give them an index
            $(selected).data("text").forEach(function (apps, index) {
                $("#appointments > ol").append('<li data-index=' + index + '>' + apps + '<a class="delete" href=""> Delete</a>' + '</li>');
            });

            $(".delete").click(function () {
                // remove appointment from list
                $(this).parent().remove();
                // remove appointment from array
                $(selected).data('text').splice($(this).parent().attr('data-index'), 1);
                //remove image from box
                $(selected).find('img').first().remove();
                //if array is empty remove array
                if (!$(selected).data('text').length) {
                    $(selected).data('text', null);
                }
            });
        } else {
            $("#appointments").text("No Appointments");
        }
    });


});