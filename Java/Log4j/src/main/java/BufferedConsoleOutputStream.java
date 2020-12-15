import java.io.OutputStream;
import java.util.concurrent.atomic.AtomicInteger;

public class BufferedConsoleOutputStream extends OutputStream {
    public static AtomicInteger WriteCount = new AtomicInteger(0);

    @Override
    public void write(int b) {
        WriteCount.incrementAndGet();

        System.out.print((char) b);
    }
}
