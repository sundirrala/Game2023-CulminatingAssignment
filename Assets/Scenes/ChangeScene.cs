using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void LoadOverworld()
    {
        SceneManager.LoadScene("Overworld");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit.");
    }
}
