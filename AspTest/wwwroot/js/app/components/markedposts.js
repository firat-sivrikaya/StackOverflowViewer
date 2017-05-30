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
        
        var makecall = $.ajax({
                url: 'http://localhost:5000/api/markedpost?pageNumber='+currentPage+'&pageSize=5',
                type: "GET",
                datatype: "json",
                processData:false,
                contentType: "application/json; charset=utf-8",
                success: function (res){
                    for(var i = 0; i < 2; i++)
                    {
                        var elem = {
                            title: res.result[i].postTitle,
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
        
        var btnclick = function(){
            $(document).ready(function() {
                $("button").on("click", function(){
                    console.log("inside jquery");
                    if ($(this).text() === "Mark" )
                    {
                        console.log("mark found");
                        $(this).text("Unmark");
                        //$(this).find("span").removeClass("glyphicon-plus");
                        //$(this).find("span").addClass("glyphicon-minus");
                        return;
                    }
                    else if( $(this).text() === "Unmark" )
                    {
                        console.log("unmark found");
                        $(this).text("Mark");
                        //$(this).find("span").removeClass("glyphicon-minus");
                        //$(this).find("span").addClass("glyphicon-plus");
                        return;
                    }   
                });               
            
            console.log("button clicked");                  
            });
        };
        
        
        $("button").on("click", function(){
                console.log("inside jquery");
                if ($(this).text() === "Mark" )
                {
                    console.log("mark found");
                    $(this).text("Unmark");
                    //$(this).find("span").removeClass("glyphicon-plus");
                    //$(this).find("span").addClass("glyphicon-minus");
                    return;
                }
                /*else if( $(this).text() === "Unmark" )
                {
                    console.log("unmark found");
                    $(this).text("Mark");
                    //$(this).find("span").removeClass("glyphicon-minus");
                    //$(this).find("span").addClass("glyphicon-plus");
                    return;
                }    */ 
        });
        
        
        var btnpress = ko.observable(function(){
            $("button").on("click", function(){
                if ($(this).find("span").hasClass("glyphicon-plus") )
                {
                    console.log("plus found");
                    $(this).find("span").removeClass("glyphicon-plus");
                    $(this).find("span").addClass("glyphicon-minus");
                    return;
                }
                else if( $(this).find("span").hasClass("glyphicon-minus") )
                {
                    console.log("minus found");
                    $(this).find("span").removeClass("glyphicon-minus");
                    $(this).find("span").addClass("glyphicon-plus");
                    return;
                }     
            });            
        }, this);
                                       
        $("button").on("click", function(){
            if ($(this).find("span").hasClass("glyphicon-plus") )
            {
                console.log("plus found");
                $(this).find("span").removeClass("glyphicon-plus");
                $(this).find("span").addClass("glyphicon-minus");
                return;
            }
            else if( $(this).find("span").hasClass("glyphicon-minus") )
            {
                console.log("minus found");
                $(this).find("span").removeClass("glyphicon-minus");
                $(this).find("span").addClass("glyphicon-plus");
                return;
            }     
        });
        
        var plusMinus = ko.pureComputed(function(){
            
            
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
        
        
        

        
        $("button#postbtn").on("click", function(event){
           
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
            btnclick
        };
    };
});