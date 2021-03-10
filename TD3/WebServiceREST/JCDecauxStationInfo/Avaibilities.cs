namespace JCDecauxStationInfo
{
    public class Availabilities
    {
        public int bikes { get; set; }

        public int stands { get; set; }

        public int mechanicalBikes { get; set; }

        public int electricalBikes { get; set; }

        public int electricalInternalBatteryBikes { get; set; }

        public int electricalRemovableBatteryBikes { get; set; }

        public override string ToString()
        {
            return
                "Bikes: " + bikes + "\n" +
                "Stands: " + this.stands + "\n" +
                "Mechanical Bikes: " + mechanicalBikes + "\n" +
                "Electrical Bikes: " + electricalBikes + "\n" +
                "Electrical Internal Battery Bikes: " + electricalInternalBatteryBikes + "\n" +
                "Electrical Removable Battery Bikes: " + electricalRemovableBatteryBikes + "\n";
        }
    }
}
