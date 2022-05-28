namespace lab1;

class Program
{
    static void Main(string[] args)
    {

    }
}

public class Vehicle
{
    public string Licence { get; set; }
    public bool Pass { get; set; }
    public Vehicle(string licence, bool pass)
    {
        this.Licence = licence;
        this.Pass = pass;
    }
}

public class VehicleTracker
{
    //PROPERTIES
    public string Address { get; set; }
    public int Capacity { get; set; }
    public int SlotsAvailable { get; set; }
    public Dictionary<int, Vehicle> VehicleList { get; set; }

    public VehicleTracker(int capacity, string address)
    {
        this.Capacity = capacity;
        this.Address = address;
        this.VehicleList = new Dictionary<int, Vehicle>();

        this.GenerateSlots();
    }

    // STATIC PROPERTIES
    public static string BadSearchMessage = "Error: Search did not yield any result.";
    public static string BadSlotNumberMessage = "Error: No slot with number ";
    public static string SlotsFullMessage = "Error: no slots available.";
    public static string LicenceNotFoundMessage = "Error: Licence not found.";

    // METHODS
    public void GenerateSlots()
    {
        //bug fix:
        if (this.VehicleList.Count != 0)
            this.VehicleList.Clear();
        for (int i = 1; i <= this.Capacity; i++)//bug fix-> i=1
        {
            this.VehicleList.Add(i, null);
        }
        //bug fix:
        this.SlotsAvailable = this.Capacity;
    }

    public void AddVehicle(Vehicle vehicle)
    {
        if (this.SlotsAvailable < 1)
        {
            throw new IndexOutOfRangeException(SlotsFullMessage); //bug fix
        }
        foreach (KeyValuePair<int, Vehicle> slot in this.VehicleList)
        {

            if (slot.Value == null)
            {
                this.VehicleList[slot.Key] = vehicle;
                this.SlotsAvailable--; //bug-fix:SlotsAvailable++; => SlotsAvailable--;
                return;
            }
        }

    }

    public void RemoveVehicle(string licence)
    {
        try
        {
            int slot = this.VehicleList.First(v => v.Value.Licence == licence).Key;

            this.SlotsAvailable++; //bug fix: SlotsAvailable--; => SlotsAvailable++
            this.VehicleList[slot] = null;
        }
        catch
        {
            throw new NullReferenceException(BadSearchMessage);
        }
    }

    public bool RemoveVehicle(int slotNumber)
    {
        //bug-fix:if the slot number is invalid (greater than capacity or negative), or the slot is not filled, should throw an exception
        if (slotNumber > this.Capacity || slotNumber <= 0)
        {
            throw new ArgumentOutOfRangeException(BadSlotNumberMessage);
            return false;
        }
        this.VehicleList[slotNumber] = null;
        this.SlotsAvailable++;
        return true;
    }

    public List<Vehicle> ParkedPassholders()
    {
        List<Vehicle> passHolders = new List<Vehicle>();
        foreach (var v in this.VehicleList.Values)
        {
            if (v != null)
            {
                passHolders.Add(v);
            }
        }
        //passHolders.Add(this.VehicleList.FirstOrDefault(v => v.Value.Pass).Value);//error1->should return a list of all parked vehicles that have a pass.
        return passHolders;
    }

    public int PassholderPercentage()
    {
        int passHolders = ParkedPassholders().Count();
        double percentage = (double)(passHolders / this.Capacity) * 100; //bug-fix
        return (int)percentage;
    }
}
