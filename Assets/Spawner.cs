using System.Collections;
using UnityEngine;

public class Spawner1 : MonoBehaviour
{
    [SerializeField] GameObject BalloonObject; // Prefab of the balloon
    private int currentBalloons = 0; // Tracks currently spawned balloons
    private int balloonsToSpawn; // Total balloons needed for the level
    private Scorekeeper scorekeeper;

    // Start is called before the first frame update
    void Start()
    {
        scorekeeper = FindObjectOfType<Scorekeeper>();

        // Get the number of balloons needed for the current level
        balloonsToSpawn = scorekeeper.GetRemainingBalloons();

        // Debug log for clarity
        Debug.Log($"Balloons to spawn: {balloonsToSpawn}");

        // Spawn the initial set of balloons
        SpawnInitialBalloons();
    }

    void SpawnInitialBalloons()
    {
        // Spawn balloons up to the required number
        for (int i = 0; i < balloonsToSpawn; i++)
        {
            SpawnSingleBalloon();
        }
    }

    void SpawnSingleBalloon()
    {
        // Safeguard: Don't spawn more balloons than required
        if (currentBalloons >= balloonsToSpawn)
        {
            Debug.Log("Max balloon count reached. No more balloons will be spawned.");
            return;
        }

        // Generate a random position
        int xMin = -10;
        int xMax = 10;
        int yMin = 0;
        int yMax = 10;

        Vector2 position = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));

        // Instantiate the balloon and increment the counter
        Instantiate(BalloonObject, position, Quaternion.identity);
        currentBalloons++;
        Debug.Log($"Spawned a balloon. Current Balloons: {currentBalloons}/{balloonsToSpawn}");
    }

    public void BalloonPopped()
    {
        // Decrement the balloon count when one is popped
        currentBalloons--;

        // Debug log for clarity
        Debug.Log($"Balloon popped. Current Balloons: {currentBalloons}/{balloonsToSpawn}");
    }
}
