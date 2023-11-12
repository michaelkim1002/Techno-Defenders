using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;          //checks if game is over
    public GameObject gameOverUI;           

    public GameObject completeLevelUI;
    public CompleteLevel completeLevel;     //gets component of complete level
    void Start()
    {
        gameIsOver = false;                 //game is not over
    }
    void Update()
    {
        if(gameIsOver)                      //if game is over, its stops updating
        {
            return;
        }
        if(PlayerStats.lives<=0)            //if lives is less than or equal to 0, then game ends
        {
            EndGame();
        }
    }
    void EndGame()
    {
        gameIsOver = true;                  //game is over
        gameOverUI.SetActive(true);         //game over UI is popped up
    }
    public void WinLevel()
    {
        
        gameIsOver = true;                  //game is over
        completeLevel.Unlock();             //unlocks next level
        completeLevelUI.SetActive(true);    //complete level UI is popped up
    }
}
