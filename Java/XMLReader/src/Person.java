import javax.xml.stream.XMLEventReader;
import javax.xml.stream.XMLStreamException;

public class Person {
    private String name;
    private String id;
    private DateOfBirth dateOfBirth;
    private PlaceOfBirth placeOfBirth;
    private TimeOfBirth timeOfBirth;

    public static Person createFromXmlReader(XMLEventReader reader) throws XMLStreamException {
        Person person = new Person();
        while (!reader.peek().isEndElement()) {
            String elementName = reader.nextEvent().asStartElement().getName().getLocalPart();
            switch (elementName) {
                case XMLTags.id:
                    person.setId(reader.nextEvent().asCharacters().getData());
                    assert reader.nextEvent().isEndElement();
                    break;

                case XMLTags.name:
                    person.setName(reader.nextEvent().asCharacters().getData());
                    assert reader.nextEvent().isEndElement();
                    break;

                case XMLTags.dateOfBirth:
                    person.setDateOfBirth(DateOfBirth.createFromXmlEvent(reader));
                    break;

                case XMLTags.placeOfBirth:
                    person.setPlaceOfBirth(PlaceOfBirth.createFromXmlReader(reader));
                    break;

                case XMLTags.timeOfBirth:
                    person.setTimeOfBirth(TimeOfBirth.createFromXmlReader(reader));
                    break;

                default:
                    throw new XMLStreamException(String.format("Unknown element: %s", elementName));
            }
        }
        assert reader.nextEvent().isEndElement();
        return person;
    }

    public static class XMLTags {
        public static final String name = "name";
        public static final String id = "id";
        public static final String dateOfBirth = "date-of-birth";
        public static final String placeOfBirth = "place-of-birth";
        public static final String timeOfBirth = "time-of-birth";
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public DateOfBirth getDateOfBirth() {
        return dateOfBirth;
    }

    public void setDateOfBirth(DateOfBirth dateOfBirth) {
        this.dateOfBirth = dateOfBirth;
    }

    public PlaceOfBirth getPlaceOfBirth() {
        return placeOfBirth;
    }

    public void setPlaceOfBirth(PlaceOfBirth placeOfBirth) {
        this.placeOfBirth = placeOfBirth;
    }

    public TimeOfBirth getTimeOfBirth() {
        return timeOfBirth;
    }

    public void setTimeOfBirth(TimeOfBirth timeOfBirth) {
        this.timeOfBirth = timeOfBirth;
    }
}
