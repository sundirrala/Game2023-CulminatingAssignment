using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
enum BattlePhase
{
    Player = 0,
    Enemy,
    Count
}

public class BattleSystem : MonoBehaviour
{
    [SerializeField]
    BattlePhase phase;

    [SerializeField]
    ICharacter[] combatants;

    public UnityEvent<ICharacter> onCharacterTurnBegin;

    // Start is called before the first frame update
    void Start()
    {
        AdvanceTurns();
    }

    public void AdvanceTurns()
    {
        // say advancing turns???

        phase++;
        if(phase >= BattlePhase.Count)
        {
            phase = 0;
        }

        ICharacter whoseTurnItIs = combatants[(int)phase];
        //Debug.Log("It is " + whoseTurnItIs.name + "'s turn.");
        whoseTurnItIs.TakeTurn();
        onCharacterTurnBegin.Invoke(whoseTurnItIs);
    }

    public void EndBattle()
    {
        //FindObjectsOfType<EncounterManager>()[0].ExitEncounter();
        SpawnPoint.player.GetComponent<EncounterManager>().ExitEncounter();
    }
}
