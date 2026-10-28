using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GalagaMovement : MonoBehaviour
{

    public Gun[] guns;
    public float speed = 5;
    public GameObject bullet;
    public bool isTripled;

    // Added some additional fields to enable refilling health
    public int maxLives = 3;
    public int lifeCount = 3;
    public Image[] lives;
    public Sprite emptyHeart;
    public Sprite fullHeart;

    // This is to allow for the triple guns to work
    void Start()
    {
        guns = transform.GetComponentsInChildren<Gun>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(transform.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-transform.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }

        // Changed up the code so now if you have the Tripler power up if has each gun fire, and if not then just the one fires.
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (isTripled == true)
            {
                foreach (Gun gun in guns)
                {
                    gun.Shoot();
                }
            }
            else
            {
                Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
            }
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8, 8), Mathf.Clamp(transform.position.y, -4, 4), 0);

        // Now instead of the health icons being exlusively tied to player collision, the health bar can change with any instance of damage or healing
        for (int i = 0; i < lives.Length; i++)
        {
            if (i < lifeCount)
                lives[i].sprite = fullHeart;

            else
                lives[i].sprite = emptyHeart;

            if (i < maxLives)
                lives[i].enabled = true;

            else
                lives[i].enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            lifeCount -= 1;
            if (lifeCount <= 0)
            {
                lifeCount = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

        }

        //Heals the player if they collect a health pickup
        if (collision.gameObject.CompareTag("HealthPickup"))
        {
            lifeCount += 1;
            if (lifeCount >= 3)
            {
                lifeCount = 3;
            }
        }
    }
}
