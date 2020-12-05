(function () {
    var btnSend = $("#btnSend");
    var tbxMsg = $("#tbxMsg");
    var listChat = $("#listChat");
    var userName = $("#UserName").val();

    var connection = new signalR.HubConnectionBuilder()
        .withUrl("/chat")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    $(btnSend).click(function () {
        var msg = $(tbxMsg).val();

        connection.invoke('SendMessage', {
            userName: userName,
            message: msg
        });
    });

    connection.on('RecivedMessage', function (obj) {
        var htmlElement = '<li>'
            + '<span class="font-weight-bold">[' + obj.formattedTimeStamp + '] ' + obj.userName + ': </span>' + obj.message
            + '</li>';
        $(listChat).prepend(htmlElement);
        $(tbxMsg).val("");
    })

    connection.on('UserSignedIn', function (obj) {
        var htmlElement = '<li>'
            + '<span class="font-weight-bold text-success">' + obj + ' - new in the room</span>'
            + '</li>';
        $(listChat).prepend(htmlElement);
        $(tbxMsg).val("");
    })

    connection.start().then(function () {
        console.log("connection as " + userName);

        connection.invoke('SignInUser', userName);
    });
})();