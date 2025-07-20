using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop
{

    class Program
    {
        // Encapsulation: List to store all cars
        static List<Car> cars = new List<Car>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Car Management System with OOP - Car Types");
                Console.WriteLine("1. Add New Car");
                Console.WriteLine("2. Show All Cars");
                Console.WriteLine("3. Start All Cars");
                Console.WriteLine("4. Remove Car");
                Console.WriteLine("0. Exit");
                Console.Write("Your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddCar();
                        break;
                    case "2":
                        ShowCars();
                        break;
                    case "3":
                        StartCars();
                        break;
                    case "4":
                        RemoveCar();
                        break;
                    case "0":
                        return;  // Exit program
                    default:
                        Console.WriteLine("Invalid choice. Press Enter.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        // Encapsulation: Get user input and add a new car object to the list
        static void AddCar()
        {
            Console.WriteLine("Choose car type:");
            Console.WriteLine("1. Ordinary");
            Console.WriteLine("2. Race");
            Console.WriteLine("3. Sports");
            Console.WriteLine("4. Super Sports");
            Console.WriteLine("5. Classic");
            Console.Write("Your choice: ");
            string typeChoice = Console.ReadLine();

            Console.Write("Car brand: ");
            string brand = Console.ReadLine();

            Console.Write("Car model: ");
            string model = Console.ReadLine();

            Console.Write("Car color: ");
            string color = Console.ReadLine();

            Console.Write("Manufacture year: ");
            int year = int.Parse(Console.ReadLine());

            Car newCar;

            // Inheritance & Polymorphism: Instantiate specific car type based on user choice
            switch (typeChoice)
            {
                case "1":
                    newCar = new OrdinaryCar(brand, model, color, year);
                    break;
                case "2":
                    newCar = new RaceCar(brand, model, color, year);
                    break;
                case "3":
                    newCar = new SportsCar(brand, model, color, year);
                    break;
                case "4":
                    newCar = new SuperSportsCar(brand, model, color, year);
                    break;
                case "5":
                    newCar = new ClassicCar(brand, model, color, year);
                    break;
                default:
                    Console.WriteLine("Invalid type, adding base Car.");
                    newCar = new Car(brand, model, color, year);
                    break;
            }

            cars.Add(newCar);
            Console.WriteLine("Car added successfully. Press Enter.");
            Console.ReadLine();
        }

        // Encapsulation: Display all cars using each car's ShowInfo method (demonstrates Polymorphism)
        static void ShowCars()
        {
            Console.WriteLine("List of cars:");
            if (cars.Count == 0)
            {
                Console.WriteLine("No cars to show.");
            }
            else
            {
                foreach (Car car in cars)
                {
                    car.ShowInfo();  // Polymorphism: call overridden method based on object type
                }
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        // Polymorphism: Call Start method on all cars demonstrating overridden behavior
        static void StartCars()
        {
            Console.WriteLine("Starting all cars:");
            foreach (Car car in cars)
            {
                car.Start();  // Polymorphic call executes method version of actual object
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        // Encapsulation: Remove a car from the list by searching its model manually (no LINQ)
        static void RemoveCar()
        {
            Console.Write("Enter model to remove: ");
            string model = Console.ReadLine().ToLower();

            Car carToRemove = null;

            // Search car by model
            foreach (Car car in cars)
            {
                if (car.Model.ToLower() == model)
                {
                    carToRemove = car;
                    break;  // Once found, stop searching
                }
            }

            if (carToRemove != null)
            {
                cars.Remove(carToRemove);
                Console.WriteLine("Car removed successfully.");
            }
            else
            {
                Console.WriteLine("No car found with this model.");
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }

    // Abstraction & Encapsulation: Base class representing common properties and methods for all cars
    public class Car
    {
        // Encapsulation: Properties with public getters/setters
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }

        // Constructor to initialize common properties
        public Car(string brand, string model, string color, int year)
        {
            Brand = brand;
            Model = model;
            Color = color;
            Year = year;
        }

        // Polymorphism: Virtual method to show car info, can be overridden by subclasses
        public virtual void ShowInfo()
        {
            Console.WriteLine($"Car -> Brand: {Brand}, Model: {Model}, Color: {Color}, Year: {Year}");
        }

        // Polymorphism: Virtual start method to be overridden by subclasses
        public virtual void Start()
        {
            Console.WriteLine($"{Brand} {Model} started with a basic start.");
        }
    }

    // Inheritance & Polymorphism: OrdinaryCar derived from Car with overridden behavior
    public class OrdinaryCar : Car
    {
        public OrdinaryCar(string brand, string model, string color, int year)
            : base(brand, model, color, year) { }

        public override void ShowInfo()
        {
            Console.WriteLine($"Ordinary Car -> Brand: {Brand}, Model: {Model}, Color: {Color}, Year: {Year}");
        }

        public override void Start()
        {
            Console.WriteLine($"{Brand} {Model} started like an ordinary car.");
        }
    }

    // Inheritance & Polymorphism: RaceCar derived from Car with overridden behavior
    public class RaceCar : Car
    {
        public RaceCar(string brand, string model, string color, int year)
            : base(brand, model, color, year) { }

        public override void ShowInfo()
        {
            Console.WriteLine($"Race Car -> Brand: {Brand}, Model: {Model}, Color: {Color}, Year: {Year}");
        }

        public override void Start()
        {
            Console.WriteLine($"{Brand} {Model} start on the track!");
        }
    }

    // Inheritance & Polymorphism: SportsCar derived from Car with overridden behavior
    public class SportsCar : Car
    {
        public SportsCar(string brand, string model, string color, int year)
            : base(brand, model, color, year) { }

        public override void ShowInfo()
        {
            Console.WriteLine($"Sports Car -> Brand: {Brand}, Model: {Model}, Color: {Color}, Year: {Year}");
        }

        public override void Start()
        {
            Console.WriteLine($"{Brand} {Model} starts with a sporty !");
        }
    }

    // Inheritance & Polymorphism: SuperSportsCar derived from Car with overridden behavior
    public class SuperSportsCar : Car
    {
        public SuperSportsCar(string brand, string model, string color, int year)
            : base(brand, model, color, year) { }

        public override void ShowInfo()
        {
            Console.WriteLine($"Super Sports Car -> Brand: {Brand}, Model: {Model}, Color: {Color}, Year: {Year}");
        }

        public override void Start()
        {
            Console.WriteLine($"{Brand} {Model} starts with a super sporty !");
        }
    }

    // Inheritance & Polymorphism: ClassicCar derived from Car with overridden behavior
    public class ClassicCar : Car
    {
        public ClassicCar(string brand, string model, string color, int year)
            : base(brand, model, color, year) { }

        public override void ShowInfo()
        {
            Console.WriteLine($"Classic Car -> Brand: {Brand}, Model: {Model}, Color: {Color}, Year: {Year}");
        }

        public override void Start()
        {
            Console.WriteLine($"{Brand} {Model} started with classic ");
        }
    }
}

