define(['postman'], function (postman) { // needed fro require modules
    return function (params) { // needed for knockout components
        let title = "Hey, " + params.name;
        let doSomething = function () {
            postman.publish('someEvent', { msg: "hello" });
        }
        return {
            title,
            doSomething
        };
    };
});