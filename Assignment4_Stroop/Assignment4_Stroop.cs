using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Jacob Stroop
CIS353 - Assignment 4
1/10/2015
*/

namespace Assignment4_Stroop
{
    class Assignment4_Stroop
    {
        static void Main(string[] args)
        {
            // initialize array to hold 10 coffee order objects
            CoffeeOrder[] orders = new CoffeeOrder[10];

            // variable for array position
            int x = 0;
            // sentinel value for while loop
            bool continueOrder = true;

            // while loop accepts new coffee orders until
            // user selects to stop or 10 orders are added to fill array
            while (continueOrder == true && x < orders.Length)
            {
                // instantiate new coffee order at array index
                orders[x] = new CoffeeOrder();

                // call method to get new order, passing the counter
                // by reference to update order number
                orders[x].getUserOrder(x);

                // if array is full, do not ask to continue order
                if (x == orders.Length - 1)
                {
                    Console.WriteLine("Max Coffee Orders Reached.");
                    continueOrder = false;
                }
                // else if array is full, call method to ask for new order
                else
                {
                    continueOrder = askForNewOrder();
                    // if new order requested, increment index
                    if (continueOrder) x++;
                }
            }

            // for loop calls method to display
            // details for each order
            for(int i = 0; i <= x; i++)
            {
                orders[i].displayUserOrder();
                Console.WriteLine();
            }

            // wait for user k to quit
            Console.ReadKey();
        }

        // method prompts user to enter a selection to continue
        // ordering or to quit (I felt with 4 possible test conditions, it was easier
        // to evaluate them in a switch statement than in the while loop conditions. 
        // I also chose to use a boolean sentinel since it can only be set true/false 
        static bool askForNewOrder()
        {
            Console.Write("\nDo you want to order another cup of coffee? ");

            char userInput = Convert.ToChar(Console.ReadLine());

            while(true)
            {
                switch (userInput)
                {
                    case 'y':
                    case 'Y':
                        return true;
                    case 'n':
                    case 'N':
                        return false;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid Option. Please enter (Y/n).");
                        Console.WriteLine();
                        askForNewOrder();
                        break;
                }
            }
        }
    }

    // enum defines valid user input
    // (I got a little carried away trying to most efficiently
    // validate input and reference the price/string of the
    // possible ingredients. I'm sure there's a better way than
    // using an enumeration and extension methods, but I got
    // too deep down the rabbit hole here to try to do anything else)
    public enum CoffeeOptions
    {
        BLACK = 1,
        CREAM_AND_SUGAR,
        CREAM_AND_SUGAR_FREE,
        MILK_AND_SUGAR,
        MILK_AND_SUGAR_FREE
    }

    // class contains methods to extend CoffeeOptions enum
    public static class CoffeeOptionsMethods
    {
        // returns additional price based on each coffee option
        public static double additionalPrice(this CoffeeOptions option)
        {
            switch (option)
            {
                case CoffeeOptions.BLACK:
                default:
                    return 0.00;
                case CoffeeOptions.CREAM_AND_SUGAR:
                    return 0.25;
                case CoffeeOptions.MILK_AND_SUGAR:
                    return 0.30;
                case CoffeeOptions.CREAM_AND_SUGAR_FREE:
                case CoffeeOptions.MILK_AND_SUGAR_FREE:
                    return 0.40;
            }
        }

        // returns string of corresponding coffee option
        public static string toString(this CoffeeOptions option)
        {
            switch (option)
            {
                case CoffeeOptions.BLACK:
                default:
                    return "Just Black";
                case CoffeeOptions.CREAM_AND_SUGAR:
                    return "Cream & Sugar";
                case CoffeeOptions.CREAM_AND_SUGAR_FREE:
                    return "Cream & Sugar Free Sweetner";
                case CoffeeOptions.MILK_AND_SUGAR:
                    return "Milk & Sugar";
                case CoffeeOptions.MILK_AND_SUGAR_FREE:
                    return "Milk & Sugar Free Sweetner";
            }
        }
    }

    // CoffeeOrder class describes each coffee order
    class CoffeeOrder
    {
        // properties
        private int orderNumber; // unique
        private CoffeeOptions coffeeOptions; // ingredients
        private double orderPrice; // total order price

        // price constants
        const double PRICEOFCOFFEE = 1.95;

        // method calls display order menu, get input, and update properties 
        public void getUserOrder(int orderCount)
        {
            setOrderNumber(orderCount);
            displayMenu();
            setCoffeeOptions();
            setorderPrice();
        }

        // sets order number property
        // adds 1 to the current completed
        // order count
        private void setOrderNumber(int orderCount)
        {
            orderNumber = orderCount + 1;
        }

        // method displays menu
        private void displayMenu()
        {
            Console.WriteLine("\nYou are ordering a fine cup of coffee! What would you like in it?\n");
            Console.WriteLine("1. Black");
            Console.WriteLine("2. Cream and Sugar, add $0.25");
            Console.WriteLine("3. Cream and Artificial Sweetner, add $0.40");
            Console.WriteLine("4. Milk and Sugar, add $0.30");
            Console.WriteLine("5. Milk and Artificial sweetner, add $0.40");
            Console.WriteLine();
            Console.Write("Please enter your selection from 1 to 5: ");
        }

        // Takes user input, ensuring it is an integer,
        // evaluates input in switch statement to determine
        // the selection is valid, then updates the coffeeOptions property
        private void setCoffeeOptions()
        {
            int userCoffeeChoice;

            // while block executes until input is an integer,
            // then assigns value to userCoffeeChoice
            while (!int.TryParse(Console.ReadLine(), out userCoffeeChoice))
            {
                Console.WriteLine("Invalid Option, Please Choose Again.\n");
                Console.Write("Please enter your selection from 1 to 5: ");
            }

            // switch statement evaluates input and sets coffeeOptions
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
                default: // default displays error, recursive method call
                    Console.WriteLine("Invalid Option, Please Choose Again.\n");
                    setCoffeeOptions();
                    break;
            }
        }

        // method sets price by using enum method to
        // look up how much the selected coffee options are
        // and add this amount to PRICEOFCOFFEE constant
        private void setorderPrice()
        {
            orderPrice = PRICEOFCOFFEE + coffeeOptions.additionalPrice();
        }

        // method displays order details
        public void displayUserOrder()
        {
            Console.WriteLine();
            Console.WriteLine("Order Number: " + orderNumber);
            Console.WriteLine("Amount of Order: " + orderPrice.ToString("C"));
            Console.WriteLine("How you take your coffee:\n" + coffeeOptions.toString());
        }
    }
}