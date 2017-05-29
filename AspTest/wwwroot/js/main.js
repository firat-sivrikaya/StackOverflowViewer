require.config({
    baseUrl: "js",
    paths: {
        knockout: "lib/knockout/dist/knockout",
        jquery: "lib/jQuery/dist/jquery.min",
        text: "lib/text/text",
        postman: "app/services/postman"
    }
});


require(['knockout'], function (ko) {

    ko.components.register("my-comp", {
        viewModel: { require: "app/components/mycomp"},
        template: { require: "text!app/components/mycomp.html"}
    });

    ko.components.register("my-list", {
        viewModel: { require: "app/components/mylist" },
        template: { require: "text!app/components/mylist.html" }
    });
    
    ko.components.register("get-post", {
        viewModel: { require: "app/components/getpost"},
        template: { require: "text!app/components/getpost.html"}
    });
    
    ko.components.register("tags", {
        viewModel : {require: "app/components/tags"},
        template : {require: "text!app/components/tags.html"}
    });
   
    ko.applyBindings({});
});