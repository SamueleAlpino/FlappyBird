using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public AudioSource Open;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Door>() != null)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                other.gameObject.GetComponent<Door>().Activate = !other.gameObject.GetComponent<Door>().Activate;
                Open.Play();
            }
        }
    }


}
