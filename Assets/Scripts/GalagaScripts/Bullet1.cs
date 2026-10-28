using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    //Extra code is for bullet rotation (unfortunatle I couldn't figure out how to rotate the sprite for each gun with needing to change everything)
    public Vector2 moveDirection = new Vector2(0, 1);
    public float bulletSpeed = 5;
    public Vector2 velocity;
    private Rigidbody2D rb => GetComponent<Rigidbody2D>();
    void Update()
    {
        velocity = moveDirection * bulletSpeed;
        transform.right = rb.linearVelocity;
        transform.Translate(moveDirection * bulletSpeed * Time.deltaTime);
        if (transform.position.y > 6)
        {
            Destroy(gameObject);

        }
    }
}
