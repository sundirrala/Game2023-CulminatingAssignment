using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class EncounterManager : MonoBehaviour
{
    public UnityEvent onEnterEncounter;
    public UnityEvent onExitEncounter;

    [SerializeField]
    float battleEntryDelay = 3.0f;

    public void EnterEncounter()
    {
        CharacterWalkAnimController.canMove = false;
        Debug.Log(CharacterWalkAnimController.canMove);
        StartCoroutine(DelayBattle());
    }

    IEnumerator DelayBattle()
    {
        onEnterEncounter.Invoke();
        yield return new WaitForSeconds(battleEntryDelay);
        transform.root.gameObject.SetActive(false);
        SceneManager.LoadScene("BattleScene");
    }

    public void ExitEncounter()
    {
        onExitEncounter.Invoke();
        transform.root.gameObject.SetActive(true);
        // In a full game, your code should remember the player's last area and return there
        SceneManager.LoadScene("Overworld");
        
        CharacterWalkAnimController.canMove = true;
    }
}
