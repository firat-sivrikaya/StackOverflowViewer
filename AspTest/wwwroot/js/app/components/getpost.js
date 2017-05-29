define(['knockout', 'postman', 'jquery'], function (ko, postman, jquery) { // needed fro require modules
    return function (params) { // needed for knockout components
        
        //declaration des variables
        /*idpost, creatindate, score, body, title, closeddate, posttypeid accepted anserid, ownerid*/

//        let names = ko.observableArray();
//        let message = ko.observable();
        var lookedforid = 17394734;
        let id = ko.observable();
        let creationdate = ko.observable();
        let score = ko.observable();
        let body = ko.observable();
        let title = ko.observable();
        let closeddate = ko.observable();
        let posttypeid = ko.observable();
        let posttype = ko.observable();
        let acceptedanserid = ko.observable();
        let ownerid = ko.observable();
        let url = ko.observable();
        let tag = ko.observable();
        let tagurl = ko.observable();
        let ownername = ko.observable();
        let ownerurl = ko.observable();
        //retrieve function
        $.ajax({
                url: 'http://localhost:5000/api/post/' + lookedforid,
                type: "GET",
                datatype: "json",
                processData:false,
                contentType: "application/json; charset=utf-8",
                success: function (res){
                    //recuperer l objet et le recup
                    
                    id(res.id);
                    creationdate(res.creationdate);
                    score(res.score);
                    body(res.body);
                    title(res.title);
                    closeddate(res.closeDate);
                    posttypeid(res.postTypeId);
                    if ( res.postTypeId == 1 ) posttype("Question");
                    else if (res.postTypeId == 2 ) posttype("Answer");
                    else posttype("Unknown");
                    acceptedanserid(res.acceptedAnswerId);
                    ownerid(res.ownerId);
                    url(res.url);
                    tag(res.tag);
                    tagurl(res.tagUrl);
                    ownername(res.ownerName);
                    ownerurl("http://localhost:5000/api/user/" + res.ownerId);
                    /*for(var i = 0; i < 5; i++)
                    {
                        names.push(res.result[i].title);
                    }*/
                    //names(res.result[0].title);
                    console.log("Success!!");
                    console.log(title());
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
            score,
            body,
            title,
            closeddate,
            posttypeid,
            acceptedanserid,
            ownerid,
            url,
            tag,
            tagurl,
            posttype,
            ownername,
            ownerurl
        };
    };
});

//get post: retourne un post