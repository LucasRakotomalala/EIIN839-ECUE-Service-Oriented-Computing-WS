namespace JCDecauxStationsList
{
    public class Station
    {
        public string contract_name { get; set; }

        public string name { get; set; }

        public int number { get; set; }

        public Position position { get; set; }

        public override string ToString()
        {
            return
                "Contract Name: " + contract_name + "\n" +
                "Name: " + name + "\n" +
                "Number: " + number + "\n" +
                position.ToString();
        }
    }
}
