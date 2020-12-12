using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFootstepAudio : MonoBehaviour
{
    [SerializeField]
    AudioClip[] footstepSounds;

    [SerializeField]
    AudioSource footstepSource;

    public void PlayFootstep()
    {
        footstepSource.clip = footstepSounds[0];
        footstepSource.Play();
    }
}
