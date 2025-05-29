public class Helicopter : AirVehicle
{
    public int BladeCount { get; set; }

    public Helicopter() : base()
    {
        BladeCount = 0;
    }

    public override void Init()
    {
        base.Init();
        Console.Write("Введите количество лопастей винта: ");
        BladeCount = ReadIntFromConsole("Количество лопастей винта", 1, int.MaxValue);
    }

    public override void RandomInit(Random random)
    {
        base.RandomInit(random);
        BladeCount = random.Next(2, 6);
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Лопасти: {BladeCount}";
    }

    public new object Clone()
    {
        return new Helicopter
        {
            Model = this.Model,
            YearOfManufacture = this.YearOfManufacture,
            EngineType = this.EngineType,
            CrewCount = this.CrewCount,
            Id = this.Id,
            BladeCount = this.BladeCount
        };
    }
}