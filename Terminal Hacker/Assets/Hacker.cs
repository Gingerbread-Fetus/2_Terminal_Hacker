using UnityEngine;

public class Hacker : MonoBehaviour
{
    const string menuHint = "You may type menu at any time to return to the menu";
    //Game configuration data
    string[] level1Passwords = { "apple", "books", "aisle", "self", "password", "font", "borrow"};
    string[] level2Passwords = { "autonomy", "dignity", "conflicting", "poison", "improvement", "coincidence", "litigation"};
    string[] level3Passwords = { "understanding", "consciousness", "constellation", "strikebreaker", "comprehensive", "entertainment", "concentration" };

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
            DisplayWinScreen();
        }
        else
        {
            StartLevel();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("You did it! Have a gold star!");
                Terminal.WriteLine(@"
     /\
____/  \____
\          /
 >        <
/___    ___\
    \  /
     \/");
                break;
            case 2:
                Terminal.WriteLine("You did it! Have another star!");
                Terminal.WriteLine(@"
       ,O,
      ,OOO,
'oooooOOOOOooooo'
  `OOOOOOOOOOO`
    `OOOOOOO`
    OOOO'OOOO
   OOO'   'OOO
  O'         'O");
                break;
            case 3:
                Terminal.WriteLine("You did it! Take the big dipper!");
                Terminal.WriteLine(@"
   *   '*
           *
                *
                       *
               *
                     *");
                break;
        }
        Terminal.WriteLine("Press enter to continue");
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
        Terminal.WriteLine(menuHint);
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = int.TryParse(input,out level);
        if (isValidLevelNumber)
        {
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
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine(menuHint);
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
    }

    private void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }
}
