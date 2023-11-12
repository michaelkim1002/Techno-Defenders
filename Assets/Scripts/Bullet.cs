using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;                                                                                   //target that is being shot
    public float speed = 70f;                                                                                   //speed projectile travels
    public float explosionRadius = 8f;                                                                          //area damage for missile
    public int damage = 50;                                                                                     //damage projectile deals
    public GameObject impactEffect;                                                                             //particle effect for impact
    public void Seek(Transform _target)
    {
        target = _target;                                                                                       //seeks target being shot
    }
    void Update()
    {
        if(target == null)                                                                                      //projectile disappears if there is no target
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;                                                     //travels to direction of target
        float distanceThisFrame = speed * Time.deltaTime;                                                       //moves at instantiated speed

        if(dir.magnitude<=distanceThisFrame)                                                                    //checks if projectile reaches target
        {
            HitTarget();                                                                                        //calls HitTarget
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);                                   //looks at target being shot
        transform.LookAt(target);
    }
    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);   //instantiates impact effect
        Destroy(effectIns, 5f);                                                                                 //gameObject disappears after 5 seconds

        if(explosionRadius>0f)                                                                                  //if radius is greater than 0, then missile 'explodes'
        {
            Explode();
        }
        else
        {
            Damage(target);                                                                                     //deals damage
        }
        
        Destroy(gameObject);                                                                                    //gameObject disappears
    }
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);                      //collider for explosion radius
        foreach(Collider collider in colliders)
        {
            if(collider.tag == "Enemy")                                                                         //deals damage if enemy is in explosion radius
            {
                Damage(collider.transform);
            }
        }
    }
    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();                                                                  //gets enemy component for damage
        if(e!=null)
        {
            e.TakeDamage(damage);                                                                               //if it's an enemy, enemy takes damage
        }
    }
    void OnDrawGizmosSelected()                                                                                 //visibly shows radius of explosion
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
