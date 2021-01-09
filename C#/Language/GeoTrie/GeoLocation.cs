using System;
using System.Collections.Generic;
using System.Text;
using FileHelpers;

namespace GeoTrie
{
    [DelimitedRecord("\t")]
    class GeoLocation
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string AsciiName { get; set; }
        public string? AlternateNames { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? FeatureClass { get; set; }
        public string? FeatureCode { get; set; }
        public string CountryCode { get; set; }
        public string CountryCode2 { get; set; }
        public string? Admin1Code { get; set; }
        public string? Admin2Code { get; set; }
        public string? Admin3Code { get; set; }
        public string? Admin4Code { get; set; }
        public long? Population { get; set; }
        public long? Elevation { get; set; }
        public string? DigitalElevationModel { get; set; }
        public string Timezone { get; set; }
        public string? ModificationDate { get; set; }
    }
}
