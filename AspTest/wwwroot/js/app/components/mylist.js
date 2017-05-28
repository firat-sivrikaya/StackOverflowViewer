define(['knockout', 'postman', 'jquery'], function (ko, postman, jquery) { // needed fro require modules
    return function (params) { // needed for knockout components
        let names = ko.observableArray();
        let urls = ko.observableArray();
        let message = ko.observable();
        let selectedName = ko.observable();
        
        $.ajax({
                url: 'http://localhost:5000/api/post',
                type: "GET",
                datatype: "json",
                processData:false,
                contentType: "application/json; charset=utf-8",
                success: function (res){
                    for(var i = 0; i < 5; i++)
                    {
                        var elem = {
                            title: res.result[i].title,
                            url: res.result[i].url
                        };
                        
                        names.push(elem);
                        //urls.push(res.result[i].url);
                    }
                    //names(res.result[0].title);
                    console.log("Success!!");
                },
                failure: function (result){
                    console.log("Error retrieving");
                }
        });
        
        let selectName = function (element) {
            console.log(element);
            selectedName(element);
        }
        
        let isSelected = function(name) {
            return name === selectedName();
        };
        postman.subscribe("someEvent", function (data) {
            message(data.msg);
        });

        return {
            names,
            message,
            selectName,
            selectedName,
            isSelected,
            urls
        };
    };
});