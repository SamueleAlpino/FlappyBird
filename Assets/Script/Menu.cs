using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Transform Locator;
    public Vector2 Size;
    public GUIStyle Style;

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Locator.position, Size));
        //Buttons
        if (GUILayout.Button("PLAY", Style))
            SceneManager.LoadScene("MainScene");

        GUILayout.EndArea();
        

    }

}
