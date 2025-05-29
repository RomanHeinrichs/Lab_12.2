using System;

class Program
{
    static void Main()
    {
        const int TableCapacity = 10;
        var hashTable = new HashTable<int, AirVehicle>(TableCapacity);
        var random = new Random();

        while (true)
        {
            
            Console.WriteLine("1. Добавить элемент");
            Console.WriteLine("2. Найти элемент");
            Console.WriteLine("3. Удалить элемент");
            Console.WriteLine("4. Показать таблицу");
            Console.WriteLine("5. Добавить случайные данные");
            Console.WriteLine("6. Выход");

            Console.Write("Выберите действие: ");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Неверный ввод. Попробуйте снова.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddElement(hashTable);
                    break;
                case 2:
                    FindElement(hashTable);
                    break;
                case 3:
                    RemoveElement(hashTable);
                    break;
                case 4:
                    hashTable.Display();
                    break;
                case 5:
                    AddRandomData(hashTable, random);
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }

    static void AddElement(HashTable<int, AirVehicle> hashTable)
    {
        Console.WriteLine("Выберите тип воздушного судна:");
        Console.WriteLine("1. AirVehicle");
        Console.WriteLine("2. Airplane");
        Console.WriteLine("3. Helicopter");

        Console.Write("Введите номер типа: ");
        if (!int.TryParse(Console.ReadLine(), out int typeChoice) || typeChoice < 1 || typeChoice > 3)
        {
            Console.WriteLine("Неверный выбор.");
            return;
        }

        AirVehicle vehicle = typeChoice switch
        {
            1 => new AirVehicle(),
            2 => new Airplane(),
            3 => new Helicopter(),
            _ => null
        };

        vehicle?.Init();
        try
        {
            hashTable.Add(vehicle.Id, vehicle);
            Console.WriteLine("Элемент успешно добавлен.");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Ошибка: Элемент с таким ID уже существует.");
        }
    }

    static void FindElement(HashTable<int, AirVehicle> hashTable)
    {
        Console.Write("Введите ID для поиска: ");
        if (int.TryParse(Console.ReadLine(), out int id) && hashTable.TryGetValue(id, out var vehicle))
        {
            Console.WriteLine($"Найден элемент: {vehicle}");
        }
        else
        {
            Console.WriteLine("Элемент не найден.");
        }
    }

    static void RemoveElement(HashTable<int, AirVehicle> hashTable)
    {
        Console.Write("Введите ID для удаления: ");
        if (int.TryParse(Console.ReadLine(), out int id) && hashTable.Remove(id))
        {
            Console.WriteLine("Элемент успешно удален.");
        }
        else
        {
            Console.WriteLine("Элемент не найден.");
        }
    }

    static void AddRandomData(HashTable<int, AirVehicle> hashTable, Random random)
    {
        Console.Write("Сколько случайных элементов добавить? ");
        if (int.TryParse(Console.ReadLine(), out int count))
        {
            for (int i = 0; i < count; i++)
            {
                AirVehicle vehicle = random.Next(0, 3) switch
                {
                    0 => new AirVehicle(),
                    1 => new Airplane(),
                    2 => new Helicopter(),
                    _ => null
                };

                vehicle?.RandomInit(random);
                try
                {
                    hashTable.Add(vehicle.Id, vehicle);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine($"Пропущен элемент с ID {vehicle.Id} (дубликат).");
                }
            }
            Console.WriteLine("Случайные данные добавлены.");
        }
        else
        {
            Console.WriteLine("Неверный ввод.");
        }
    }
}