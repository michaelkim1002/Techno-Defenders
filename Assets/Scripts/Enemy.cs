using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;                                                                          //movement speed of enemy
    [HideInInspector]
    public float speed;                                                                                     //movement start speed of enemy

    public float startHealth = 100;                                                                         //start health of enemy
    private float health;                                                                                   //health of enemy

    public int worth = 50;                                                                                  //amount of money received for killing enemy
    public int giantDamage = 10;                                                                            //lives lost when giant enemy reaches end

    public GameObject deathEffect;                                                                          //particle effect when enemy dies

    [Header("Unity Stuff")]

    public Image healthBar;                                                                                 //health bar UI for enemy

    private bool isDead = false;                                                                            //checks if enemy is dead
    public bool isGiant;                                                                                    //checks if enemy is giant
    void Start()                                                                                            //sets enemy health when spawned
    {
        speed = startSpeed;
        health = startHealth;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;                                                                                   //enemy loses health by amount
        healthBar.fillAmount = health / startHealth;                                                        //health bar length decreases when enemy takes damage
        if (health <= 0 && !isDead)                                                                         //checks if enemy health is 0 and is not dead
        {
            Die();                                                                                          //enemy dies
        }
    }
    public void Slow(float amount)
    {
        speed = startSpeed * (1f - amount);                                                                 //if hit by laser, enemy moves slower
    }
    void Die()
    {
        isDead = true;                                                                                      //enemy is dead
        PlayerStats.money += worth;                                                                         //money is received
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);  //death effect is played
        Destroy(effect, 5f);                                                                                //effect disappears
        WaveSpawner.enemiesAlive--;                                                                         //enemies that are alive decreases
        Destroy(gameObject);                                                                                //gameObject disappears
    }
}
