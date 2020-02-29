using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    string[] passwords = { "apple", "difficulty", "springtime"};

    //Game State
    int level;
    string password;

    enum Screen { MainMenu, Password, Win };
    Screen currentScreen = Screen.MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu(); 
        }
        else if(currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if(currentScreen == Screen.Password)
        {
            GuessPassword(input);
        }
        else if(currentScreen == Screen.Win)
        {
            currentScreen = Screen.MainMenu;
            ShowMainMenu();
        }
    }

    void GuessPassword(string input)
    {
        if(input == password)
        {
            currentScreen = Screen.Win;
            Terminal.WriteLine("HOLY SHIT YOU GOT IT!");
            Terminal.WriteLine("Press enter to continue");
        }
        else
        {
            Terminal.WriteLine("Wrong Password, try again.");
        }
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome to Terminal hacker!");
        Terminal.WriteLine("What would you like to do?");
        Terminal.WriteLine("");
        Terminal.WriteLine("1. Hack Home PCs");
        Terminal.WriteLine("2. Hack Remote Servers");
        Terminal.WriteLine("3. Hack Government Systems");
        Terminal.WriteLine("Enter your selection:");
    }

    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            password = "apple";
            currentScreen = Screen.Password;
            StartLevel();
        }
        else if (input == "2")
        {
            level = 2;
            password = "difficulty";
            currentScreen = Screen.Password;
            StartLevel();
        }
        else if (input == "3")
        {
            level = 3;
            password = "springtime";
            currentScreen = Screen.Password;
            StartLevel();
        }
        else if (input == "supersecret")
        {
            Terminal.WriteLine("Your secret is safe with me");
        }
        else
        {
            Terminal.WriteLine("Please select a valid level.");
        }
    }

    void StartLevel()
    {
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please enter your password: ");
    }
}
