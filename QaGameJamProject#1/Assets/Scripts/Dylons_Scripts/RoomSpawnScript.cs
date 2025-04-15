using UnityEngine;

public class RoomSpawnScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject hallwayPrefab;
    [SerializeField] Vector3 hallwayPivotPos;

    private Vector3 hallwayTriggerPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hallwayTriggerPos = this.gameObject.transform.position;
        hallwayPivotPos = GameObject.FindGameObjectWithTag("HallwayPivot").transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "Player")
        {
            Debug.Log(hallwayTriggerPos);
            Instantiate(hallwayPrefab, hallwayPivotPos, transform.rotation = Quaternion.Euler(0, 0, 0));
            this.gameObject.SetActive(false);
        }
    }
}
