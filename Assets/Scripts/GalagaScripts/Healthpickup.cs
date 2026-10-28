using UnityEngine;

public class Healthpickup : MonoBehaviour
{
    public float speed = 4f;
    [SerializeField] private AudioClip collectSoundClip;
    void Update()
    {
        transform.Translate(-transform.up * speed * Time.deltaTime);

    }
    //This code just plays a sound and Destroys the object upon collision with the player.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GalagaPlayer"))
        {
            ActivatePowerup();
        }
    }
    void ActivatePowerup()
    {

        AudioSource.PlayClipAtPoint(collectSoundClip, transform.position, 1f);
        Destroy(gameObject);
    }

}
