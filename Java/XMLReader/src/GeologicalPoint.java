import javax.xml.stream.XMLEventReader;
import javax.xml.stream.XMLStreamException;

public class GeologicalPoint {
    private static class Place {
        public enum Direction {
            NORTH, SOUTH, EAST, WEST
        }
    }

    private int degrees;
    private int minutes;
    private Place.Direction direction;

    public static GeologicalPoint createFromXmlReader(XMLEventReader reader) throws XMLStreamException {
        GeologicalPoint geologicalPoint = new GeologicalPoint();
        while (!reader.peek().isEndElement()) {
            String elementName = reader.nextEvent().asStartElement().getName().getLocalPart();
            switch (elementName) {
                case XMLTags.degrees:
                    geologicalPoint.degrees = Integer.parseInt(reader.nextEvent().asCharacters().getData().strip());
                    assert reader.nextEvent().isEndElement();
                    break;

                case XMLTags.minutes:
                    geologicalPoint.minutes = Integer.parseInt(reader.nextEvent().asCharacters().getData().strip());
                    assert reader.nextEvent().isEndElement();
                    break;

                case XMLTags.direction:
                    String direction = reader.nextEvent().asCharacters().getData().strip();
                    if (direction.equalsIgnoreCase("NORTH")) {
                        geologicalPoint.direction = Place.Direction.NORTH;
                    } else if (direction.equalsIgnoreCase("SOUTH")) {
                        geologicalPoint.direction = Place.Direction.SOUTH;
                    } else if (direction.equalsIgnoreCase("EAST")) {
                        geologicalPoint.direction = Place.Direction.EAST;
                    } else if (direction.equalsIgnoreCase("WEST")) {
                        geologicalPoint.direction = Place.Direction.WEST;
                    } else {
                        throw new XMLStreamException(String.format("Unknown direction: %s", direction));
                    }
                    assert reader.nextEvent().isEndElement();
                    break;

                default:
                    throw new XMLStreamException(String.format("Unknown element: %s", elementName));
            }
            reader.nextEvent();
        }
        assert reader.nextEvent().isEndElement();
        return geologicalPoint;
    }

    public static class XMLTags {
        public final static String degrees = "degrees";
        public final static String minutes = "minutes";
        public final static String direction = "direction";
    }

    public int getDegrees() {
        return degrees;
    }

    public int getMinutes() {
        return minutes;
    }

    public Place.Direction getDirection() {
        return direction;
    }
}
