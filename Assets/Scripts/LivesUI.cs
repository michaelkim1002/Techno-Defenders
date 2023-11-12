using UnityEngine;
using UnityEngine.UI;
public class LivesUI : MonoBehaviour
{
    public Text livesText;                                              //lives text UI
   
    void Update()
    {
        livesText.text = "Lives: " + PlayerStats.lives.ToString();      //shows number of lives
    }
}
