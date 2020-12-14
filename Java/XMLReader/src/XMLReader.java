import javax.xml.stream.XMLStreamException;
import java.io.FileInputStream;
import java.io.FileNotFoundException;

public class XMLReader {
    public static void main(String[] args) throws FileNotFoundException, XMLStreamException {
        FileInputStream inputStream = new FileInputStream("C:\\Users\\Gautham\\projects\\github\\temp\\Java\\XMLReader\\resources\\input.xml");
        RequestParser requestParser = new RequestParser();
        MatchData matchData = requestParser.parse(inputStream);
    }
}
