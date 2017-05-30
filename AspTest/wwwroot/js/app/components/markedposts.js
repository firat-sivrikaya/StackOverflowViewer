define(['knockout', 'postman', 'jquery'], function (ko, postman, $) { // needed fro require modules
    return function (params) { // needed for knockout components
        let names = ko.observableArray();
        let urls = ko.observableArray();
        let message = ko.observable();
        let selectedName = ko.observable();
        let currentPage = 1;
        let prevPage = 0;
        let nextPage = 2;
        var nextPageNav = function(){
            currentPage = nextPage;
            nextPage++;
            prevPage++;
            console.log("Get to next page");
            //location.reload();
        };
        var prevPageNav = function(){
            currentPage = prevPage;
            nextPage--;
            prevPage--;
            console.log("Get to prev page");
            //location.reload();
        };
        
        var makecall = function (){
            names.removeAll();
            $.ajax({
                url: 'http://localhost:5000/api/markedpost?pageNumber='+currentPage+'&pageSize=5',
                type: "GET",
                datatype: "json",
                processData:false,
                contentType: "application/json; charset=utf-8",
                success: function (res){
                    for(var i = 0; i < res.totalMarked; i++)
                    {
                        var elem = {
                            id: res.result[i].id,
                            title: res.result[i].postTitle,
                            url: res.result[i].url,
                            notes: res.result[i].notes
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
            });//end of ajax get
        };//end of makecall
        
        makecall();
        
        
        var markpostclick = $("#markpostform").submit( function(event) {
            event.preventDefault();
            // Get the form data
            var values = $(this).serializeArray();
            // values[0].value : postid
            // values[1].value : method (POST, PUT, DELETE)
            // values[2].value : notes
            console.log(values[0].value);
            console.log(values[1].value);
            console.log(values[2].value);
            
            var jsonData= {"id": values[0].value, "notes": values[2].value };  
            
            if ( values[1].value === "POST"){
                console.log("Request made: " + values[1].value);
                var request = $.ajax({
                  url: "http://localhost:5000/api/markedpost",
                  type: values[1].value,
                  data: JSON.stringify({
                      id: values[0].value,
                      notes: values[2].value
                  }),
                  contentType: 'application/json; charset=utf-8',
                  error: function(e){
                      console.log(e);
                  }
                });
            }
            else{
                console.log("Request made: " + values[1].value);
                var request = $.ajax({
                  url: "http://localhost:5000/api/markedpost/" + values[0].value,
                  type: values[1].value,
                  data: JSON.stringify({
                      id: values[0].value,
                      notes: values[2].value
                  }),
                  contentType: 'application/json; charset=utf-8',
                  error: function(e){
                      console.log(e);
                  }
                });   
            }
            
            // Refresh the table
            makecall();
   
            
            /*
            var settings = {
              "async": true,
              "crossDomain": true,
              "url": "http://localhost:5000/api/markedpost",
              "type": values[1].value,
              "datatype": "json",
              "headers": {
                "content-type": "application/json; charset=utf-8",
                "cache-control": "no-cache"
              },
              "processData": false,
              "data": {
                "id" : values[0].value,
                "notes": values[2].value
              },
              "success" : "Successful!",
              "failure" : "Failed!"
            }

            $.ajax(settings).done(function (response) {
              console.log(response);
            });*/
            
            
            console.log(values);
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
            urls,
            nextPageNav,
            prevPageNav,
            makecall
        };
    };
});