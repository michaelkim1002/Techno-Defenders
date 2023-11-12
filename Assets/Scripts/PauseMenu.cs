using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject ui;                                                   //UI of Pause menu
    public string mainMenuName = "MainMenu";                                //string name of main menu
    public SceneFader sceneFader;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))                                //If escape is pressed, then Toggle is called
        {
            Toggle();
        }
    }
    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);                                       //UI popps up

        if(ui.activeSelf)                                                   //if UI is shown, time scale is 0
        {
            Time.timeScale = 0f;
          
        }
        else 
        {
            Time.timeScale = 1f;                                            //otherwise, time scale is 1
        }
    }
    public void Retry()                                                     //retries same level
    {
        Toggle();                                                           //Toggle() is called
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);              //fades to same level
    }
    public void Menu()                                                      //goes to main menu
    {
        Toggle();                                                           //Toggle() is called
        sceneFader.FadeTo(mainMenuName);                                    //fades to main menu
    }
}
