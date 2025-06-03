using UnityEngine;

public class RandomHallway : MonoBehaviour
{
    [SerializeField] private GameObject[] randomHallway;
    [SerializeField] private GameObject chosenHallway;
    private bool checkIfHallwaySpawned;

    //Create Object to be where hallway spawns inbetween airlocks.
    [SerializeField] Vector3 hallwaySpawnPosition;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Picks a hallway gameobject randomly from array of set pieces
        chosenHallway = randomHallway[Random.Range(0, randomHallway.Length)];

        //Instantiate the hallway that was chosen.
        Instantiate(chosenHallway, hallwaySpawnPosition, transform.rotation = Quaternion.Euler(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
