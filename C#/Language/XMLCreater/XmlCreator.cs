using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace XMLCreator
{
    public class XmlCreator
    {
        public static string Create(Person boy, Person girl)
        {
            var writerSettings = new XmlWriterSettings
            {
                ConformanceLevel = ConformanceLevel.Fragment,
                CloseOutput = false
            };

            var stringBuilder = new StringBuilder();
            using var writer = XmlWriter.Create(stringBuilder, writerSettings);
            // start match data
            writer.WriteStartElement("match-data");

            // start boy
            writer.WriteStartElement("boy");

            writer.WriteElementString("id", boy.Id);
            writer.WriteElementString("name", boy.Name);

            // start date of birth
            writer.WriteStartElement("date-of-birth");
            writer.WriteElementString("day", boy.DateAndTimeOfBirth.Day.ToString());
            writer.WriteElementString("month", boy.DateAndTimeOfBirth.Month.ToString());
            writer.WriteElementString("year", boy.DateAndTimeOfBirth.Year.ToString());
            writer.WriteEndElement();
            // end date of birth

            // start place of birth
            writer.WriteStartElement("place-of-birth");

            // start latitude
            writer.WriteStartElement("latitude");
            writer.WriteElementString("degrees", "1");
            writer.WriteElementString("minutes", "1");
            writer.WriteElementString("direction", "North");
            writer.WriteEndElement();
            // end latitude

            // start longitude
            writer.WriteStartElement("longitude");
            writer.WriteElementString("degrees", "1");
            writer.WriteElementString("minutes", "1");
            writer.WriteElementString("direction", "North");
            writer.WriteEndElement();
            // end longitude

            writer.WriteEndElement();
            // end place of birth

            // start time of birth
            writer.WriteStartElement("time-of-birth");
            writer.WriteElementString("hour", boy.DateAndTimeOfBirth.Hour.ToString());
            writer.WriteElementString("minutes", boy.DateAndTimeOfBirth.Minute.ToString());
            writer.WriteElementString("second", boy.DateAndTimeOfBirth.Second.ToString());
            writer.WriteElementString("timezone", "IST");
            writer.WriteEndElement();
            // end time of birth

            writer.WriteEndElement();
            // end boy

            // start girl
            writer.WriteStartElement("girl");

            writer.WriteElementString("id", girl.Id);
            writer.WriteElementString("name", girl.Name);

            // start date of birth
            writer.WriteStartElement("date-of-birth");
            writer.WriteElementString("day", girl.DateAndTimeOfBirth.Day.ToString());
            writer.WriteElementString("month", girl.DateAndTimeOfBirth.Month.ToString());
            writer.WriteElementString("year", girl.DateAndTimeOfBirth.Year.ToString());
            writer.WriteEndElement();
            // end date of birth

            // start place of birth
            writer.WriteStartElement("place-of-birth");

            // start latitude
            writer.WriteStartElement("latitude");
            writer.WriteElementString("degrees", "1");
            writer.WriteElementString("minutes", "1");
            writer.WriteElementString("direction", "North");
            writer.WriteEndElement();
            // end latitude

            // start longitude
            writer.WriteStartElement("longitude");
            writer.WriteElementString("degrees", "1");
            writer.WriteElementString("minutes", "1");
            writer.WriteElementString("direction", "North");
            writer.WriteEndElement();
            // end longitude

            writer.WriteEndElement();
            // end place of birth

            // start time of birth
            writer.WriteStartElement("time-of-birth");
            writer.WriteElementString("hour", girl.DateAndTimeOfBirth.Hour.ToString());
            writer.WriteElementString("minutes", girl.DateAndTimeOfBirth.Minute.ToString());
            writer.WriteElementString("second", girl.DateAndTimeOfBirth.Second.ToString());
            writer.WriteElementString("timezone", "IST");
            writer.WriteEndElement();
            // end time of birth

            writer.WriteEndElement();
            // end girl

            writer.WriteEndElement();
            // end match

            writer.Flush();
            writer.Close();
            return stringBuilder.ToString();
        }
    }
}
