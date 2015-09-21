(function() {
    var baseUri = "/api/Configuration";

    function loadList() {
        $.ajax({
            url: baseUri,

            success: function(config) {

                var list = $("#names");
                list.empty();

                for (var i = 0; i < config.length; i++) {
                    var name = config[i].ConfigName;
                    var email = config[i].EmailAdress;
                    var hostname = config[i].HostingName;
                    var ftpusername = config[i].FtpUserName;
                    var registration = config[i].Registration;
                    var typeofhost = config[i].TypeOfHosting;
                    list.append("<dl>" + "<b>" + 'Configuration Name: ' + "</b>" + name + "</dl>");
                    list.append("<dt>" + 'EmailAdress: ' + email + "</dt>");
                    list.append("<dt>" + 'HostingName: ' + hostname + "</dt>");
                    list.append("<dt>" + 'FtpUserName: ' + ftpusername + "</dt>");
                    list.append("<dt>" + 'Registration: ' + registration + "</dt>");
                    list.append("<dt>" + 'TypeOfHosting: ' + typeofhost + "</dt>");
                }
            }
        });
    }

    loadList();
    $(document).ready(function() {
        $("#addNewBtn").on("click", postConfig);
        $("#changeBtn").on("click", putConfig);
        $("#deleteBtn").on("click", deleteItem);
    });

    function errorHandler(xhr, textStatus, error) {
        if (xhr.status == "404") {
            alert('Element not found');
        }
        else if (xhr.status == "400") {
            alert('Invalid request');
        }
        else if (xhr.status == "500") {
            alert('Server error');
        }
    }

    function postConfig() {
        var config = {};
        config.ConfigName = $("#configName").val();
        config.EmailAdress = $("#emailAdress").val();
        config.HostingName = $("#hostingName").val();
        config.FtpUserName = $("#ftpUserName").val();
        config.TypeOfHosting = $("#typeOfHosting").val();
        config.Registration = $('#checker').prop("checked");
        $.ajax({
            url: baseUri,
            type: "POST",
            data: JSON.stringify(config),
            dataType: "json",
            contentType: "application/json",
            success: function(data, textStatus, xhr) {
                var locationHeader = xhr.getResponseHeader("Location");
                loadList();
                $("#location").html("<a href='" + locationHeader + "'>Last Item</a>");

            },
            error: errorHandler,
            statusCode: {
                201: function() {
                    alert("Created.");
                },
                400: function() {
                    alert("Bad Request");
                }
            }
            
        });
    }
    function putConfig() {
        var config = {};
        config.ConfigName = $("#configNameChange").val();
        config.EmailAdress = $("#emailAdressChange").val();
        config.HostingName = $("#hostingNameChange").val();
        config.FtpUserName = $("#ftpUserNameChange").val();
        config.TypeOfHosting = $("#typeOfHostingChange").val();
        config.Registration = $('#checkerChange').prop("checked");

        $.ajax({
            url: baseUri,
            type: "PUT",
            data: JSON.stringify(config),
            dataType: "json",
            contentType: "application/json",
            success: function(data, textStatus, xhr) {
                alert('Element by name' + config.ConfigName + 'has been chaged');
                loadList();
            },

            error: errorHandler
        });
    }
    function deleteItem() {
        var stringName = $("#configDeleteName").val();

        $.ajax({
            url: "api/configuration/deleteconfig/" + stringName,
            type: "DELETE",

            success: function() { loadList() },

            error: errorHandler
        });
    }
})();