using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [Header("On Duel")]
    [SerializeField] AudioClip initialBGSound1;
    [SerializeField] AudioClip initialBGSound2;

    [Header("On Clash")]
    [SerializeField] AudioClip alertFX;

    [SerializeField] AudioClip attackFX;

    [SerializeField] AudioClip dyingFX;

    [Header("After Clash")]
    [SerializeField] AudioClip fanfareFX;

    [SerializeField] AudioClip mourningFX;


    [Header("Audio Sources")]

    [SerializeField] AudioSource backgroundSound1;

    [SerializeField] AudioSource backgroundSound2;

    void Awake () {
        GameManager.Instance.call_OnStartDuel_Events += PlayInitialBackgorundSound;
        GameManager.Instance.call_OnStartClash_Events += PlayClashSounds;
        GameManager.Instance.call_OnEndClash_Events += PlayEndClashSounds;
        GameManager.Instance.call_OnDelayedDeath_Events += PlayEndSequenceSounds;
    }

    void PlayInitialBackgorundSound() {
        backgroundSound1.clip = initialBGSound1;
        backgroundSound1.Play();

        backgroundSound2.clip = initialBGSound2;
        backgroundSound2.Play();
    }

    void PlayClashSounds(){
        StopPlaying();

        backgroundSound1.PlayOneShot(alertFX);
    }

    void PlayEndClashSounds(string winner){
        StopPlaying();

        if(winner == "player"){
            backgroundSound1.PlayOneShot(attackFX);
        } else if(winner == "enemy"){
            backgroundSound1.PlayOneShot(dyingFX);
        }
    }

    void PlayEndSequenceSounds(string winner)
    {
        StopPlaying();

        if (winner == "player")
        {
            backgroundSound1.PlayOneShot(fanfareFX);
        }
        else if (winner == "enemy")
        {
            backgroundSound1.PlayOneShot(mourningFX);
        }
    }

    void StopPlaying(){
        backgroundSound1.Stop();
        backgroundSound2.Stop();
    }
}
