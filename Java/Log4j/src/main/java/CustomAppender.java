import org.apache.log4j.WriterAppender;
import org.apache.log4j.helpers.OnlyOnceErrorHandler;
import org.apache.log4j.helpers.QuietWriter;

import java.io.BufferedWriter;
import java.io.OutputStream;
import java.io.Writer;

public class CustomAppender extends WriterAppender {
    public CustomAppender() {
        super();

        OutputStream os = new BufferedConsoleOutputStream();
        Writer writer = super.createWriter(os);
        writer = new BufferedWriter(writer, 10);
        super.qw = new QuietWriter(writer, new OnlyOnceErrorHandler());
    }
}
