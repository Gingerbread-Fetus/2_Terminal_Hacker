using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    private static void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome to Terminal hacker!");
        Terminal.WriteLine("What would you like to do?");
        Terminal.WriteLine("");
        Terminal.WriteLine("1. Hack Home PCs");
        Terminal.WriteLine("2. Hack Remote Servers");
        Terminal.WriteLine("3. Hack Government Systems");
        Terminal.WriteLine("Enter your selection:");
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
        else if(input == "1")
        {
            print("You chose level 1");
        }
        else if (input == "2")
        {
            print("You chose level 2");
        }
        else if (input == "3")
        {
            print("You chose level 3");
        }
        else if(input == "secretsecret")
        {
            print("Your secret is safe with me.");
        }
        else
        {
            print("Please select a valid level");
        }
    }
}
