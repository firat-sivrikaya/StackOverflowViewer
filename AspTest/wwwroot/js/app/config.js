define([], function () {
    var root = 'http://localhost:5000';
    var menuElements = ["Marks", "Histories"];
    return {
        markedposturl: "http:/localhost:5000/api/markedpost/",
        posturl: "http:/localhost:5000/api/post/",
        userurl: "http:/localhost:5000/api/user/",
        tagurl: "http:/localhost:5000/api/tag/"
    }
});