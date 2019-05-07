package javafunc;

import java.util.*;
import com.microsoft.azure.functions.annotation.*;
import com.microsoft.azure.functions.*;

/**
 * Java Function to use our custom 'DummyBinding'
 */
public class JavaFunc {
    @FunctionName("JavaFunc")
    public HttpResponseMessage run(
            @HttpTrigger(name = "req", methods = {HttpMethod.GET, HttpMethod.POST}, authLevel = AuthorizationLevel.ANONYMOUS) HttpRequestMessage<Optional<String>> request,
            @CustomBinding(direction = "out", name = "message", type = "dummy") OutputBinding<DummyMessage> message,
            @CustomBinding(direction = "in", name = "inMessage", type = "dummy") DummyMessage inMessage,
            final ExecutionContext context) {
        context.getLogger().info("Java HTTP trigger processed a request.");

        // Create a new Dummy Message and hand it off to the binding - output
        DummyMessage dum = new DummyMessage();
        dum.Id = "Sending out from";
        dum.Name = "Java Func!";
        message.setValue(dum);

        return request.createResponseBuilder(HttpStatus.OK).body("I got Id: " + inMessage.Id + " and Name: " + inMessage.Name + " from the binding").build();

    }
}
