import javax.xml.stream.XMLEventReader;
import javax.xml.stream.XMLStreamException;

public class DateOfBirth {
    private int day;
    private int month;
    private int year;

    public static DateOfBirth createFromXmlReader(XMLEventReader reader) throws XMLStreamException {
        DateOfBirth dateOfBirth = new DateOfBirth();
        while (!reader.peek().isEndElement()) {
            String elementName = reader.nextEvent().asStartElement().getName().getLocalPart();
            switch (elementName) {
                case XMLTags.day:
                    dateOfBirth.day = Integer.parseInt(reader.nextEvent().asCharacters().getData().strip());
                    assert reader.nextEvent().isEndElement();
                    break;

                case XMLTags.month:
                    dateOfBirth.month = Integer.parseInt(reader.nextEvent().asCharacters().getData().strip());
                    assert reader.nextEvent().isEndElement();
                    break;

                case XMLTags.year:
                    dateOfBirth.year = Integer.parseInt(reader.nextEvent().asCharacters().getData().strip());
                    assert reader.nextEvent().isEndElement();
                    break;

                default:
                    throw new XMLStreamException(String.format("Unknown element: %s", elementName));
            }
            reader.nextEvent();
        }
        assert reader.nextEvent().isEndElement();
        return dateOfBirth;
    }

    public static class XMLTags {
        public static final String day = "day";
        public static final String month = "month";
        public static final String year = "year";
    }

    public int getDay() {
        return day;
    }

    public int getMonth() {
        return month;
    }

    public int getYear() {
        return year;
    }
}
