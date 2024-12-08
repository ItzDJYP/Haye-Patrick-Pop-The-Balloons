using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour{
    //const int NUM_BALLOONS = 10;
    [SerializeField] GameObject BallonObject;
    private int currentBalloons = 0;
    private int balloonsToSpawn;
    private Scorekeeper scorekeeper;

    // Start is called before the first frame update
    void Start(){
        scorekeeper = FindObjectOfType<Scorekeeper>();
        balloonsToSpawn = scorekeeper.GetRemainingBalloons();
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        //if (currentBalloons < NUM_BALLOONS)
        if (currentBalloons < balloonsToSpawn)
        {
            {
                Spawn();
            }
        }
    }
        void Spawn()
        {
            /*if (currentBalloons >= NUM_BALLOONS)
            {
                return; // Don't spawn more than the limit
            }*/

            int xMin = 0;
            int xMax = 10;
            int yMin = 0;
            int yMax = 10;

            //while(currentBalloons < NUM_BALLOONS){
            while(currentBalloons < balloonsToSpawn)
            {
                Vector2 position = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
                Instantiate(BallonObject, position, Quaternion.identity);
                currentBalloons++;
            }
        }
    public void BalloonPopped()
    {
        currentBalloons--;
    }
}