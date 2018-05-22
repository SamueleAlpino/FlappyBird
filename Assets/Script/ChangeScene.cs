using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void SelectScene(string SelectedScene)
    {
        SceneManager.LoadScene(SelectedScene);
    }

    public void SelectScene(int SelectedScene)
    {
        SceneManager.LoadScene(SelectedScene);
    }
}
