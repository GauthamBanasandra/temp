import java.io.OutputStream;

public class BufferedConsoleOutputStream extends OutputStream {
    @Override
    public void write(int b) {
        System.out.print((char) b);
    }
}
