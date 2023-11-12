using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;                       //target being shot at
    private Enemy targetEnemy;                      //enemy target

    [Header("Attributes")]

    public float range = 15f;                       //shooting range of turret

    [Header("Use Bullets (default)")]
    public GameObject bulletPrefab;                 //projectile that is shot
    public float fireRate = 1f;                     //speed of shooting
    private float fireCountdown = 0f;               //countdown until turret can shoot again

    [Header("Use Laser")]

    public bool useLaser = false;                   //if turret is a laser
    public LineRenderer lineRenderer;               //laser line

    public ParticleSystem impactEffect;             //particle effect for impact
    public Light impactLight;                       //laser glows

    public int damageOverTime =30;                  //damage laser deals over time
    public float slowPct = 0.5f;                    //how much speed is cutoff when enemy is slowed

    [Header("Use Money Generator")]

    public bool gen = false;                        //checks if turret is generator
    public GameObject moneyEffect;                  //particle effect for money
    public int worth = 20;                          //how much money is received
    private float moneyCountdown = 2f;              //countdown until money is generated

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";               //enemy has enemy tag
    public Transform partToRotate;                  //turret head that is rotated
    public float turnSpeed = 10f;                   //how fast the head turns

   
    public Transform firePoint;                     //point where projectile is shot from
   
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);                                                      //updates target being hot at
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);                             //finds objects with enemy tag
        float shortestDistance = Mathf.Infinity;                                                        //finds nearest enemy
        GameObject nearestEnemy = null;                                                                 //nearestEnemy had not been found yet
        foreach (GameObject enemy in enemies)                                                           //pack of enemies
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);     //distance from turret to enemy
            if (distanceToEnemy < shortestDistance)                                                     //updates nearestEnemy and distance
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)                                          //target is current nearest enemy                                     
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;                                                                              //there is no nearest enemy
        }

    }
    void Update()
    {
        if(!gen)                                            //checks if turret is not money generator
        {
            if (target == null)                             //checks if ther is no turret
            {
                if(useLaser)                                //checks if turret is laser
                {
                    if(lineRenderer.enabled)                //checks if laser line is enabled
                    {
                        lineRenderer.enabled = false;       //laser line disappears
                        impactEffect.Stop();
                        impactLight.enabled = false;
                    }
                }
                return;
            }
            LockOnTarget();                                 //looks at enemy being shot at
            if(useLaser)                                    
            {
                Laser();                                    //shoots laser
            }
            else
            {
                if (fireCountdown <= 0f)                    //countdown until turret can shoot
                {
                    Shoot();                                //shoots projectile
                    fireCountdown = 1f / fireRate;          //controls shooting speed
                }
                fireCountdown -= Time.deltaTime;            //counts down
            }   
        }
        else
        {
            if (moneyCountdown <= 0f)                       //counts down to generate money
            {
                GenerateMoney();
                moneyCountdown = 1f / fireRate;
            }
            moneyCountdown -= Time.deltaTime;
        }

    }
    void LockOnTarget()                                                                                                     
    {
        Vector3 dir = target.position - transform.position;                                                                 //direction of view to enemy                               
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);                                                       //turret head rotates to direction
    }
    void Laser()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);                                                            //enemy takes damage
        targetEnemy.Slow(slowPct);                                                                                          //enemy slows dwon

        if (!lineRenderer.enabled)                                                                                          //checks if ther is no laser line
        {
            lineRenderer.enabled = true;                                                                                    //laser line is instantiated
            impactEffect.Play();
            impactLight.enabled = true;
        }
        
        lineRenderer.SetPosition(0,firePoint.position);                                                                     //fire point
        lineRenderer.SetPosition(1, target.position);                                                                       //point of impact
        
        

        Vector3 dir = firePoint.position - target.position;                                                                 //direction of line to enemy
        impactEffect.transform.position = target.position + dir.normalized;                                                 //impact effect is played
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);                                                     //impact effect is played in direction
        
    }
    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);                //projectile is instantiated
        Bullet bullet = bulletGO.GetComponent<Bullet>();                                                                    //projectile is bullet

        if(bullet !=null)
        {
            bullet.Seek(target);                                                                                            //bullet travels to target
        }
    }
    void GenerateMoney()
    {
        PlayerStats.money += worth;                                                                                         //adds money
        GameObject effect = (GameObject)Instantiate(moneyEffect, transform.position, Quaternion.identity);                  //money effect is played
        Destroy(effect, 5f);                                                                                                //effect gameObject disappears
    }
    void OnDrawGizmosSelected()                                                                                             //shows radius of shooting range
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
