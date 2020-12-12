using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    private MusicManager() {}
    private static MusicManager instance;

    public static MusicManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MusicManager>();
            }

            return instance;
        }

        private set { }
    }
    
    [SerializeField]
    AudioSource musicSource;

    [SerializeField]
    AudioClip[] trackList;

    [SerializeField]
    AudioMixer musicMixer;

    [SerializeField]
    float volumeMin_dB = -80.0f;

    [SerializeField]
    float volumeMax_dB = 0.0f;

    public enum Track
    {
        Overworld,
        Battle
    }

    // Start is called before the first frame update
    void Start()
    {
        EncounterManager encounterManager = SpawnPoint.player.GetComponent<EncounterManager>();
        encounterManager.onEnterEncounter.AddListener(OnEncounterEnterHandler);
        encounterManager.onExitEncounter.AddListener(OnEncounterExitHandler);

        MusicManager[] musicManagers = FindObjectsOfType<MusicManager>();
        foreach(MusicManager mgr in musicManagers)
        {
            if (mgr != Instance)
            {
                Destroy(mgr.gameObject);
            }
        }

        DontDestroyOnLoad(transform.root);
    }

    public void OnEncounterEnterHandler()
    {
        PlayTrack(Track.Battle);
    }

    public void OnEncounterExitHandler()
    {
        FadeInTrackOverSeconds(Track.Overworld, 5.0f);
    }

    public void PlayTrack(MusicManager.Track trackID)
    {
        musicSource.clip = trackList[(int)trackID];
        musicSource.Play();
    }

    public void FadeInTrackOverSeconds(MusicManager.Track trackID, float duration)
    {
        PlayTrack(trackID);
        StartCoroutine(FadeInTrackOverSecondsCoroutine(duration));
    }

    IEnumerator FadeInTrackOverSecondsCoroutine(float duration)
    {
        musicSource.volume = 0.0f;
        float timer = 0.0f;

        while(timer < duration)
        {
            timer += Time.deltaTime;

            float normalizedTime = timer / duration;
            musicSource.volume = Mathf.SmoothStep(0, 1, normalizedTime);

            yield return new WaitForEndOfFrame();
        }
    }

    public void SetMusicVolume(float volumeNormalized)
    {
        //musicMixer.SetFloat("MusicVolume", Mathf.Lerp(volumeMin_dB, volumeMax_dB, volumeNormalized));
        musicMixer.SetFloat("MusicVolume", volumeNormalized);
    }
}
