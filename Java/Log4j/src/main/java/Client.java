import org.apache.log4j.Logger;

public class Client {
    private static final Logger logger = Logger.getLogger(Client.class);

    public static void main(String[] args) {
        logger.info("Hello log");

        System.out.printf("WriteCount=%d\n", BufferedConsoleOutputStream.WriteCount.intValue());
    }
}
