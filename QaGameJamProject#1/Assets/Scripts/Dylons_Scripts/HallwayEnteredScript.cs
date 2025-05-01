using UnityEngine;

public class HallwayEnteredScript : MonoBehaviour
{
    [SerializeField] GameObject forwardCheckTrigger;
    [SerializeField] GameObject backwardCheckTrigger;

    [SerializeField] GameObject backDoor;
    [SerializeField] GameObject backAirLock;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            forwardCheckTrigger.SetActive(true);
            backwardCheckTrigger.SetActive(true);
            backDoor.SetActive(false);
            backAirLock.SetActive(true);

            this.gameObject.SetActive(false);
        }
    }

}
