namespace JCDecauxGPS
{
    public class Position
    {
        public double latitude { get; set; }

        public double longitude { get; set; }

        public override string ToString()
        {
            return
                "Latitude: " + latitude + "\n" +
                "Longitude: " + longitude + "\n";
        }
    }
}
