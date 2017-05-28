// using es6 syntax
define([], () => {
    return (() => {

        let subscribers = [];

        let subscribe = (event, callback) => {
            let subscriber = { event, callback };
            subscribers.push(subscriber);

            return () => {
                subscribers = subscribers.filter(s => s !== subscriber);
            };
        };

        let publish = (event, data) => {
            subscribers.forEach(s => {
                if (s.event === event) s.callback(data);
            });
        };

        return {
            subscribe,
            publish
        };
    })();
});
