using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game State
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen curScreen;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }
    
    void ShowMainMenu()
    {
        Screen curScreen = Screen.MainMenu;
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
        if (input == "1")
        {
            level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            StartGame();
        }
        else if (input == "3")
        {
            level = 3;
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
        
    }

    void StartGame()
    {
        curScreen = Screen.Password;
        Terminal.WriteLine("You've seleceted level " + level + "\n");
        Terminal.WriteLine("Please enter your password: ");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
