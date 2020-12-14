import javax.xml.stream.XMLEventReader;
import javax.xml.stream.XMLStreamException;

public class MatchData {
    public static final String XMLTag = "match";

    private Person boy;
    private Person girl;

    public static MatchData createFromXmlReader(XMLEventReader reader) throws XMLStreamException {
        MatchData matchData = new MatchData();
        while (!reader.peek().isEndElement()) {
            String elementName = reader.nextEvent().asStartElement().getName().getLocalPart();
            switch (elementName) {
                case XMLTags.boy:
                    matchData.boy = Person.createFromXmlReader(reader);
                    break;

                case XMLTags.girl:
                    matchData.girl = Person.createFromXmlReader(reader);
                    break;

                default:
                    throw new XMLStreamException(String.format("Unknown element: %s", elementName));
            }
            reader.nextEvent();
        }
        assert reader.nextEvent().isEndElement();
        return matchData;
    }

    public static class XMLTags {
        public static final String boy = "boy";
        public static final String girl = "girl";
    }

    public static String getXMLTag() {
        return XMLTag;
    }

    public Person getBoy() {
        return boy;
    }

    public Person getGirl() {
        return girl;
    }
}
