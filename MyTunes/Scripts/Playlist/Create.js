$(function () {

    $("#input-track").autocomplete({
        source: function (request, response) {
            $.getJSON("/track/GetTracks",
                { name: request.term }
                , function (data) {
                    response(data);
                });
        },
        select: function (event, ui) {
            event.preventDefault();
            $("#input-track").val(ui.item.label);
            $("#hdn-track-id").val(ui.item.value);        
        },
        minLength: 3,
        open: function () {
            $(this).removeClass("ui-corner-all").addClass("ui-corner-top");
        },
        close: function () {
            $(this).removeClass("ui-corner-top").addClass("ui-corner-all");
        }
    });

    $("#add-track").on('click', function () {
        if ($("#input-track").val().trim() != '' && $("#hdn-track-id").val().trim() != '') {
            $("#tb_track").append('<tr><td data-pick="1" data-id="' + $("#hdn-track-id").val() + '">' + $("#input-track").val() + '</td><td><button type="button" class="btn btn-xs"><span class="glyphicon glyphicon-trash"></span></button></td></tr>');
            $("#hdn-track-id").val("");
            $("#input-track").val("");
        }
    
    });

    $("#tb_track").on('click', 'button.btn-xs', function (e) {
        e.preventDefault();
        $(this).parents('tr').remove();
    });

    $("#create-playlist").on('click', function () {

        var playlist = {
            Id : '1',
            Calificacion : '2',
            Nombre : $("#Nombre").val(),
            Tracks: []
        };

        $("td[data-pick='1']").each(function () {
            var idTrack = $(this).attr("data-id");
            playlist.Tracks.push({ Id: idTrack });
        });

        $.ajax(
            {
                url: "/Playlist/Create",
                type: "POST",
                data: JSON.stringify(playlist),
                success: function (data) {
                    $(".result").html(data);
                },
                dataType: "json",
                contentType: "application/json"
            });
    });

});