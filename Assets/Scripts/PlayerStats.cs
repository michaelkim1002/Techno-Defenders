using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;            //current money
    public int startMoney = 400;        //start money

    public static int lives;            //current lives
    public int startLives = 20;         //start lives

    public static int rounds;           //rounds processes
    void Start()                        //sets starting stats
    {
        money = startMoney;
        lives = startLives;

        rounds = 0;
    }
}
