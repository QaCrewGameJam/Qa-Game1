using UnityEngine;
using UnityEditor;

public class ResetPrefab : MonoBehaviour
{
    [SerializeField] GameObject hallwayCheckTrigger;
    [SerializeField] GameObject backDoor;
    [SerializeField] GameObject backAirLock;
    [SerializeField] GameObject forwardCheckTrigger;
    [SerializeField] GameObject backwardCheckTrigger;



    private void OnTriggerEnter(Collider other)
    {
        hallwayCheckTrigger.SetActive(true);
        backDoor.SetActive(true);
        backAirLock.SetActive(false);
        forwardCheckTrigger.SetActive(false);
        backwardCheckTrigger.SetActive(false);
    }


}
