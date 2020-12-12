using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionManager : MonoBehaviour
{
    [SerializeField]
    Animator screenEffects;

    // Start is called before the first frame update
    void Start()
    {
        var encounterMgr = SpawnPoint.player.GetComponent<EncounterManager>();
        encounterMgr.onEnterEncounter.AddListener(OnEnterEncounterHandler);
        encounterMgr.onExitEncounter.AddListener(OnExitEncounterHandler);
    }

    void OnEnterEncounterHandler()
    {
        screenEffects.Play("FadeToBlackState");
        //screenEffects.Play("FadeFromBlackState");
    }

    void OnExitEncounterHandler()
    {
        screenEffects.Play("FadeToBlackState");
    }
}
