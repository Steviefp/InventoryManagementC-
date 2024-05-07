

class Item
{
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public int quantity { get; set; }
    public double price { get; set; }

    public Item(int id, string name, string description, int quantity, double price)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.quantity = quantity;
        this.price = price;
    }

}