using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    [SerializeField] private AudioClip collectSoundClip;
    public float speed = 6;
    public int points = 100;

    private void OnTriggerEnter2D(Collider2D collision) // This plays a sound clip when a Projectile collides with the Player
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(collectSoundClip, transform.position, 1f);
        }
    }

    void Update()
    {
        transform.Translate(-transform.right * speed * Time.deltaTime);
        if (transform.position.x < -10)
        {
            Destroy(gameObject);

        }
    }

}
