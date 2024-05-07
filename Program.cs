

using System.Diagnostics.Metrics;
using System.Windows.Markup;

class Program
{
    private static void addChoice(int counter,InventoryManager inventory)
    {
        Console.WriteLine("Please enter the values, seperated by commas: name, description, quantity, price");
        string userInput = Console.ReadLine();
        string[] vals;

        try
        {
            vals = userInput.Split(",");

            for (int i = 0; i < vals.Length; i++)
            {
                vals[i] = vals[i].Trim();
            }

            if (vals.Length != 4)
            {
                return;
            }

            //hard code id's

            Item tempItem = new Item(counter, vals[0], vals[1], int.Parse(vals[2]), double.Parse(vals[3]));

            inventory.addItem(tempItem);
            counter++;
          
        }
        catch (FormatException e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
        
    }

    private static void removeChoice(InventoryManager inventory)
    {
        Console.WriteLine("Please enter the name of the Item you would like to be removed");
        string userInput = Console.ReadLine();
        Item selectedItem = inventory.SelectItem(userInput);
        if (selectedItem == null)
        {
            Console.WriteLine("Item DNE");
        }
        inventory.removeItem(selectedItem);
        Console.WriteLine("Selected item has been removed");
        
    }

    private static Item selectItemChoice(InventoryManager inventory)
    {
        Console.WriteLine("Please type the name of the item you would like to select");
        inventory.printItems();
        string userInput = Console.ReadLine();
        Item selectedItem = inventory.SelectItem(userInput);
        if (selectedItem == null)
        {
            Console.WriteLine("Item DNE");
            return null;
        }
        return selectedItem;
    }
    private static void updateChoice(InventoryManager inventory)
    {
        Item item = selectItemChoice(inventory);
        if(item == null)
        {
            return;
        }
        Console.WriteLine("What field would you like to edit: id, name, description, quantity, price");
        string userInput = Console.ReadLine();
        Console.WriteLine("What value would you like to update it too?");
        string updatedValue = Console.ReadLine();

        try
        {
            inventory.updateItem(item, userInput, updatedValue);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    static void Main(string[] args)
    {
        //Item testItemOne = new Item(1, "testName", "testDescription", 3, 3.44);
        //Item testItemTwo = new Item(2, "testName2", "testDescription2", 222, 22.22);

        InventoryManager inventory = new InventoryManager();

        //inventory.addItem(testItemOne);
        //inventory.addItem(testItemTwo);



        inventory.printItems();


        bool gameLoop = true;
        int counter = 0;
        while (gameLoop){
            Console.WriteLine("What would you like to do? 1. add item, 2. remove item, " +
                            "3. print item, 4. update item, 5. quit");
            int userChoice = int.Parse(Console.ReadLine());

            //inventory.printItems();

            switch (userChoice)
            {
                case 1:
                    addChoice(counter, inventory);
                    break;
                case 2:
                    removeChoice(inventory);
                    break;
                case 3:
                    inventory.printItems();
                    break;
                case 4:
                    updateChoice(inventory);
                    break;
                case 5:
                    gameLoop = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Not an option");
                    break;
            }
        }
    }
}