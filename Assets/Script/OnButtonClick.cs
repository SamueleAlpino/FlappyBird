using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SphereCollider))]
public class OnButtonClick : MonoBehaviour
{
    public string NextScene;

    private bool isBig;
    private SphereCollider sphere;
    
    void Start()
    {
        sphere = GetComponent<SphereCollider>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.rigidbody != null)
                    SceneManager.LoadScene(NextScene);

            }
        }

        //Use the mouse position and a target
        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // RaycastHit hit;
        //
        // if (Physics.Raycast(ray, out hit))
        // {
        //     if (hit.rigidbody != null)
        //     {
        //         if (!isBig)
        //         {
        //             hit.transform.localScale *= 1.5f;
        //             isBig = !isBig;
        //         }
        //
        //         if (Input.GetMouseButton(0))
        //             SceneManager.LoadScene(NextScene);
        //     }
        // }
        isBig = false;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePos.x < gameObject.transform.position.x + sphere.radius &&
            mousePos.x > gameObject.transform.position.x - sphere.radius &&
            mousePos.y < gameObject.transform.position.y + sphere.radius &&
            mousePos.y > gameObject.transform.position.y - sphere.radius && !isBig)
        {
            gameObject.transform.localScale = new Vector3(0.7f,0.7f,1f);
            sphere.radius = 1.7f;
            isBig = true;

        }
        if (!isBig)
        {
            gameObject.transform.localScale = new Vector3(0.5f,0.5f,1f);
            sphere.radius = 1.3f;
        }
        
    }
}
