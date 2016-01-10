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

        }
    }
}

public enum CoffeeOptions
{
    BLACK = 1,
    CREAM_AND_SUGAR,
    CREAM_AND_SUGAR_FREE,
    MILK_AND_SUGAR,
    MILK_AND_SUGAR_FREE
}

class CoffeeOrder
{
    // properties
    private int orderNum;
    private string ingredient;
    private double orderPrice;

    // constants
    const double PRICEOFCOFFEE = 1.95;
    const double CREAMSUGAR = 0.25;
    const double CREAMSUGARFREE = 0.40;
    const double MILKSUGAR = 0.25;
    const double MILKSUGARFREE = 0.40;

    // method prompts user for coffee order
    public void getUserOrder()
    {
        int userCoffeeChoice;

        Console.WriteLine("You are ordering a fine cup of coffee! What would you like in it?");
        Console.WriteLine("1. Black");
        Console.WriteLine("2. Cream and Sugar, add $0.25");
        Console.WriteLine("3. Cream and Artificial Sweetner, add $0.40");
        Console.WriteLine("4. Milk and Sugar, add $0.30");
        Console.WriteLine("5. Milk and Artificial sweetner, add $0.40");
        Console.Write("Please enter your selection from 1 to 5: ");

        try
        {
            userCoffeeChoice = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception)
        {

            throw;
        }
    }

    // method calculates price of user coffee
    public void calculateCoffeePrice(int userCoffeechoice)
    {
        double coffeePrice = PRICEOFCOFFEE;

        // switch statement evaluates input and calculates price
        switch (userCoffeechoice)
        {
            case 1:
                break;
            case 2:
                coffeePrice += CREAMSUGAR;
                break;
            case 3:
                coffeePrice += CREAMSUGARFREE;
                break;
            case 4:
                coffeePrice += MILKSUGAR;
                break;
            case 5:
                coffeePrice += MILKSUGARFREE;
                break;
            default:
                Console.WriteLine("Invalid Option, Please Choose Again.\n");
                getUserOrder();
                break;
        }

        coffeePrice = orderPrice;
    }
}