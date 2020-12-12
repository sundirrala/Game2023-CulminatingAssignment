using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameSaver : MonoBehaviour
{
    public static UnityEvent OnSave = new UnityEvent();
    public static UnityEvent OnLoad = new UnityEvent();

    public void Save()
    {
        OnSave.Invoke();

        PlayerPrefs.SetFloat("xLoc", SpawnPoint.player.transform.position.x);
        PlayerPrefs.SetFloat("yLoc", SpawnPoint.player.transform.position.y);
        PlayerPrefs.SetString("CurrentScene", SceneManager.GetActiveScene().name);

        PlayerPrefs.Save();

        Debug.Log("Saved! " + SpawnPoint.player.transform.position.x);
    }
    public void Load()
    {
        OnLoad.Invoke();

        SpawnPoint.player.transform.position = new Vector3(PlayerPrefs.GetFloat("xLoc"), PlayerPrefs.GetFloat("yLoc"), SpawnPoint.player.transform.position.z);
        SceneManager.LoadScene(PlayerPrefs.GetString("CurrentScene"));

        Debug.Log("Loaded!");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }
}
