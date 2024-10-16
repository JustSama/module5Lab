using System;

public interface ITransport
{
    void Move();
    void FuelUp();
}

public class Car : ITransport
{
    private string model;
    private int speed;

    public Car(string model, int speed)
    {
        this.model = model;
        this.speed = speed;
    }

    public void Move()
    {
        Console.WriteLine($"Автомобиль {model} движется со скоростью {speed} км/ч.");
    }

    public void FuelUp()
    {
        Console.WriteLine($"Автомобиль {model} заправляется бензином.");
    }
}

public class Motorcycle : ITransport
{
    private string model;
    private int speed;

    public Motorcycle(string model, int speed)
    {
        this.model = model;
        this.speed = speed;
    }

    public void Move()
    {
        Console.WriteLine($"Мотоцикл {model} движется со скоростью {speed} км/ч.");
    }

    public void FuelUp()
    {
        Console.WriteLine($"Мотоцикл {model} заправляется бензином.");
    }
}

public class Plane : ITransport
{
    private string model;
    private int speed;

    public Plane(string model, int speed)
    {
        this.model = model;
        this.speed = speed;
    }

    public void Move()
    {
        Console.WriteLine($"Самолет {model} летит со скоростью {speed} км/ч.");
    }

    public void FuelUp()
    {
        Console.WriteLine($"Самолет {model} заправляется авиационным топливом.");
    }
}

public class Bicycle : ITransport
{
    private string model;
    private int speed;

    public Bicycle(string model, int speed)
    {
        this.model = model;
        this.speed = speed;
    }

    public void Move()
    {
        Console.WriteLine($"Велосипед {model} движется со скоростью {speed} км/ч.");
    }

    public void FuelUp()
    {
        Console.WriteLine($"Велосипед {model} не требует заправки.");
    }
}

public abstract class TransportFactory
{
    public abstract ITransport CreateTransport(string model, int speed);
}

public class CarFactory : TransportFactory
{
    public override ITransport CreateTransport(string model, int speed)
    {
        return new Car(model, speed);
    }
}

public class MotorcycleFactory : TransportFactory
{
    public override ITransport CreateTransport(string model, int speed)
    {
        return new Motorcycle(model, speed);
    }
}

public class PlaneFactory : TransportFactory
{
    public override ITransport CreateTransport(string model, int speed)
    {
        return new Plane(model, speed);
    }
}

public class BicycleFactory : TransportFactory
{
    public override ITransport CreateTransport(string model, int speed)
    {
        return new Bicycle(model, speed);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Выберите тип транспорта: 1 - Автомобиль, 2 - Мотоцикл, 3 - Самолет, 4 - Велосипед");
        int choice = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите модель:");
        string model = Console.ReadLine();

        Console.WriteLine("Введите скорость (км/ч):");
        int speed = int.Parse(Console.ReadLine());

        TransportFactory factory = null;

        switch (choice)
        {
            case 1:
                factory = new CarFactory();
                break;
            case 2:
                factory = new MotorcycleFactory();
                break;
            case 3:
                factory = new PlaneFactory();
                break;
            case 4:
                factory = new BicycleFactory();
                break;
            default:
                Console.WriteLine("Неверный выбор.");
                return;
        }

        ITransport transport = factory.CreateTransport(model, speed);
        transport.Move();
        transport.FuelUp();
    }
}
