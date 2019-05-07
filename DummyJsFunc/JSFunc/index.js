module.exports = async function (context, req, dummyIn) {
    context.log('JavaScript HTTP trigger function processed a request.');

    // you can  can set the object straight on the bindings object
    // context.bindings.dummyMessage = {Id: "Sending from", Name: "JS via the context obj"}

    // inputs are on the context.bindings obj - and/or passed in to the method
    var d = context.bindings.dummyIn;

    // if using $return, can pass object as 2nd param in context.done()
    // context.done(null, {Id: "Sending from", Name: "JS via $return - context.done()"});

    // return a big single object with all outputs, named after the bindings in function.json
    return {
        res: {
            body: "I got Id: " + dummyIn.Id + " and Name: " + dummyIn.Name + " from the binding."
        },
        dummyMessage: {Id: "Sending from", Name: "JS via a big return object"}
    }
};