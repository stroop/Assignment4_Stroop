using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_Stroop
{
    class Assignment4_Stroop
    {
        static void Main(string[] args)
        {
            // initialize array to hold 10 coffee order objects
            CoffeeOrder[] orders = new CoffeeOrder[10];

            // counter for total orders
            int orderCounter = 0;
            // variable for array position
            int x = 0;
            // sentinel value for while loop
            bool continueOrder = true;

            // while loop accepts new coffee orders until
            // user selects to stop or 10 orders are added to fill array
            while (continueOrder)
            {
                // instantiate new coffee order
                CoffeeOrder order = new CoffeeOrder();
                // call method to get new order, passing the counter
                // by reference to update order number
                order.getUserOrder(ref orderCounter);

            }
        }
    }

    // enum defines valid user input
    public enum CoffeeOptions
    {
        BLACK = 1,
        CREAM_AND_SUGAR,
        CREAM_AND_SUGAR_FREE,
        MILK_AND_SUGAR,
        MILK_AND_SUGAR_FREE
    }

    public static class CoffeeOptionsMethods
    {
        public static double additionalPrice(this CoffeeOptions option)
        {
            switch (option)
            {
                case CoffeeOptions.CREAM_AND_SUGAR:
                case CoffeeOptions.MILK_AND_SUGAR:
                    return 0.25;
                case CoffeeOptions.CREAM_AND_SUGAR_FREE:
                case CoffeeOptions.MILK_AND_SUGAR_FREE:
                    return 0.40;
                case CoffeeOptions.BLACK:
                default:
                    return 0.00;
            }
        }

        public static string toString(this CoffeeOptions option)
        {
            switch (option)
            {
                case CoffeeOptions.BLACK:
                default:
                    return "Just Black";
                case CoffeeOptions.CREAM_AND_SUGAR:
                    return "Cream and Sugar";
                case CoffeeOptions.CREAM_AND_SUGAR_FREE:
                    return "Cream and Sugar Free Sweetner";
                case CoffeeOptions.MILK_AND_SUGAR:
                    return "Milk and Sugar";
                case CoffeeOptions.MILK_AND_SUGAR_FREE:
                    return "Milk and Sugar Free Sweetner";
            }
        }
    }

    class CoffeeOrder
    {
        // properties
        private int orderNum;
        private CoffeeOptions coffeeOptions;
        private string coffeeOptionsString;
        private double orderPrice;

        // price constants
        const double PRICEOFCOFFEE = 1.95;

        // method prompts user for coffee order
        public void getUserOrder(ref int orderCounter)
        {
            displayMenu();
            getAndValidateInput();
        }

        // method displays menu
        private void displayMenu()
        {
            Console.WriteLine("You are ordering a fine cup of coffee! What would you like in it?");
            Console.WriteLine("1. Black");
            Console.WriteLine("2. Cream and Sugar, add $0.25");
            Console.WriteLine("3. Cream and Artificial Sweetner, add $0.40");
            Console.WriteLine("4. Milk and Sugar, add $0.30");
            Console.WriteLine("5. Milk and Artificial sweetner, add $0.40");
            Console.Write("Please enter your selection from 1 to 5: ");
        }

        // RENAME
        private void getCoffeeOptions()
        {
            int userCoffeeChoice;

            // while block executes until input is an integer,
            // then assigns value to userCoffeeChoice
            while (!int.TryParse(Console.ReadLine(), out userCoffeeChoice))
            {
                Console.WriteLine("Invalid Option, Please Choose Again.\n");
                Console.Write("Please enter your selection from 1 to 5: ");
            }

            // switch statement evaluates input and calculates price
            switch (userCoffeeChoice)
            {
                case 1:
                    coffeeOptions = CoffeeOptions.BLACK;
                    break;
                case 2:
                    coffeeOptions = CoffeeOptions.CREAM_AND_SUGAR;
                    break;
                case 3:
                    coffeeOptions = CoffeeOptions.CREAM_AND_SUGAR_FREE;
                    break;
                case 4:
                    coffeeOptions = CoffeeOptions.MILK_AND_SUGAR;
                    break;
                case 5:
                    coffeeOptions = CoffeeOptions.MILK_AND_SUGAR_FREE;
                    break;
                default:
                    Console.WriteLine("Invalid Option, Please Choose Again.\n");
                    getCoffeeOptions();
                    break;
            }
        }


        public void setCoffeeOptionsString(CoffeeOptions options)
        {

        }
    }
}