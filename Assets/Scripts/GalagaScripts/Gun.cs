using UnityEngine;
using UnityEngine.UIElements;

public class Gun : MonoBehaviour
{
    //Having multiple guns allows the player to shoot iun multiple directions at once by just adding more guns to the ship to activate on power up
    public Bullet1 bullet;
    private Vector2 direction;
    [SerializeField] Transform gun;
    void Start()
    {
        direction = (transform.localRotation * Vector2.right).normalized;
    }
    //This code instantiates the bullet and makes sure it goes in the right direction
    public void Shoot()
    {
        GameObject go = Instantiate(bullet.gameObject, gun.position, Quaternion.identity);
        Bullet1 goBullet = go.GetComponent<Bullet1>();
        goBullet.moveDirection = direction;
    }
}
