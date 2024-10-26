using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour{
    const int NUM_BALLOONS = 10;
    [SerializeField] GameObject BallonObject;
    private int currentBalloons = 0;

    // Start is called before the first frame update
    void Start(){
        Spawn();
    }

    // Update is called once per frame
    void Update(){
        if (currentBalloons < NUM_BALLOONS)
        {
            Spawn();
        }
    }

    void Spawn(){
        if (currentBalloons >= NUM_BALLOONS)
        {
            return; // Don't spawn more than the limit
        }

        int xMin = -10 ;
        int xMax = 16;
        int yMin = -2;
        int yMax = 2;

        while(currentBalloons < NUM_BALLOONS){
            Vector2 position = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            Instantiate(BallonObject, position, Quaternion.identity);
            currentBalloons++;
        }
    }
}
