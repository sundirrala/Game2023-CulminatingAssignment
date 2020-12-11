using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    GameObject playerPrefab;

    public static PlayerCharacterController player = null;

    // Start is called before the first frame update
    void Awake()
    {
        if(player == null)
        {
            player = FindObjectOfType<PlayerCharacterController>();
            if (player == null)
            {
                player = Instantiate(playerPrefab, transform.position, transform.rotation).GetComponentInChildren<PlayerCharacterController>();
            }
        }
    }
}
