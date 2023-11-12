using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "Level";        //name of level that is being loaded
    public GameObject howToPlay;                //how to play menu UI
    public GameObject resetMenu;                //reset menu UI
    public bool isShowing = false;              //checks if how to play ui is showing
    public bool resetisShowing = false;         //checks if reset ui is showing

    public SceneFader sceneFader;
    public void Play()                          //loads to level to load scene
    {
        sceneFader.FadeTo(levelToLoad);
    }
    public void Quit()                          //exits game
    {
        Application.Quit();
    }
    public void Show()                          //shows UI of how to play menu
    {
        isShowing = !isShowing;
        howToPlay.SetActive(isShowing);
    }
    public void ResetMenu()                     //shows UI of reset menu
    {
        resetisShowing = !resetisShowing;
        resetMenu.SetActive(resetisShowing);
    }
    public void Reset()                         //deletes all prefs, therefore resetting the game
    {
        PlayerPrefs.DeleteAll();
        resetisShowing = !resetisShowing;
        resetMenu.SetActive(resetisShowing);

    }
}
