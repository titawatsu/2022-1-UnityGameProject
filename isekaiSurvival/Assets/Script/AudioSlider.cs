
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioSlider : MonoBehaviour
{

    public AudioMixer mixer;
    public string volumeName;

    public AudioSource testAudio;
    // for changing the volume by slider
    public void UpdateValueOnChange(float value)
    {
        mixer.SetFloat(volumeName, value);
        testAudio.Play();
    }
}
