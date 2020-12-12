using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameSaver : MonoBehaviour
{
    public static UnityEvent OnSave = new UnityEvent();
    public static UnityEvent OnLoad = new UnityEvent();

    void Save()
    {
        OnSave.Invoke();

        PlayerPrefs.SetFloat("xLoc", SpawnPoint.player.transform.position.x);
        PlayerPrefs.SetFloat("yLoc", SpawnPoint.player.transform.position.y);

        PlayerPrefs.Save();

        Debug.Log("Saved! " + SpawnPoint.player.transform.position.x);
    }
    void Load()
    {
        OnLoad.Invoke();

        SpawnPoint.player.transform.position = new Vector3(PlayerPrefs.GetFloat("xLoc"), PlayerPrefs.GetFloat("yLoc"), SpawnPoint.player.transform.position.z);

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
