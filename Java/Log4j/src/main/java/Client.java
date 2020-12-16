import org.apache.log4j.Logger;

public class Client {
    private static final Logger logger = Logger.getLogger(Client.class);

    public static void main(String[] args) {
        logger.info("0".repeat(1024 * 1024));

        System.out.printf("WriteCount=%d\n", ConsoleWriter.WriteCount.intValue());
    }
}
