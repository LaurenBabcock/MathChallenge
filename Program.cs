using System;
using System.Collections.Generic;
//Name: Lauren Babcock
//Date: August 17th, 2017
//Program: Math Challenge
//Purpose: Accept two integer numbers from the user with the same number of digits.
//         Check to see if each corresponding place in the two numbers sums to same total.
//         Output true or false based on the result.

namespace mathChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOne, numberTwo, numberOfdigits;
            string entryOne, entryTwo;
            int[] numberOneDigits;
            int[] numberTwoDigits;

            Console.WriteLine("Welcome. Enter two integers with the same number of digits.");

            //Accept an integer number from the user
            Console.Write("Enter your first number: ");
            entryOne = Console.ReadLine();

            //Accept a second integer number & check to confirm that it is the same number of digits as the first. 
            //If it is not the same number of digits as the first, prompt the user to enter a different number.
            do
            {
                Console.Write("Enter your second number: ");
                entryTwo = Console.ReadLine();

                if (entryOne.Length != entryTwo.Length)
                {
                    Console.WriteLine("Sorry, your integers must have the same number of digits. Try again.");
                }

            } while (entryOne.Length != entryTwo.Length);

            //Convert the strings to integers
            numberOne = Convert.ToInt32(entryOne);
            numberTwo = Convert.ToInt32(entryTwo);
            numberOfdigits = entryOne.Length;

            //Initialize two arrays to store the individual digits of each number
            numberOneDigits = new int[numberOfdigits];
            numberTwoDigits = new int[numberOfdigits];

            //Call the GetIntArray method to separate the number into individual digits
            numberOneDigits = GetIntArray(numberOne);
            numberTwoDigits = GetIntArray(numberTwo);

            //Call the CheckDigitSums method to see if each corresponding place in the two numbers sums to the same total.
            CheckDigitSums(numberOneDigits, numberTwoDigits);
            
            Console.ReadKey();
        }

        //Method: GetIntArray
        //Purpose: Separate an integer of any length into an array of individual digits
        static int[] GetIntArray(int num)
        {
            List<int> listOfDigits = new List<int>();
            while (num > 0)
            {
                listOfDigits.Add(num % 10);
                num = num / 10;
            }
            listOfDigits.Reverse();
            return listOfDigits.ToArray();
        }

        //Method: CheckDigitSums
        //Purpose: Check to see if each corresponding integer in the two arrays of digits sums to the same total. If all sum to the same total, return true. If any sum to a different total, return false.
        static void CheckDigitSums(int [] arrayOfDigitsOne, int [] arrayOfDigitsTwo)
        {
            bool result = true;
            int sumOfPlaceOne;

            //Determine what the first numbers in each array sum to 
            sumOfPlaceOne = arrayOfDigitsOne[0] + arrayOfDigitsTwo[0];

            //Check to see if the other corresponding numbers in each array sum to the same total as the first numbers did
            for(int i = 1; i < arrayOfDigitsOne.Length; i++)
            {
                int sum = arrayOfDigitsOne[i] + arrayOfDigitsTwo[i];
                if (sumOfPlaceOne != sum)
                {
                    result = false;
                }
            }

            //Display the result to the user
            if (result == false)
            {
                Console.WriteLine("The result is: False. Each corresponding place in the two numbers does not sum to the same total");
            }
            else
            {
                Console.WriteLine("The result is: True. Each corresponding place in the two numbers does sum to the same total");
            }   
        }
    }
}
