using MySql.Data.MySqlClient;

namespace demon3;

public class Item()
{
    public required  string Photo { get; set; }
    public required string Name  { get; set; }
    public required string Category  { get; set; }
    public required string description  { get; set; }
    public required int price  { get; set; }
    public required float discount  { get; set; }
}

public class Database
{
    MySqlConnection demo=new MySqlConnection("server=localhost;port=3306;user=root;password=987654321;database=demo");
    
    public List<Item> getItems()
    {
        List<Item> items = new List<Item>();
        demo.Open();
        try
        {
            MySqlCommand cmd = new MySqlCommand(
                "SELECT p.image, p.name as name, p.description, p.price, c.name as category, d.discount FROM products p  JOIN categories c ON p.cateigor = c.id  JOIN discounts d ON p.article = d.article ",
                demo
                );
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var item = new Item()
                {
                    Photo = reader["image"].ToString(),
                    Name = reader["name"].ToString(),
                    Category = reader["category"].ToString(),
                    description = reader["description"].ToString(),
                    price = int.Parse(reader["price"].ToString()),
                    discount = float.Parse(reader["discount"].ToString())
                };
                items.Add(item);
            }
            reader.Close();
        }
        finally
        {
            demo.Close();
        }
        return items;
    }
}