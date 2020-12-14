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
                    timeOfBirth.setMinute(Integer.parseInt(reader.nextEvent().asCharacters().getData()));
                    assert reader.nextEvent().isEndElement();
                    break;

                case XMLTags.hour:
                    timeOfBirth.setHour(Integer.parseInt(reader.nextEvent().asCharacters().getData()));
                    assert reader.nextEvent().isEndElement();
                    break;

                case XMLTags.second:
                    timeOfBirth.setSecond(Integer.parseInt(reader.nextEvent().asCharacters().getData()));
                    assert reader.nextEvent().isEndElement();
                    break;

                case XMLTags.timezone:
                    timeOfBirth.setTimezone(reader.nextEvent().asCharacters().getData());
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

    public void setHour(int hour) {
        this.hour = hour;
    }

    public int getMinute() {
        return minute;
    }

    public void setMinute(int minute) {
        this.minute = minute;
    }

    public int getSecond() {
        return second;
    }

    public void setSecond(int second) {
        this.second = second;
    }

    public String getTimezone() {
        return timezone;
    }

    public void setTimezone(String timezone) {
        this.timezone = timezone;
    }
}
