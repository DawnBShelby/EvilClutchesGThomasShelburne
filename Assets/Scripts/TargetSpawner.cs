using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    // This code spawns projectiles in random intervals in random places
    [SerializeField] private BoxCollider2D cd;
    [SerializeField] private GameObject newCoin;
    [SerializeField] private float coinWait = 1;
    [SerializeField] private float coinTimer = 0;


    void Update()
    {
        //spawning
        coinTimer += Time.deltaTime;


        if (coinTimer > coinWait)
        {
            //The first three lines are the random area spawns, and the last two randomize the time between spawns
            GameObject coin = Instantiate(newCoin);

            float randomY = Random.Range(cd.bounds.min.y, cd.bounds.max.y);

            coin.transform.position = new Vector2(transform.position.x, randomY);

            coinTimer = 0;
            coinWait = Random.Range(1f, 2f);

        }
    }
}
