namespace Food_Inventory_App
{
    class Program
    {
        static List<FoodItem> _inventory = new List<FoodItem>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nFood Bank Inventory System");
                Console.WriteLine("1. Add Food Item");
                Console.WriteLine("2. Delete Food Item");
                Console.WriteLine("3. Print List of Current Food Items");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddFoodItem();
                        break;
                    case "2":
                        DeleteFoodItem();
                        break;
                    case "3":
                        PrintFoodItems();
                        break;
                    case "4":
                        Console.WriteLine("Exiting the program. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddFoodItem()
        {
            try
            {
                Console.Write("Enter food name: ");
                string name = Console.ReadLine();

                Console.Write("Enter category: ");
                string category = Console.ReadLine();

                Console.Write("Enter quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Console.Write("Enter expiration date (yyyy-MM-dd): ");
                DateTime expirationDate = DateTime.Parse(Console.ReadLine());

                FoodItem newItem = new FoodItem(name, category, quantity, expirationDate);
                _inventory.Add(newItem);
                Console.WriteLine("Food item added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void DeleteFoodItem()
        {
            Console.Write("Enter the name of the food item to delete: ");
            string name = Console.ReadLine();

            FoodItem itemToRemove = _inventory.Find(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (itemToRemove != null)
            {
                _inventory.Remove(itemToRemove);
                Console.WriteLine("Food item deleted successfully.");
            }
            else
            {
                Console.WriteLine("Food item not found.");
            }
        }

        static void PrintFoodItems()
        {
            if (_inventory.Count == 0)
            {
                Console.WriteLine("No food items in inventory.");
                return;
            }

            Console.WriteLine("\nCurrent Food Items in Inventory:");
            foreach (FoodItem item in _inventory)
            {
                Console.WriteLine(item);
            }
        }
    }
}