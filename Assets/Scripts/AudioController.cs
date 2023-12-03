using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource clickSound;
    public AudioSource bgMusic;
    public AudioSource mergeAudio;

    // This method is called when the button is clicked
    public void BGMusicMute()
    {
        bgMusic.mute = !bgMusic.mute;
    }

    public void SoundMute()
    {
        clickSound.mute = !clickSound.mute;
    }

    public void MergeAudio()
    {
        mergeAudio.mute = !mergeAudio.mute;
    }
}
