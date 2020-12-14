import javax.xml.stream.XMLEventReader;
import javax.xml.stream.XMLStreamException;

public class PlaceOfBirth {
    private GeologicalPoint latitude;
    private GeologicalPoint longitude;

    public static PlaceOfBirth createFromXmlReader(XMLEventReader reader) throws XMLStreamException {
        PlaceOfBirth placeOfBirth = new PlaceOfBirth();
        while (!reader.peek().isEndElement()) {
            String elementName = reader.nextEvent().asStartElement().getName().getLocalPart();
            switch (elementName) {
                case XMLTags.latitude:
                    placeOfBirth.latitude = GeologicalPoint.createFromXmlReader(reader);
                    break;

                case XMLTags.longitude:
                    placeOfBirth.longitude = GeologicalPoint.createFromXmlReader(reader);
                    break;

                default:
                    throw new XMLStreamException(String.format("Unknown element: %s", elementName));
            }
            reader.nextEvent();
        }
        assert reader.nextEvent().isEndElement();
        return placeOfBirth;
    }

    public static class XMLTags {
        public static final String latitude = "latitude";
        public static final String longitude = "longitude";
    }

    public GeologicalPoint getLatitude() {
        return latitude;
    }

    public GeologicalPoint getLongitude() {
        return longitude;
    }
}
