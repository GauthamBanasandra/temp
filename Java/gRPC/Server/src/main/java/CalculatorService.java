import org.example.myMath.CalculatorGrpc;
import org.example.myMath.Math;

import io.grpc.stub.StreamObserver;

public class CalculatorService extends CalculatorGrpc.CalculatorImplBase {
    @Override
    public void add(Math.Operands request, StreamObserver<Math.Number> responseObserver) {
        System.out.println(request);

        long x = request.getOperand1();
        long y = request.getOperand2();

        Math.Number response = Math.Number.newBuilder().setNumber(x + y).build();
        responseObserver.onNext(response);
        responseObserver.onCompleted();
    }
}
