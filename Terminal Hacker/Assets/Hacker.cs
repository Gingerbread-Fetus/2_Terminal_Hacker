using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game State
    int level;

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
            currentScreen = Screen.Password;
            StartLevel();
        }
        else if (input == "2")
        {
            level = 2;
            currentScreen = Screen.Password;
            StartLevel();
        }
        else if (input == "3")
        {
            level = 3;
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
