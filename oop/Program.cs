using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
                string[] menu =  {
                    "Exit",
                    "Add New Car",
                    "Show All Cars",
                    "Start All Cars",
                    "Remove Car"


                };

                Console.WriteLine("Car Management System with OOP - Car Types");
                for (int i = 0; i < menu.Length; i++)
                {
                    Console.WriteLine($"{i}. {menu[i]}");
                }
                const String choiceQuestion = "Your choice: ";

                while (true)
                {
                    try
                    {
                        Console.Write(choiceQuestion);
                        int choice = int.Parse(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                AddCar();
                                break;
                            case 2:
                                ShowCars();
                                break;
                            case 3:
                                StartCars();
                                break;
                            case 4:
                                RemoveCar();
                                break;
                            case 0:
                                return;  // Exit program
                        }
                        break;
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid number!");
                        Console.ResetColor();
                    }
                }
            }
        }

        // Encapsulation: Get user input and add a new car object to the list
        static void AddCar()
        {
            string[] typecar = {
                "Ordinary",
                "Race",
                "Sports",
                "Super Sports",
                "Classic"
            };
            Console.WriteLine("Choose car type:");
            for (int i = 0; i < typecar.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {typecar[i]}");
            }

            Console.Write("Your choice: ");
            string typeChoice = Console.ReadLine();

            Console.Write("Car brand: ");
            string brand = Console.ReadLine();

            Console.Write("Car model: ");
            string model = Console.ReadLine();

            Console.Write("Car color: ");
            string color = Console.ReadLine();


            int year = 0;
            const String carmodelQuestion = "car model year: ";

            while (true)
            {
                try
                {
                    Console.Write(carmodelQuestion);
                    year = int.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid number!");
                    Console.ResetColor();
                }
            }


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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Car added successfully. Press Enter.");
            Console.ReadLine();
            Console.ResetColor();
        }

        // Encapsulation: Display all cars using each car's ShowInfo method (demonstrates Polymorphism)
        static void ShowCars()
        {
            Console.WriteLine("List of cars:");
            if (cars.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("No cars to show.");
                Console.ResetColor();
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
            Console.WriteLine("List of cars:");
            Console.WriteLine("------------------------------------------------");

            if (cars.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("No cars to show.");
                Console.ResetColor();
            }
            else
            {
                foreach (Car car in cars)
                {
                    car.ShowInfo();  // Polymorphism: call overridden method based on object type
                }
            }
            Console.WriteLine("------------------------------------------------");

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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Car removed successfully.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("No car found with this model.");
                Console.ResetColor();
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
            Console.WriteLine(

                $"Car -> Brand: {Brand}," +
                $" Model: {Model}," +
                $" Color: {Color}," +
                $" Year: {Year}"

                );
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
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(
                $"Ordinary Car -> Brand: {Brand}," +
                $" Model: {Model}," +
                $" Color: {Color}," +
                $" Year: {Year}"
                );
            Console.ResetColor();
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
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(
                $"Race Car -> Brand: {Brand}, " +
                $"Model: {Model}," +
                $" Color: {Color}," +
                $" Year: {Year}"
                );
            Console.ResetColor();
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
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(
                $"Sports Car -> Brand: {Brand}," +
                 $" Model: {Model}," +
                 $" Color: {Color}," +
                 $" Year: {Year}"
                );
            Console.ResetColor();
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
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(
                $"Super Sports Car -> Brand: {Brand}," +
                 $" Model: {Model}," +
                 $" Color: {Color}," +
                 $" Year: {Year}"
                );
            Console.ResetColor();
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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(
                $"Classic Car -> Brand: {Brand}," +
                $" Model: {Model}," +
                $" Color: {Color}," +
                $" Year: {Year}"
                );
            Console.ResetColor();
        }

        public override void Start()
        {
            Console.WriteLine($"{Brand} {Model} started with classic ");
        }
    }
}

