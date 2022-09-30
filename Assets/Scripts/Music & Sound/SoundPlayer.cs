using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    /** SoundPlayer:
    *   Script per la gestione dei file audio, in particolare degli effetti sonori
    */

    public AudioSource soundPlayer;
    public AudioClip soundNotFound;
    public AudioClip tap, win, pause, exit, nextPlayer, passPlayer, turnStart, endOfGame;

    void Start()
    {
        if (tap == null) {
            tap = soundNotFound;
        }

        if(PlayerPrefs.GetInt("mutedSFX") == 1) {
            gameObject.GetComponent<AudioSource>().mute = true;
        }
    }

    public void PlaySound(AudioClip audio) {
        soundPlayer.clip = audio;
        soundPlayer.Play(); 
    }

    public void PlayTapSound() {
        PlaySound(tap);
    }

    public void PlayWinSound() {
        PlaySound(win);
    }

    public void PlayPauseSound() {
        PlaySound(pause);
    }

    public void PlayExitSound() {
        PlaySound(exit);
    }

    public void PlayNextPlayerSound()
    {
        PlaySound(nextPlayer);
    }

    public void PlayPassPlayerSound()
    {
        PlaySound(passPlayer);
    }

    public void PlayTurnStartSound()
    {
        PlaySound(turnStart);
    }

    public void PlayEndofGameSound()
    {
        soundPlayer.volume = 0.4f;
        PlaySound(endOfGame);

    }

}
