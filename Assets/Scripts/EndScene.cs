using UnityEngine;

public class EndScene : MonoBehaviour       //when game is beaten, end scene is shown
{
    public SceneFader sceneFader;
    
    public void Menu()
    {
        sceneFader.FadeTo("MainMenu");      //fades to main menu
    }
}
