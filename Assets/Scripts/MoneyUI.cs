using UnityEngine;
using UnityEngine.UI;
public class MoneyUI : MonoBehaviour
{
    public Text moneyText;                                      //money UI

    void Update()
    {
        moneyText.text = "$" + PlayerStats.money.ToString();    //shows amount of money
    }
}
