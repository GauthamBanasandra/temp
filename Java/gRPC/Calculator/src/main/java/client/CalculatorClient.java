package client;

import io.grpc.ManagedChannel;
import io.grpc.ManagedChannelBuilder;
import io.grpc.StatusRuntimeException;
import org.gautham.grpc.calculator.CalculatorGrpc;
import org.gautham.grpc.calculator.Math;

import java.util.logging.Logger;

public class CalculatorClient {
    private static final Logger logger = Logger.getLogger(CalculatorClient.class.getName());

    private static final String serviceHost = "localhost:9000";

    public static void main(String[] args) {
        ManagedChannel channel = ManagedChannelBuilder.forTarget(serviceHost).usePlaintext().build();
        CalculatorGrpc.CalculatorBlockingStub calculatorBlockingStub = CalculatorGrpc.newBlockingStub(channel);

        Math.Operands operands = Math.Operands.newBuilder().setOperand1(1).setOperand2(1).build();

        Math.Result result;
        try {
            result = calculatorBlockingStub.add(operands);
            logger.info(String.format("The result is: %d", result.getValue()));
        } catch (StatusRuntimeException e) {
            e.printStackTrace();
        }
    }
}
