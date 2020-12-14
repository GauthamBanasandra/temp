import io.grpc.*;

import java.io.IOException;

public class Server {
    public static void main(String[] args) throws IOException, InterruptedException {
        System.out.println("Hello Java from Maven build");
        io.grpc.Server server = ServerBuilder.forPort(8080).addService(new CalculatorService()).build();
        server.start();
        System.out.println("Server started");
        server.awaitTermination();
    }
}
