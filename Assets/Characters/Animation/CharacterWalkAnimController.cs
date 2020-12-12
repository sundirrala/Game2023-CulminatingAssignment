using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;
using UnityEngine.SceneManagement;

public enum CardinalDirection
{
    NORTH   = 0,
    EAST    = 1,
    SOUTH   = 2,
    WEST    = 3
}


public class CharacterWalkAnimController : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    CardinalDirection walkDirection = CardinalDirection.SOUTH;

    public static bool canMove = true;

     Vector2 vel;

    // Update is called once per frame
    void Update()
    {
       //Vector2 vel = rb.velocity;
       if (canMove)
       {
           vel = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // if we are moving at all
        bool isWalking = vel.magnitude > float.Epsilon;

       if (isWalking)
       {
        float encounter = Random.Range(-2000, 10);

           if (encounter == 0)
           {
               SpawnPoint.player.GetComponent<EncounterManager>().EnterEncounter();
               //SceneManager.LoadScene("BattleScene", LoadSceneMode.Single);
           }

            bool isMovingHorizontally = Mathf.Abs(vel.x) > Mathf.Abs(vel.y);
            
           if (isMovingHorizontally) //moving left/right more than up/down
           {
               if (vel.x < 0) //moving left/WEST
               {
                   walkDirection = CardinalDirection.WEST;
               }
               else //moving right/EAST
               {
                   walkDirection = CardinalDirection.EAST;
               }
           }
           else // moving more vertically
           {
               if (vel.y < 0) //moving down/SOUTH
               {
                   walkDirection = CardinalDirection.SOUTH;
               }
               else //moving up/NORTH
               {
                   walkDirection = CardinalDirection.NORTH;
               }
           }
       } // if is walking

       animator.SetBool("IsWalking", isWalking);
       animator.SetInteger("WalkDirection", (int)walkDirection);
       }
    }
}
