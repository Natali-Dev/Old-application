//Lägga till stöd för att ta bort artiklar från beställningen.
//    Implementera möjlighet att spara och läsa beställningar från en fil.
//    Skapa en metod för att rensa beställningen.


using static Program;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Välkommen!");
        Order order = new Order(); // Skapat ett objekt från klassen Order med variabeln order.

        order.AddItem("Pizza", 125, 0);
        order.AddItem("Dryck", 19.99, 0);
        order.AddItem("Pommes", 30, 0);

        while (true)
        {
            order.StartMenu();
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1: // se restaurangmeny
                    order.PrintMenu();

                    break;

                case 2: // lägg beställning

                    //order = new Order();

                    order.PlaceOrder();
                    break;

                case 3: // se alla beställningar
                    order.PrintOrder(); // skriver ut hela listan list.
                    break;

                case 4:// ta bort
                    //order.RemoveAt
                    break;

                case 5:// rensa
                    //order.Clear
                    break;

                default:
                    Console.WriteLine("Ogiltig inmatning");
                    break;

            }
        }

    }

    public class Order
    {
        List<OrderItem> list = new(); // global lista (vit)

        public Order()
        { // Initierar en tom lista för att lagra beställningsartiklar.
            this.list = new List<OrderItem>();
        }

        public void AddItem(string name, double price, int quantity)
        //Lägger till en artikel i beställningen. Om en artikel med samma namn redan finns, ska kvantiteten ökas istället för att skapa en ny artikel.
        {

            for (int i = 0; i < list.Count; i++)
            {

                if (list[i].Name == name) // Om en match finns i listan
                {
                    list[i].Quantity += quantity; // öka kvantiten
                    return;
                }

            }
            // annars, lägg till i listan
            list.Add(new OrderItem(name, price, quantity)); // Skapar ett nytt orderItem objekt och lägger till det i listan!!!!!

        }

        public double CountTotal()
        //Beräknar och returnerar den totala kostnaden för beställningen.
        {
            double total = 0;

            for (int i = 0; i < list.Count; i++)
            {
                total += list[i].Quantity * list[i].Price;

            }

            Console.WriteLine("Totalbelopp: " + Math.Round(total, 2));
            return total;
        }

        public void PrintOrder()
        //Skriver ut hela beställningen med artikelnamn, pris och kvantitet till konsolen.
        {
            Console.WriteLine("Beställning: ");
            for (int i = 0; i < list.Count; i++)
            {

                Console.WriteLine($"{i + 1}. {list[i].Name}. {list[i].Price} kr x {list[i].Quantity} st ");

            }

        }
        public void StartMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("1. Se meny");
            Console.WriteLine("2. Lägg beställning");
            Console.WriteLine("3. Se alla beställningar");
            Console.WriteLine("4. Ta bort beställning");
            Console.WriteLine("5. Rensa beställning");
            Console.WriteLine("6. Spara & ladda upp");
            Console.Write("Gör ett val: ");

            Console.ResetColor();
        }
        public void PlaceOrder()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Gör ett val: ");
            string item = Console.ReadLine();
            Console.Write("Antal: ");
            int quant = Convert.ToInt32(Console.ReadLine());
            list.Add(new OrderItem(item, list[0].Price, quant));
            Console.ResetColor();
        }
        public void PrintMenu()
        {
            //Skriver ut hela menyn med artikelnamn, pris och kvantitet till konsolen.
            Console.WriteLine("----MENY----");
            for (int i = 0; i < list.Count; i++)
            {

                Console.WriteLine($"Nr: {i + 1}. {list[i].Name}   {list[i].Price} kr");

            }
        }
        public class OrderItem
        {
            string name;
            double price;
            int quantity;


            public OrderItem(string name, double price, int quantity)
            {
                this.name = name;
                this.price = price;
                this.quantity = quantity;

            }
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public double Price
            {
                get { return price; }
                set { price = value; }
            }

            public int Quantity
            {
                get { return quantity; }
                set { quantity = value; }
            }

        }

    }
}

/*
Testkör

Din klass ska testas med följande kodstycke:

csharp

Order order = new Order();
order.AddItem("Pizza", 99.99, 2);
order.AddItem("Dryck", 19.99, 1);
order.AddItem("Pizza", 99.99, 1); // Öka kvantitet
order.PrintOrder();
Console.WriteLine($"Total: {order.CountTotal()} kr");

Utskriften vid exekvering ska se ut så här:



Beställning:
1.Pizza - 99.99 kr x 3
2. Dryck - 19.99 kr x 1
Total: 319.96 kr

Implementering

Implementera klassen så att den kan användas i en restaurang-applikation.
Utökningar

Om du har tid över kan du:

    Lägga till stöd för att ta bort artiklar från beställningen.
    Implementera möjlighet att spara och läsa beställningar från en fil.
    Skapa en metod för att rensa beställningen.
*/