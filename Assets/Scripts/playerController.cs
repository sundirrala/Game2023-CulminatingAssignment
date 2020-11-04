﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    // ------------- serializedfield makes private variable seen on the inspector ----------------- //
    [SerializeField]
    float playerSpeed = 5.0f;

    [SerializeField]
    Animator animator = null;

    // ------ the update function is called once every frame ----------- //
    void Update()
    {
        // ------------ teleporting the player, no animations yet. ------------- //
        Vector2 movementVec = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementVec *= Time.deltaTime * playerSpeed;
        transform.Translate(movementVec);
        // --------------- end of teleporting player code. ---------------- //

        // ---------- setting the animations ----------- //
        animator.SetFloat("Horizontal", movementVec.x);
        animator.SetFloat("Vertical", movementVec.y);
        animator.SetFloat("Speed", movementVec.magnitude); // magnitude returns the length.
    }
}
