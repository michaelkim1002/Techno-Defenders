using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public SceneFader sceneFader;                               //variable for fading to next scene
    public string nextLevel = "Level02";                        //gets string name of next level
    public int nextLevelIndex;                                  //gets index of next level
    public string mainMenu = "MainMenu";                        //string for main menu scene
    public void Menu()                                          //fades to main menu scene
    {
        sceneFader.FadeTo(mainMenu);
    }
    public void Unlock()                                        //when level is complete, it unlocks next level by gettign next index
    {
        PlayerPrefs.SetInt("levelReached", nextLevelIndex);
    }
    public void Continue()                                      //fades to next level
    {
        sceneFader.FadeTo(nextLevel);
    }
}
