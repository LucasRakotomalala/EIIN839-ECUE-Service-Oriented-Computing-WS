namespace JCDecauxStationInfo
{
    public class DetailedStation
    {
        public string contractName { get; set; }

        public string name { get; set; }

        public string address { get; set; }

        public int number { get; set; }

        public Position position { get; set; }

        public bool banking { get; set; }

        public bool bonus { get; set; }

        public string status { get; set; }

        public bool connected { get; set; }

        public bool overflow { get; set; }

        public string shape { get; set; }

        public string overflowStands { get; set; }

        public Stand totalStands { get; set; }

        public Stand mainStands { get; set; }

        public override string ToString()
        {
            return
                "Contract Name: " + contractName + "\n" +
                "Address: " + address + "\n" +
                "Name: " + name + "\n" +
                "Number: " + number + "\n" +
                position.ToString() +
                "Banking: " + banking + "\n" +
                "Bonus: " + bonus + "\n" +
                "Status: " + status + "\n" +
                "Connected: " + connected + "\n" +
                "Overflow: " + overflow + "\n" +
                "Shape: " + shape + "\n" +
                "Overflow Stands: " + overflowStands + "\n" +
                "Total Stands: " + totalStands + "\n" +
                "Main Stands: " + mainStands + "\n";
        }
    }
}
