define(['knockout', 'postman', 'jquery'], function (ko, postman, jquery) { // needed fro require modules
    return function (params) { // needed for knockout components
        let users = ko.observableArray();
        /*let id = ko.obervable();
        let displayedName = ko.obervable();*/
        let message = ko.observable();
        let selectedName = ko.observable();
        
        $.ajax({
                url: 'http://localhost:5000/api/User',
                type: "GET",
                datatype: "json",
                processData:false,
                contentType: "application/json; charset=utf-8",
                success: function (res){
                    for(var i = 0; i < 5; i++)
                    {
                        var user = {
                            id: res.result[i].id,
                            displayedName: res.result[i].displayedName,
                            url: res.result[i].url
                        }
                        users.push(user);
                    }
                    //names(res.result[0].title);
                    console.log("Success!!");
                },
                failure: function (result){
                    console.log("Error retrieving");
                }
        });
        
        postman.subscribe("someEvent", function (data) {
            message(data.msg);
        });

        return {
            users,
            message
        };
    };
});