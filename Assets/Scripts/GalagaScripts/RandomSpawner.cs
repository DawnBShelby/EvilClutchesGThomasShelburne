using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    // This is code from my first project I copied over to have the pickups spwan randomly.
    //This code spawns projectiles in random intervals in random places
    [SerializeField] private BoxCollider2D spawner;
    [SerializeField] private GameObject[] spawnableObjects;
    [SerializeField] private float itemWait = 1;
    [SerializeField] private float itemTimer = 0;


    void Update()
    {
        //spawning
        itemTimer += Time.deltaTime;


        if (itemTimer > itemWait)
        {
            //The first three lines are the random area spawns, and the last two randomize the time between spawns
            GameObject item = Instantiate(spawnableObjects[Random.Range(0, spawnableObjects.Length)], transform.position, Quaternion.identity);

            float randomX = Random.Range(spawner.bounds.min.x, spawner.bounds.max.x);
            float randomY = Random.Range(spawner.bounds.min.y, spawner.bounds.max.y);

            item.transform.position = new Vector2(randomX, randomY);

            itemTimer = 0;
            itemWait = Random.Range(1f, 2f);

        }
    }
}
