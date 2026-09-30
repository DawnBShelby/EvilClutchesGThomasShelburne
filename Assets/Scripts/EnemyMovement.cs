using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5;
    public bool goingUp = true;

    // fireball timers. The other projectile is now in TargetSpawner, which I changed from a rat to a coin
    private float fireballWait = 2;
    private float fireballTimer = 0;

    public GameObject fireball;

    void Update()
    {
        //spawning

        fireballTimer += Time.deltaTime;

        if (fireballTimer > fireballWait)
        {
            Instantiate(fireball, transform.position, Quaternion.identity);
            fireballTimer = 0;
            fireballWait = Random.Range(2f, 3f);
        }

        transform.Translate(transform.up * speed * Time.deltaTime);

        if (transform.position.y > 4 && goingUp == true)
        {
            goingUp = false;
            speed *= -1;
        }

        if (transform.position.y < -4 && goingUp == false)
        {
            goingUp = true;
            speed *= -1;
        }
    }
}
