using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRotation : MonoBehaviour
{
    private Transform toControl;
    private Vector3   originalRot = new Vector3(0, 0, 180);

    void Start()
    {
        toControl = this.gameObject.GetComponent<Transform>();
    }
    void Update ()
    {
        if (Input.GetKey(KeyCode.S))
        {
            // The right angles
            Debug.Log(toControl.eulerAngles.z);
            // Wrong angles
            Debug.Log(toControl.rotation.z);
            Debug.Log(toControl.localRotation.z);
        }

        if (toControl.eulerAngles.z < 170 || toControl.eulerAngles.z > 190)
        {
            toControl.eulerAngles = Vector3.Lerp(toControl.eulerAngles, originalRot, 4f);
        }
    }
}
