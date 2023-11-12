using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class RoundsSurvived : MonoBehaviour
{
    public Text roundsText;                             //text for rounds processed
    void OnEnable()
    {
        StartCoroutine(AnimateText());                  //animated text for number of rounds survived
    }
    IEnumerator AnimateText()
    {
        roundsText.text = "0";
        int round = 0;
        yield return new WaitForSeconds(0.7f);          //changes every 0.7 seconds
        while (round<PlayerStats.rounds)                //changes while number of rounds is less than rounds processed
        {
            round++;                                    //increases
            roundsText.text = round.ToString();         //sets text
            yield return new WaitForSeconds(0.05f);     //changes every 0.05 seconds
        }
    }
}
