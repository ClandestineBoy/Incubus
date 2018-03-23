using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour {

    public static sound me = null;
    public GameObject audioSourcePrefab;
    public AudioSource[] audioSources;

    // Use this for initialization

    private void Awake()
    {
        if (me == null)
        {
            DontDestroyOnLoad(this);
            me = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start() {
        audioSources = new AudioSource[64];
        for (int i = 0; i < audioSources.Length; i++)
        {
            audioSources[i] = (Instantiate(audioSourcePrefab) as GameObject).GetComponent<AudioSource>();
            audioSources[i].transform.SetParent(transform);
        }
    }

    public AudioSource PlaySound(AudioClip clip)
    {
        return PlaySound(clip, 1f, 1f);
    }

    public AudioSource PlaySound(AudioClip clip, float volume, float pitch, bool loop = false)
    {
        int index = GetSourceIndex();
        audioSources[index].clip = clip;
        audioSources[index].volume = volume;
        audioSources[index].pitch = pitch;
        audioSources[index].loop = loop;

        audioSources[index].Play();
        return audioSources[index];
    }
    public int GetSourceIndex()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (!audioSources[i].isPlaying)
            {
                return i;
            }
        }
        Debug.Log("all audiosources are currently playing");
        return 0;
    }
    public void StopSound(AudioSource audioSource)
    {
        audioSource.Stop();
    }
    // Update is called once per frame
    void Update() {
    }
}
