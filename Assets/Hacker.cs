using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game configuration data
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] level3Passwords = { "starfield", "telescope", "environment", "exploration", "astronauts" };

    // Game State
    int level;
    string password;
    enum Screen { MainMenu, Password, Win };
    Screen curScreen;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }
    
    void ShowMainMenu()
    {
        curScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("**WARNING: DO NOT PROCEED**");
        Terminal.WriteLine("If you really want to proceed.... :)");
        Terminal.WriteLine("\nPress 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine("\nEnter your selection or enter secret agent names:");
        return;
    }

    void OnUserInput(string input)
    {
        print(input);
        if (input.ToLower() == "menu")
        {
            curScreen = Screen.MainMenu;
            ShowMainMenu();
        }
        else if(curScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        } else if(curScreen == Screen.Password)
        {
            RunCheckPassword(input);
        }
        

    }

    void RunMainMenu(string input)
    {
        bool isLevelInputValid = (input == "1" || input == "2" || input == "3");
        if (isLevelInputValid)
        {
            level = int.Parse(input);
            StartGame();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Mr. Bond, please choose a level! Thank you :)\n");
        }
        else if (input.ToLower() == "alex")
        {
            Terminal.WriteLine("Fick dich! Can you not read?... Hündin...\n");
        }
        else if (input.ToLower() == "andre")
        {
            Terminal.WriteLine("HOT POT!\n");
        }
        else
        {
            Terminal.WriteLine("Please enter a valid difficulty level\n");
        }
    }

    void RunCheckPassword(string input)
    {
        if(input != password)
        {
            Terminal.WriteLine("Wrong password! Please try again...");
        }
        else
        {
            ShowWinScreen();
        }
    }

    void ShowWinScreen()
    {
        curScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
    ________
   /       //
  /       //
 /       //
(_______(/
                ");
                break;
            case 2:
                Terminal.WriteLine("Have a key...");
                Terminal.WriteLine(@"
 ___
/ 0 \___________
\___/---\/=\/-\/           
                ");
                break;
            case 3:
                Terminal.WriteLine("Have a rocket...");
                break;
            default:
                Debug.LogError("You have been surrounded :)");
                break;
        }
        Terminal.WriteLine("Log in successful!");
    }

    void StartGame()
    {
        curScreen = Screen.Password;
        Terminal.ClearScreen();
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                print("hello");
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("INVALID LEVEL NUMBER!");
                break;
        }
        Terminal.WriteLine("Enter your password: ");
    }
}
