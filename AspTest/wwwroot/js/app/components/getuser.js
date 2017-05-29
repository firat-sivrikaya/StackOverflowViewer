define(['knockout', 'postman', 'jquery'], function (ko, postman, jquery) { // needed fro require modules
    return function (params) { // needed for knockout components
        
        //declaration des variables
        /*idpost, creatindate, score, body, title, closeddate, posttypeid accepted anserid, ownerid*/

//        let names = ko.observableArray();
//        let message = ko.observable();
        var lookedforid = 17394734;
        let id = ko.observable();
        let displayedName = ko.observable();
        let url = ko.observable();
        let creationdate = ko.observable();
        let location = ko.observable();
        let age = ko.observable();
        //retrieve function
        $.ajax({
                url: 'http://localhost:5000/api/user/' + lookedforid,
                type: "GET",
                datatype: "json",
                processData:false,
                contentType: "application/json; charset=utf-8",
                success: function (res){
                    //recuperer l objet et le recup
                    id(res.Id);
                    displayedName(res.DisplayedName);
                    creationdate(res.CreationDate);
                    url(res.Url);
                    location(res.Location);
                    age(res.Age);
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
            id,
            creationdate,
            displayedName,
            url,
            location,
            age,
        };
    };
});
