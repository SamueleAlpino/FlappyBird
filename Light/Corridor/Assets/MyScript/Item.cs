using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject Torch;
    public AudioSource Click;

    private bool change;

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            change = !change;
            Click.Play();
            Torch.SetActive(change);
        }

	}
}
