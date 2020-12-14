import javax.xml.stream.XMLEventReader;
import javax.xml.stream.XMLStreamException;

public class DateOfBirth {
    private int day;
    private int month;
    private int year;

    public static DateOfBirth createFromXmlEvent(XMLEventReader reader) throws XMLStreamException {
        DateOfBirth dateOfBirth = new DateOfBirth();
        while (!reader.peek().isEndElement()) {
            String elementName = reader.nextEvent().asStartElement().getName().getLocalPart();
            switch (elementName) {
                case XMLTags.day:
                    dateOfBirth.setDay(Integer.parseInt(reader.nextEvent().asCharacters().getData()));
                    assert reader.nextEvent().isEndElement();
                    break;

                case XMLTags.month:
                    dateOfBirth.setMonth(Integer.parseInt(reader.nextEvent().asCharacters().getData()));
                    assert reader.nextEvent().isEndElement();
                    break;

                case XMLTags.year:
                    dateOfBirth.setYear(Integer.parseInt(reader.nextEvent().asCharacters().getData()));
                    assert reader.nextEvent().isEndElement();
                    break;

                default:
                    throw new XMLStreamException(String.format("Unknown element: %s", elementName));
            }
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

    public void setDay(int day) {
        this.day = day;
    }

    public int getMonth() {
        return month;
    }

    public void setMonth(int month) {
        this.month = month;
    }

    public int getYear() {
        return year;
    }

    public void setYear(int year) {
        this.year = year;
    }

}
