using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public string mainMenuName = "MainMenu";                    //gets string of main menu name
    public SceneFader sceneFader;                              
    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);  //fades to current scene
    }
    public void Menu()
    {
        sceneFader.FadeTo(mainMenuName);                        //fades to main menu
    }
}
