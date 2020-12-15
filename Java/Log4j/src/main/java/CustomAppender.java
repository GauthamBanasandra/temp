import org.apache.log4j.FileAppender;
import org.apache.log4j.spi.LoggingEvent;

public class CustomAppender extends FileAppender {
    @Override
    public void append(LoggingEvent event) {
        System.out.println("Appending now " + event.getRenderedMessage());
    }
}
