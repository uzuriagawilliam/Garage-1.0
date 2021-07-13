using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0
{
    public class UserInterface
    {        
        IGarageHandler gh = new GarageHandler();

        public void ShowMenu()
        {
            bool flag = true;
            bool AnswerCheck = true;
            string menuAnswer ;
            int i = int.MaxValue;

            do
            {
                Console.Clear();
                Console.WriteLine("SKAPA GARAGE");
                Console.WriteLine("Ange antal platser: ");
                string createGarage = Console.ReadLine();

                if (String.IsNullOrEmpty(createGarage) || !Int32.TryParse(createGarage, out i) || i == 0)//Null check, empty orr intiger
                {
                    continue;
                }
                else
                {
                    gh.CreateGarage(i);
                    break;
                }


            } while (true);            
           
            while(flag)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("---- Main Menu ------");
                    Console.WriteLine("\n1. Check Garage status." +
                        "\n2. Parkera in bil." +
                        "\n3. Sök bil." +
                        "\n4. Ta bort bill." +
                        "\n0  För att avsluta programmet");
                    
                    menuAnswer = Console.ReadLine();
                    
                    if (String.IsNullOrEmpty(menuAnswer) || !Int32.TryParse(menuAnswer, out i) )//Null check, empty orr intiger
                    {
                        Console.Clear();
                        i = int.MaxValue;
                        continue;
                    }
                    else
                    {                        
                        AnswerCheck = false;//Om rätt svar gå ut från loopen till Switchen
                    }

                } while (AnswerCheck);

                switch (i)
                {
                   
                    case 1:
                        CheckGarageStatus();
                        break;
                    case 2:
                        ParkCar();
//                        ParkCar4();//Test code
                        break;
                    case 3:                        
                        SearchCar();
                        break;
                    case 4:                        
                        CarOutOfParking();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;

                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Fel input");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        continue;
                }

            }
        }

        private void CarOutOfParking()
        {
            Console.WriteLine("------ Ta bort bil från garaget---------");
            Console.WriteLine("Mata in registrerings nummer");

            string carRegNumber = Console.ReadLine();//Todo: check inmatnings data

            string handlerMessage = gh.TakeCarOutOfGarage(carRegNumber);

            Console.WriteLine(handlerMessage);
            Console.ReadKey();
        }

        private void SearchCar()
        {
            Console.Clear();
            do
            {
                string switch_on;
                bool AnswerCheck = true;
                int i = int.MaxValue;
                do
                {
                    Console.Clear();
                    Console.WriteLine("-------Sök bil i Garaget--------"
                        + "\n1. Sök registrerings nummer"
                        + "\n2. Sök för färg"
                        + "\n3. Sök för biltyp"
                        + "\n4. Sök för criteria"
                        + "\n0. För att återkomma till main meny");

                    switch_on = Console.ReadLine();

                    if (String.IsNullOrEmpty(switch_on) || !Int32.TryParse(switch_on, out i))//Null check, empty orr intiger
                    {
                        Console.Clear();
                        i = int.MaxValue;
                        continue;
                    }
                    else
                    {
                        AnswerCheck = false;//Om rätt svar gå ut från loopen till Switchen
                    }

                } while (AnswerCheck);

                switch (i)
                {
                    case 1:
                        {                            
                            SerchByRegistNumber();
                            break;
                        }
                    case 2: 
                        {
                            SerchByCarColor();
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            SerchByCarType();
                            Console.ReadKey();
                            break;
                        }
                    case 4:
                        {
                            SerchByCriteria();
                            Console.ReadKey();
                            break;
                        }
                    case 0:
                        return;
                    //default:
                }
            } while (true);
 
        }

        private void SerchByCarType()
        {
            Vehicle[] vehicle = new Vehicle[20];//Todo: kolla antal ???
            Console.Clear();
            Console.WriteLine("\nMata in bil sort");
            Console.WriteLine("(truck, sedan, coupe, Wagons, pickup, convertibles)");

            string carType = Console.ReadLine();
            carType.ToLower();

            vehicle = gh.SearchByCarType(carType);

            if (vehicle.Length == 0)
            {
                Console.WriteLine($"Ingen fordom av sorten {carType} hittades");
            }

            foreach (var item in vehicle)
            {
                Console.WriteLine(item.RegisNumber);
            }
        }
        private void SerchByCriteria()
        {
            Vehicle[] vehicle = new Vehicle[20];//Todo: kolla antal ???
            Console.Clear();
            Console.WriteLine("\nAnge kriterier");
            Console.WriteLine("Bils registreringsnummer, biltyp eller färg");

            string criteria = Console.ReadLine();
            criteria.ToLower();
            var searchCriteria = criteria.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            gh.TestSearch(searchCriteria);
        }

        private void SerchByCarColor()
        {
            Vehicle[] vehicle = new Vehicle[20];//Todo: kolla antal ???
            Console.WriteLine("\nMata in color");
            string carColor = Console.ReadLine();
            carColor.ToLower();
            vehicle = gh.SearchCarByColor(carColor);
            
            if(vehicle.Length == 0)
            {
                Console.WriteLine($"Ingen fordom med color {carColor} hittades");                
            }

            foreach (var item in vehicle)
            {
                Console.WriteLine(item.RegisNumber);                
            }
        }

        private void SerchByRegistNumber()
        {
            Vehicle vehicle = new Vehicle();//Todo: kolla antal ???
            Console.WriteLine("\nMata in registrerings nummer");
            string carReg = Console.ReadLine();//Todo: check inmatnings data

            //Letar efter registrerings nummer
            vehicle = gh.SearchCarByRegNumber(carReg);

            if (vehicle == null)
            {
                Console.WriteLine($"Ingen fordom med registrerings {carReg} hittades");
                Console.ReadKey();
                return;
            }
            Console.WriteLine($"{carReg} finns i garaget och den har {vehicle.CarColor} färg.");
            Console.ReadKey();
        }    

        private void CheckGarageStatus()
        {           
            string freeParkinPlaces = gh.GarageStatus();

            Console.WriteLine(freeParkinPlaces);
            Console.ReadKey();

        }
        public void ParkCar4()
        {
            gh.ParkCar("WAUEH79", "Indigo", "sedan", 4);
            gh.ParkCar("YV16126", "Pink", "coupe", 4);
            gh.ParkCar("WDDGF4H", "Purple", "truck", 18);
            gh.ParkCar("WAUML54", "Yellow", "boat", 0);
        }


        public void ParkCar()
        {

            Console.WriteLine("---Registrera Fordom ------\nRegistrerings nummer:");
            string regNumber = Console.ReadLine();

            Console.WriteLine("Color:");
            string carColor = Console.ReadLine();
            carColor.ToLower();

            Console.WriteLine("Typ av fordon: ");
            Console.WriteLine("(sedan, coupe, pickup, truck, bus, motorcycle, boat)");
            string carType = Console.ReadLine();
            carType.ToLower();

            Console.WriteLine("Antal däck:");
            string carTyres = Console.ReadLine();

            int tires;
            Int32.TryParse(carTyres, out tires);

            switch (carType)
            {
                case "sedan":
                case "coupe":               
                case "pickup":

                    if (!gh.ParkCar(regNumber, carColor, carType, tires))
                    {
                        Console.WriteLine("Garaget är full");
                        Console.ReadKey();
                    }
                    break;
                case "truck":
                    {
                        int tCapacity = 0;
                        Console.WriteLine("Truck cargo apacity");
                        string truckCapacity = Console.ReadLine();

                        Int32.TryParse(truckCapacity, out tCapacity);//Todo: Check in input


                        if (!gh.ParkTruck(regNumber, carColor, carType, tires, tCapacity))
                        {
                            Console.WriteLine("Garaget är full");
                            Console.ReadKey();
                        }
                        break;
                    }
                case "bus":
                    {
                        int numSeat = 0;
                        Console.WriteLine("Antal sitplatser: ");
                        string busNumSeats = Console.ReadLine();

                        Int32.TryParse(busNumSeats, out numSeat);//Todo: Check in input


                        if (!gh.ParkBuss(regNumber, carColor, carType, tires, numSeat))
                        {
                            Console.WriteLine("Garaget är full");
                            Console.ReadKey();
                        }

                    }
                    break;               
                case "motorcycle":
                    { 
                        Console.WriteLine("Märke : ");
                        string vehicleBrand = Console.ReadLine();

                        if (!gh.ParkMc(regNumber, carColor, carType, tires, vehicleBrand))
                        {
                            Console.WriteLine("Garaget är full");
                            Console.ReadKey();
                        }
                    }
                    break;
                case "boat":
                    {
                        Console.WriteLine("Boat type : ");
                        Console.WriteLine("(Fishing, Deck, Bowrider, Catamaran, Trawler,Yacht )");
                        string boatType = Console.ReadLine();
                        boatType.ToLower();

                        if (!gh.ParkBoat(regNumber, carColor, carType, tires, boatType))
                        {
                            Console.WriteLine("Garaget är full");
                            Console.ReadKey();
                        }
                    }
                    break;
                //default:
            }
     
            Console.WriteLine("Bilen är parkerad i garaget");
            Console.ReadKey();

        }
    }
}
