using System.Collections;
using UnityEngine;

public class TriplerPickup : MonoBehaviour
{
    //The Tripler power up code
    public float speed = 3f;
    public float powerupDuration = 4f;
    public float pickupSpeed = 4f;
    [SerializeField] private AudioClip collectSoundClip;
    
    void Update()
    {
        transform.Translate(-transform.up * pickupSpeed * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GalagaPlayer"))
        {
            StartCoroutine(Pickup(collision));
        }
    }
    //So, the StartCoroutine above^^ is so that the powerup can have a countdown when it's activated
    //The IEnumerator allows for the countdown, the stats variable refers to the Pickup parameter,
    //The "isTripled" boolean is from GalagaMovement, and it determines whether the ship is firing three bullets or not
    //The GetCompenents before the WaitForSeconds make sure that the sprite and collider leave the screen so that it doesn't linger while the powerup is active
    IEnumerator Pickup(Collider2D player)
    {
        GalagaMovement stats = player.GetComponent<GalagaMovement>();

        stats.isTripled = true;
        AudioSource.PlayClipAtPoint(collectSoundClip, transform.position, 1f);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitForSeconds(powerupDuration);

        stats.isTripled = false;

        Destroy(gameObject);

    }
}
