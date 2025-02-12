using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public static AudioPlayer instance;
    void Awake()
    {
        ManageSingleton();
    }
    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public AudioClip eatingClip;
    public float eatingClipVolume = 1f;
    public void PlayEatingClip()
    {
        playClip(eatingClip, eatingClipVolume);
    }
    public void playClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 position = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, position, volume);
        }
    }
}
