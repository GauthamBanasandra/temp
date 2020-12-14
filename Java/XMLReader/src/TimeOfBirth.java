import javax.xml.stream.XMLEventReader;
import javax.xml.stream.XMLStreamException;

public class TimeOfBirth {
    private int hour;
    private int minute;
    private int second;
    private String timezone;

    public static TimeOfBirth createFromXmlReader(XMLEventReader reader) throws XMLStreamException {
        TimeOfBirth timeOfBirth = new TimeOfBirth();
        while (!reader.peek().isEndElement()) {
            String elementName = reader.nextEvent().asStartElement().getName().getLocalPart();
            switch (elementName) {
                case XMLTags.minute:
                    timeOfBirth.minute = Integer.parseInt(reader.nextEvent().asCharacters().getData());
                    assert reader.nextEvent().isEndElement();
                    break;

                case XMLTags.hour:
                    timeOfBirth.hour = Integer.parseInt(reader.nextEvent().asCharacters().getData());
                    assert reader.nextEvent().isEndElement();
                    break;

                case XMLTags.second:
                    timeOfBirth.second = Integer.parseInt(reader.nextEvent().asCharacters().getData());
                    assert reader.nextEvent().isEndElement();
                    break;

                case XMLTags.timezone:
                    timeOfBirth.timezone = reader.nextEvent().asCharacters().getData();
                    assert reader.nextEvent().isEndElement();
                    break;

                default:
                    throw new XMLStreamException(String.format("Unknown element: %s", elementName));
            }
            reader.nextEvent();
        }
        assert reader.nextEvent().isEndElement();
        return timeOfBirth;
    }

    public static class XMLTags {
        public static final String hour = "hour";
        // TODO : Change this to "minute"
        public static final String minute = "minutes";
        public static final String second = "second";
        public static final String timezone = "timezone";
    }

    public int getHour() {
        return hour;
    }

    public int getMinute() {
        return minute;
    }

    public int getSecond() {
        return second;
    }

    public String getTimezone() {
        return timezone;
    }
}
