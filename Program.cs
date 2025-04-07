namespace ConsoleApp6
{
    internal class Program
    {

        static int MAX_ROOMS = 100;
        static int[] roomNumbers = new int[MAX_ROOMS];
        static double[] roomRate = new double[MAX_ROOMS];
        static bool[] isReserved = new bool[MAX_ROOMS];
        static string[] guestNames = new string[MAX_ROOMS];
        static int[] nights = new int[MAX_ROOMS];
        static DateTime[] bookingDates = new DateTime[MAX_ROOMS];
        static int roomcount = 0;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nChoose one of them:");
                Console.WriteLine("1.Add a new room");
                Console.WriteLine("2.View all rooms");
                Console.WriteLine("3.Reserve a room for a guest .");
                Console.WriteLine("4.View all reservations with total cost ");
                Console.WriteLine("5.Search reservation by guest name ");
                Console.WriteLine("6.Find the highest-paying guest ");
                Console.WriteLine("7.Cancel a reservation by room number ");
                Console.WriteLine("8.Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: AddNewRoom(); break;
                    case 2: ViewAllRooms(); break;
                    case 3: ReserveRoom(); break;
                    case 4: ViewAllReservations(); break;
                    case 5: SearchReservation(); break;
                    case 6: HighestPaying(); break;
                    // case 7:CancelReservation;break;
                    case 0: return;
                    default: Console.WriteLine("Invaild Choies ,try again!"); break;
                }
                Console.ReadLine();
            }
        }

        static void AddNewRoom()
        {
            if (roomcount >= MAX_ROOMS)
            {
                Console.WriteLine("Room capacity reached!");
                return;
            }

            Console.WriteLine("Enter the room number:");
            int RoomNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i > roomcount; i++)
            {
                if (roomNumbers[i] == RoomNumber)
                {
                    Console.WriteLine("Room number must be unique ");
                    return;
                }
            }

            Console.WriteLine("Enter the dailay reat (>=100)");
            double rate = double.Parse(Console.ReadLine());

            if (rate < 100)
            {
                Console.WriteLine("The rate must be >=100");

            }
            else
            {
                roomNumbers[roomcount] = RoomNumber;
                roomRate[roomcount] = rate;

                Console.WriteLine($"Room Number: {roomNumbers[roomcount]},\n Room rate: {roomRate[roomcount]}");

                roomcount++;
                Console.WriteLine("Room added successfully!");
            }
            Console.WriteLine("Do you want continu? y/n");
            if (Console.ReadKey().KeyChar == 'N' || Console.ReadKey().KeyChar == 'n') ;

        }
        static void ViewAllRooms()
        {
            for (int i = 0; i < roomcount; i++)
            {
                if (isReserved[i])
                {
                    double totalcost = roomRate[i] * nights[i];
                    Console.WriteLine($"Room {roomNumbers[i]}: Reseved by {guestNames[i]}, Total cost:{totalcost}");
                }
                else
                {
                    Console.WriteLine($"Room{roomNumbers[i]}:Available");
                }
            }

        }
        static void ReserveRoom()
        {
            Console.WriteLine("Enter gust name: ");
            string guestName = Console.ReadLine();

            Console.WriteLine("Enter Room Number: ");
            int roomNumber = int.Parse(Console.ReadLine());

            int roomIndex = -1;
            for (int i = 0; i < roomcount; i++)
            {
                if (roomNumbers[i] == roomNumber)
                {
                    roomIndex = i;
                    break;
                }
            }
            if (roomIndex == -1)
            {
                Console.WriteLine("Room dose not exist!");
                return;
            }
            if (isReserved[roomIndex])
            {
                Console.WriteLine("Room Already Reserved");
                return;
            }
            Console.WriteLine("Enter number of nights: ");
            int numberOfNihts = int.Parse(Console.ReadLine());
            if (numberOfNihts <= 0)
            {
                Console.WriteLine("Number of nihats must be gratrt than 0!");
                return;
            }
            isReserved[roomIndex] = true;
            guestNames[roomIndex] = guestName;
            nights[roomIndex] = numberOfNihts;
            bookingDates[roomIndex] = DateTime.Now;
            Console.WriteLine("Room reserved successfully!");
        }
        static void ViewAllReservations()
        {
            for (int i = 0; i < roomcount; i++)
            {
                if (isReserved[i])
                {
                    double totalCost = roomRate[i] * nights[i];
                    Console.WriteLine($"Gust:{guestNames[i]},\nRoom:{roomNumbers[i]},\nNights:{nights[i]},\nRate:{roomRate[i]},\nTotal Cost:{totalCost}");
                }
            }
        }
        static void SearchReservation()
        {
            Console.WriteLine("Enter Name to search: ");
            string searchName = Console.ReadLine().ToLower();

            bool found = false;
            for (int i = 0; i < roomcount; i++)
            {
                if (isReserved[i] && guestNames[i].ToLower() == searchName)
                {
                    double totalCost = roomRate[i] * nights[i];
                    Console.WriteLine($"Guest: {guestNames[i]}, Room {roomNumbers[i]}, Nights: {nights[i]}, Rate: {roomRate[i]}, Total Cost: {totalCost}");
                    found = true;
                }
                if (!found)
                {
                    Console.WriteLine("Not Found!");
                }

            }
        }
        static void HighestPaying()
        {
            double maxCost = 0;
            string highest = "None";
            for(int i = 0; i < roomcount; i++)
            {
                if (isReserved[i])
                {
                    double totalCost = roomRate[i] * nights[i];
                    if (totalCost > maxCost)
                    {
                        maxCost = totalCost;
                        highest = guestNames[i];
                    }
                    Console.WriteLine($"Highest-Paying Guest: {highest}, Total Paid: {maxCost}");
                }
            }
            }
        public void CancelReservation()
        {
            
        }
    }
}

    


