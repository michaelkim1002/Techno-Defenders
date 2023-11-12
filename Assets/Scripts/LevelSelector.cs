using UnityEngine;
using UnityEngine.UI;
public class LevelSelector : MonoBehaviour
{
    public SceneFader fader;

    public Button[] levelButtons;                                       //array of buttons in level menu

    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached",1);        //index of level reached
        for(int x = 0; x<levelButtons.Length;x++)
        {
            if(x +1 > levelReached)
            {
                levelButtons[x].interactable = false;                   //if index is not reached, button is locked
            }
        }
    }
    public void Select(string levelName)
    {
        fader.FadeTo(levelName);                                        //fades to selected level
    }
    public void Back()
    {
        fader.FadeTo("MainMenu");                                       //fades back to main menu
    }
}
