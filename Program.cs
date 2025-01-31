﻿//Lägga till stöd för att ta bort artiklar från beställningen.
//    Implementera möjlighet att spara och läsa beställningar från en fil.
//    Skapa en metod för att rensa beställningen.


using static Program;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Välkommen!");
        Order order = new Order(10); // Skapar ett objekt från klassen Order med variabeln order.

        order.AddItem("Pizza", 125, 0);
        order.AddItem("Dryck", 19.99, 3);
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
                    order.PlaceOrder();
                    break;

                case 3: // se alla beställningar
                    order.PrintOrder(); // skriver ut hela listan list.
                    System.Console.WriteLine("Totalpris: " + order.CountTotal());
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
        private readonly double price;

        public Order(double price)
        { // Initierar en tom lista för att lagra beställningsartiklar.
            this.price=price;
            list = new List<OrderItem>();
        }
            public void PrintMenu()
        {
            //Skriver ut hela menyn med artikelnamn, pris och kvantitet till konsolen.
            Console.WriteLine("----MENY----");
            for (int i = 0; i < list.Count; i++)
            {

                Console.WriteLine($"Nr: {i + 1}. {list[i].name}   {list[i].price} kr");

            }
        }
        public void AddItem(string name, double price, int quantity)
        //Lägger till en artikel i beställningen. Om en artikel med samma namn redan finns, ska kvantiteten ökas istället för att skapa en ny artikel.
        {
                    // Order order = new Order(0); // Skapar ett objekt från klassen Order med variabeln order.

                    // order.AddItem("Pizza", 125, 0);
                    // order.AddItem("Dryck", 19.99, 0);
                    // order.AddItem("Pommes", 30, 0);

            for (int i = 0; i < list.Count; i++)
            {

                if (list[i].name == name) // Om en match finns i listan
                {
                    list[i].quantity += quantity; // öka kvantiten
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
                total += list[i].quantity * list[i].price;

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

                Console.WriteLine($"{i + 1}. {list[i].name}. {list[i].price} kr x {list[i].quantity} st ");
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
            AddItem(item, price, quant);                // Paltskalle att lägger till objekt i list.Add!! givetvis måste du lägga till dom i AddItem()!
            Console.ResetColor();

        }
       
        public class OrderItem // representerar ett specifikt objekt, pizza, dryck, pommes
        {
            public string name  {get; set;}
            public  double price {get; set ;}
            public int quantity {get; set;} 


            public OrderItem(string name, double price, int quantity)
            {
                this.name = name; 
                this.price = price;
                this.quantity = quantity;

            }
         
        }

    }
}
