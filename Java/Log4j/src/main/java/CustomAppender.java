import org.apache.log4j.WriterAppender;
import org.apache.log4j.helpers.OnlyOnceErrorHandler;
import org.apache.log4j.helpers.QuietWriter;

import java.io.BufferedWriter;
import java.io.IOException;
import java.io.Writer;

public class CustomAppender extends WriterAppender {
    private Writer writer;

    public CustomAppender() {
        super();

        super.setImmediateFlush(false);
        super.reset();

        writer = new ConsoleWriter();
        writer = new BufferedWriter(writer, 8 * 1024);
        super.qw = new QuietWriter(writer, new OnlyOnceErrorHandler());

        Runtime.getRuntime().addShutdownHook(new Thread(() -> {
            try {
                writer.flush();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }));
    }
}
