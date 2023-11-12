using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;                                                                   //waypoint that is being moved to
    private int wavepointindex = 0;                                                             //wavepoint number
    public bool boss;                                                                           //check if enemy is a boss
    private Enemy enemy;                                                                        //enemy that is moving

    void Start()
    {
        enemy = GetComponent<Enemy>();                                                          //gets enemy component
        target = WayPoints.points[0];                                                           //starts at waypoint 0
    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;                                     //direction of movement
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);        //travels at instantiated speed

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)                      //if enemy reaches waypoint, moves to next waypoint
        {
            GetNextWaypoint();
        }
        enemy.speed = enemy.startSpeed;                                                         //speed of enemy is set
    }
    void GetNextWaypoint()
    {
        if (wavepointindex >= WayPoints.points.Length - 1)                                      //if enemy reaches last waypoint, then it ends travel
        {
            EndPath();
            return;
        }
        wavepointindex++;                                                                       //waypoint index increases
        target = WayPoints.points[wavepointindex];                                              //sets next waypoint
    }
    void EndPath()
    {
        if(boss)                                                                                //if enemy is boss, then player loses remaining lives, making the game over
        {
            PlayerStats.lives-= PlayerStats.lives;
        }
        else if(enemy.isGiant)                                                                  //if enemy is giant, then player loses certain lives
        {
            PlayerStats.lives-= enemy.giantDamage;
        }
        else                                                                                    //player loses a life if enemy reaches end
        {
            PlayerStats.lives--;
        }
        WaveSpawner.enemiesAlive--;                                                             //decreses number of enemies alive
        Destroy(gameObject);                                                                    //gameobject disappears
    }
}
