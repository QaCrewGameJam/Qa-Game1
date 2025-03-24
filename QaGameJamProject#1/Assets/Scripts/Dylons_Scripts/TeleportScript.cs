using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public GameObject Player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player.transform.position = new Vector3(5.5f, 1.6f, -4.5f);

        }
    }
}
