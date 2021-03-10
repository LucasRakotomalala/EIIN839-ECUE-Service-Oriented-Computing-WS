namespace JCDecauxStationInfo
{
    public class Stand
    {
        public Availabilities availabilities { get; set; }

        public int capacity { get; set; }

        public override string ToString()
        {
            return
                "Availabilities: " + availabilities + "\n" +
                "Capacity: " + capacity;
        }
    }
}
