import java.io.IOException;
import java.io.Writer;
import java.util.concurrent.atomic.AtomicInteger;

public class ConsoleWriter extends Writer {
    public static AtomicInteger WriteCount = new AtomicInteger(0);

    @Override
    public void write(char[] cbuf, int off, int len) throws IOException {
        WriteCount.incrementAndGet();

//        String str = new String(cbuf, off, len);
//        System.out.println(str);
    }

    @Override
    public void flush() throws IOException {
        System.out.println("Flushed");
    }

    @Override
    public void close() throws IOException {
        flush();
        System.out.println("Closed");
    }
}
