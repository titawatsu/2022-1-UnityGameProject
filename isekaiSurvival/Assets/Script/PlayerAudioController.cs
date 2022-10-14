using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private SoAudioClips bulletFireSound;
    [SerializeField] private SoAudioClips playerDamageSound;

    public void BulletFireSound() => audioSource.PlayOneShot(bulletFireSound.GetAudioClip(), 0.5f);

    public void PlayerDamageSound() => audioSource.PlayOneShot(playerDamageSound.GetAudioClip(), 0.5f);

}
