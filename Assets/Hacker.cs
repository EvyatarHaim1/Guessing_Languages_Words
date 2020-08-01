
 using UnityEditor;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    const string menuHint = "You may type menu at any time.";
    string[] level1Passwords = { "books", "uniform", "shelf", "password", "font", "prisoner", "arrest" };
    string[] level2Passwords = { "בגדים", "הליכה", "סליחה", "כוכבים", "משפחה", "אמצעים", "מלכות"};
    string[] level3Passwords = { "quiero","hablar","caminar","procupado","verdad","cielo", "tocar" };
    string[] level4Passwords = { "merci", "Maison", "femme", "soleil", "monde", "demain", "langue" };

    int level;
    enum Screen { MainMenu, Password, Win};
    Screen currentScreen;
    string password;

    void Start() 
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        level = 0;
        password = "";
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for test your English");
        Terminal.WriteLine("Press 2 for test your Hebrew");
        Terminal.WriteLine("Press 3 for test your spanish");
        Terminal.WriteLine("Press 4 for test your French");
        Terminal.WriteLine("Enter you selection: ");
    }

    
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("if on the web close the tab");
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

     void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3" || input == "4");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if(input == "007")
        {
            Terminal.WriteLine("Please select a level!");
        }
        else
        {
            Terminal.WriteLine("please type a valid level");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);

    }

    void SetRandomPassword()
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
            case 4:
                password = level4Passwords[Random.Range(0, level4Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
       if(input == password)
        {
            DisplayWithScreeen();
        }
        else
        {
            AskForPassword();
        }

    }

    void DisplayWithScreeen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Your English is quite good!");
                Terminal.WriteLine("Play again to test yourself in other language");
                Terminal.WriteLine(@"
    ________________       
   /      //      //
  /      //      //
 /_____ //______//
(______(/______//    
"
                );
                break;
            case 2:
                Terminal.WriteLine("Your Hebrew is quite good!");
                Terminal.WriteLine("Play again for a greater challenge.");
                Terminal.WriteLine(@"
 __/\__
 \/  \/
 /\  /\   
 ﹋\/﹋
"
                );
                break;
            case 3:
                Terminal.WriteLine("Your Spanish is quite good!");
                Terminal.WriteLine(@"
        ____
       /    \
  ____/______\____
 (________________)
");
                break;
            case 4:
                Terminal.WriteLine("Your French is quite good!");
                Terminal.WriteLine(@"       
     .|.
     |||
     j_I
    .)_(.
    |===|
   //___\\
  /=======\
 /..- ''-..\
 |__|   |__|
");
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
    }
}







