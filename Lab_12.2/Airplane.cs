public class Airplane : AirVehicle
{
    public int PassengerCount { get; set; }
    public int MaxRange { get; set; }

    public Airplane() : base()
    {
        PassengerCount = 0;
        MaxRange = 0;
    }

    public override void Init()
    {
        base.Init();
        Console.Write("Введите количество пассажиров: ");
        PassengerCount = ReadIntFromConsole("Количество пассажиров", 0, int.MaxValue);

        Console.Write("Введите максимальную дальность полёта: ");
        MaxRange = ReadIntFromConsole("Максимальная дальность полёта", 1, int.MaxValue);
    }

    public override void RandomInit(Random random)
    {
        base.RandomInit(random);
        PassengerCount = random.Next(50, 500);
        MaxRange = random.Next(1000, 10000);
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Пассажиры: {PassengerCount}, Дальность: {MaxRange} км";
    }

    public new object Clone()
    {
        return new Airplane
        {
            Model = this.Model,
            YearOfManufacture = this.YearOfManufacture,
            EngineType = this.EngineType,
            CrewCount = this.CrewCount,
            Id = this.Id,
            PassengerCount = this.PassengerCount,
            MaxRange = this.MaxRange
        };
    }
}