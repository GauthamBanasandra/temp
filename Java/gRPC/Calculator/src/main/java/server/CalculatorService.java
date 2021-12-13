package server;

import io.grpc.stub.StreamObserver;
import org.gautham.grpc.calculator.CalculatorGrpc;
import org.gautham.grpc.calculator.Math;

public class CalculatorService extends CalculatorGrpc.CalculatorImplBase {
    @Override
    public void add(Math.Operands request, StreamObserver<Math.Result> responseObserver) {
        long operand1 = request.getOperand1();
        long operand2 = request.getOperand2();
        Math.Result result = Math.Result.newBuilder().setValue(operand1 + operand2).build();
        responseObserver.onNext(result);
        responseObserver.onCompleted();
    }
}