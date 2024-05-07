


class InventoryManager
{
    List<Item> inventory;

    public InventoryManager(List<Item> inventory)
    {
        this.inventory = inventory;
    }
    
    public InventoryManager()
    {
        this.inventory = new List<Item>();
    }

    public List<Item> getInventory() {  return inventory; }
    public void addItem(Item item)
    {
        inventory.Add(item);
    }
    public void removeItem (Item item) { inventory.Remove(item);}

    public Item SelectItem(string n)
    {
        if (inventory.Count <= 0) { return null; }

        for (int i = 0; i < inventory.Count; i++)
        {
            Item item = inventory[i];
            if (item.name.Equals(n))
            {
                return item;
            }
        }
        return null;
    }
    public void updateItem(Item item, string field, string val)
    {

        int intVal;
        double doubleVal;
        
        

        switch (field)
        {
            case "id":
                intVal = int.Parse(val);
                item.id = intVal;
                break;
            case "name":
                item.name = val;
                break;
            case "description":
                item.description = val;
                break;
            case "quantity":
                intVal = int.Parse(val);
                item.quantity = intVal;
                break;
            case "price":
                doubleVal = double.Parse(val);
                item.price = doubleVal;
                break;

            default: 
                Console.WriteLine("Field does not exist"); 
                break;
        }
        
    }

    public void printItems()
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            Console.WriteLine("ID: {0}, Name: {1}, Description: {2}, Quantity: {3}, Price: {4}", 
                                inventory[i].id, inventory[i].name, inventory[i].description, 
                                inventory[i].quantity, inventory[i].price);

        }
    }

}