using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive = 0;         //how many enemies are alive

    public Wave[] waves;                        //array of waves spawned
   
    public Transform spawnPoint;                //where the enemies are spawned

    public float timeBetweenWaves = 5f;         //time until next wave is spawned
    private float countdown = 5f;               //countdown until wave is spawned

    public Text waveCountdownText;              //shows coundown number
    private int waveIndex = 0;                  //index number of wave
    public GameManager gameManager;             //gets game manager component
    void Start()
    {
        countdown = timeBetweenWaves;           //starts at coundown time
        enemiesAlive = 0;                       //starts at 0 enemies alive
        waveIndex = 0;                          //starts at wave index 0
    }
    void Update()
    {
        if(enemiesAlive>0)                                                          //does nothing when there are enemies
        {
            return;
        }
        if (waveIndex == waves.Length && enemiesAlive == 0)                         //if last wave is beaten and there are no enemies alive
        {
            gameManager.WinLevel();                                                 //level is complete
            this.enabled = false;
        }
        if (countdown<=0f)                                                          //if countodwn is 0
        {
            StartCoroutine(SpawnWave());                                            //spawns wave
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;                                                 //timer counts down
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);                      
        waveCountdownText.text = "Next Wave: " + string.Format("{0:00}", countdown); //shows countdown timer
    }
    IEnumerator SpawnWave()
    {
       
        PlayerStats.rounds++;                                           //number of round survived increases
        Wave wave = waves[waveIndex];                                   //gets wave of waveIndex
        enemiesAlive = wave.count;                                      //number of enemies currently alive
        for(int x = 0; x<wave.count; x++)
        {
            SpawnEnemy(wave.enemy[Random.Range(0,wave.enemy.Length)]);  //spawns random type of enemy
            yield return new WaitForSeconds(1f / wave.rate);            //spawn rate until enemy is spawned again
        }
         waveIndex++;                                                   //waveIndex increases and moves on to next wave
        
    }
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);   //instantiates enemy
    }
}
