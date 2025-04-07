using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    private Animator _doorAnimator;

    public GameObject InvisibleDoor;
    public GameObject GreenLightSwitch;
    public GameObject RedLightSwitch;

    public AudioSource doorOpening;
    public AudioSource doorClosing;   

    void Start()
    {
        _doorAnimator = GetComponent<Animator>();
    }

    //Open Door
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            InvisibleDoor.SetActive(false);
            GreenLightSwitch.SetActive(true);
            RedLightSwitch.SetActive(false);

            //_doorAnimator.SetTrigger("Open");
            _doorAnimator.SetBool("Open", true);
            _doorAnimator.SetBool("Close", false);
   
            doorOpening.Play();
        }
    }

    //Close Door
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            InvisibleDoor.SetActive(true);
            GreenLightSwitch.SetActive(false);
            RedLightSwitch.SetActive(true);

            _doorAnimator.SetBool("Open", false);
            _doorAnimator.SetBool("Close", true);

            doorClosing.Play();
        }
    }


}
