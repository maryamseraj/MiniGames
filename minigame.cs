using System;

namespace _NETApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAppInfo();

            GreetUser();

            Menu();
        }

        // menu
        static void Menu()
        {
            int choice = 0;
            // menu to select game
            Console.WriteLine("Welcome, please choose a game");
            Console.WriteLine("=============================");
            Console.WriteLine("1: Guessing the number game");
            Console.WriteLine("=============================");
            Console.WriteLine("2: Guessing the number game 2");
            Console.WriteLine("=============================");
            Console.WriteLine("3: Fortune Teller");
            Console.WriteLine("=============================");
            Console.WriteLine("4: Quit Menu");
            Console.WriteLine("=============================");

            while (choice == 0)
            {
                try
                {
                    Console.Write("\nPlease select an option: ");
                    choice = int.Parse(Console.ReadLine());
                    
                }
                catch (FormatException)
                {
                    PrintColourMessage(ConsoleColor.Red, "Please enter an integer");
                }
                if (choice < 1 || choice > 4)
                {
                    PrintColourMessage(ConsoleColor.Red, "Please select an option between 1 and 4");
                }
            }
            
            switch (choice) // starts game based on user input
            {
                case 1:
                    Console.WriteLine("\nYou have selected Guessing the number game");
                    NumberGuessingGame(); // starts game 1
                    break;
                case 2:
                    Console.WriteLine("\nYou have selected Guessing the number game 2");
                    NumberGuessingGameTwo(); // starts game 2 
                    break;
                case 3:
                    Console.WriteLine("\nYou have selected Fortune Teller");
                    FortuneTeller(); // starts game 3
                    break;
                case 4:
                    System.Environment.Exit(1); // closes application
                    break;
                default:
                    PrintColourMessage(ConsoleColor.Red, "Please select an option between 1 and 4");
                    break;
            }
        }


        // get and display app info
        static void GetAppInfo()
        {
            // set app vars
            string appName = "Mini games";
            string appVersion = "1.0.0";
            string appAuthor = "Mary";

            // change text colour
            Console.ForegroundColor = ConsoleColor.Green;

            // write out app info
            Console.WriteLine("{0}: Version {1} by {2}", appName, appVersion, appAuthor);
            Console.ResetColor();
        }

        // ask users name and greet
        static void GreetUser()
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello {name}");
        }

        // print colour message
        static void PrintColourMessage(ConsoleColor color, string message)
        {
            // change text colour
            Console.ForegroundColor = color;

            Console.WriteLine(message);
            Console.ResetColor();
        }

        // guessing the number game
        static void NumberGuessingGame()
        {
            while (true)
            {
                // create a new Random object
                Random random = new Random();

                int correctNumber = random.Next(1, 10);
                int guess = 0;
                int NumberOfGuesses = 2;
                string answer;

                while (guess != correctNumber)
                {
                    // get users input and validate
                    try
                    {
                        Console.Write("Guess a number between 1 and 10: ");
                        guess = Convert.ToInt16(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        PrintColourMessage(ConsoleColor.Red, "Please enter an integer");
                    }
                    
                    if (NumberOfGuesses == 0)
                    {
                        Console.WriteLine("Out of guesses");
                        Console.WriteLine("Play again? [Y or N]");
                        answer = Console.ReadLine().ToUpper();
                        if (answer == "Y") NumberGuessingGame(); else Menu();
                    } 
                    else if (guess <= 0 || guess > 10)
                    {
                        PrintColourMessage(ConsoleColor.Red, "Please enter a number between 1 and 10"); // prompts user for valid input
                        continue;
                    }
                    if (guess != correctNumber)
                    {
                        PrintColourMessage(ConsoleColor.Blue, "Wrong number, try again");
                        NumberOfGuesses--;
                    }
                }
                PrintColourMessage(ConsoleColor.Green, "Correct, you guessed it");  // output success message
                Console.WriteLine("Play again? [Y or N]");
                answer = Console.ReadLine().ToUpper();
                if (answer == "Y") NumberGuessingGame(); else Menu();
            }
        } // end of number guessing game 1


        // guessing the number game 2
        static void NumberGuessingGameTwo()
        {
            while (true)
            {
                // create a new Random object
                Random random = new Random();

                int correctNumber = random.Next(1, 50);
                int guess = 0;
                int NumberOfGuesses = 5;

                try
                {
                    Console.Write("Guess a number between 1 and 50, I'll give you some clues: ");
                    guess = Convert.ToInt16(Console.ReadLine());
                }
                catch (FormatException)
                {
                    PrintColourMessage(ConsoleColor.Red, "Please enter an integer");
                }

                while (guess != correctNumber)
                {
                    // get users input
                    string input = Console.ReadLine();

                    if (NumberOfGuesses == 0) // when user has no guesses left
                    {
                        Console.WriteLine("Out of guesses");
                    }
                    if (!int.TryParse(input, out guess)) // checks input is an actual number
                    {
                        PrintColourMessage(ConsoleColor.Red, "Please enter an actual number"); // prompts user for valid input
                        continue;
                    }
                    else if (guess <= 0 || guess > 50) // checks input is between 1 and 50
                    {
                        PrintColourMessage(ConsoleColor.Red, "Please enter a number between 1 and 50"); // prompts user for valid input
                        continue;
                    }
                    guess = Int16.Parse(input); // converts input to int
                    if (guess <= correctNumber)
                    {
                        PrintColourMessage(ConsoleColor.Blue, "The correct number is higher");
                        NumberOfGuesses--;
                    }
                    else if (guess >= correctNumber)
                    {
                        PrintColourMessage(ConsoleColor.Blue, "The correct number is lower");
                        NumberOfGuesses--;
                    }
                    else
                    {
                        PrintColourMessage(ConsoleColor.Green, "Correct, you guessed it."); // output success message
                        Console.WriteLine("Play again? [Y or N]");
                        string answer = Console.ReadLine().ToUpper();
                        if(answer == "Y") NumberGuessingGameTwo(); else Menu();
                    }
                }
            }
        } // end of number guessing game 2

        // fortune teller
        static void FortuneTeller()
        {
            int num = 0;
            int choice = 0;
            int length = 0;
            while (num == 0 && choice == 0)
            {
                // gets integer from user
                try
                {
                    Console.Write("Enter a number between 1 and 10: ");
                    num = Convert.ToInt16(Console.ReadLine());
                }
                catch (FormatException)
                {
                    PrintColourMessage(ConsoleColor.Red, "Please enter an integer");
                }
                if (num < 0 || num > 10)
                {
                    PrintColourMessage(ConsoleColor.Red, "Please select an option between 1 and 10");
                }

                Console.WriteLine("Please choose a colour:");
                Console.WriteLine("1: Red");
                Console.WriteLine("2: Blue");
                Console.WriteLine("3: Green");
                Console.WriteLine("4: Yellow");
                Console.WriteLine("5: Orange");
                Console.WriteLine("6: Purple");
                Console.WriteLine("7: Pink");

                // gets colour from user
                try
                {
                    Console.Write("\nChoose a colour: ");
                    num = Convert.ToInt16(Console.ReadLine());
                }
                catch (FormatException)
                {
                    PrintColourMessage(ConsoleColor.Red, "Please enter an integer");
                }
                if (num < 0 || num > 5)
                {
                    PrintColourMessage(ConsoleColor.Red, "Please select an option between 1 and 5");
                }
            }

            switch (choice) // starts game based on user input
            {
                case 1:
                    length = 3;
                    break;
                case 2:
                    length = 4;
                    break;
                case 3:
                    length = 5;
                    break;
                case 4:
                    length = 6;
                    break;
                case 5:
                    length = 6;
                    break;
                case 6:
                    length = 6;
                    break;
                case 7:
                    length = 4;
                    break;
                default:
                    PrintColourMessage(ConsoleColor.Red, "Please select an option between 1 and 4");
                    break;
            }

            // determines output depending on sum of num and length of colour
            if (num + length <= 5)
            {
                Console.WriteLine("1");
            }
            else if (num + length <= 10 && num + length > 5)
            {
                Console.WriteLine("2");
            }
            else if (num + length <= 12 && num + length > 10)
            {
                Console.WriteLine("3");
            }
            else if (num + length <= 15 && num + length > 12)
            {
                Console.WriteLine("4");
            }
            Console.ReadLine();
            Console.WriteLine("Play again? [Y or N]");
            string answer = Console.ReadLine().ToUpper();
            if (answer == "Y") FortuneTeller(); else Menu();
        
            } // end of fortune teller
        } // end of Main
    }  // end of class
} // end of application
