/// <reference path="../knockout-2.1.0.js" />

function LoginModel() {
    this.Email = ko.observable("");
    this.Password = ko.observable("");

    this.Login = function () {
        $.ajax({
            url: '/Login/Login',
            contentType: "application/json;",
            dataType: "json",
            data: { email: this.Email, password: this.Password },
            success: function (json, status, x) {
                //ON SUCCESS
                if (json.Success == true) {
                    console.log("success");
                    window.location.href = '/ClientList';
                }
                else {
                    console.log("error");
                }
            }
        });
    }
}

//GOOOOO
ko.applyBindings(new LoginModel());