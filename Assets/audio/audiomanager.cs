using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.SceneManagement;

public class audiomanager : MonoBehaviour
{
    public AudioMixerGroup audioMixer;
    public MusicClass.Sound[] sounds;
    private AudioSource[] allAudioSources;
    public int level = 0;
    public int credit = 0;
    public int menu = 0;
    public int end = 0;
    bool ToggleChange;
    private void Awake()
    {
        foreach (MusicClass.Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = audioMixer;
        }
        allAudioSources = FindObjectsOfType<AudioSource>();
    }

    /*public void levelChecker()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "level01") 
        {
            Play("theme");
            Play("rain");
            Play("city");
        }
        if (sceneName == "End_Screen")
        {
            Play("rain");
            Play("theme");
        }
        else
        {
            Play("theme");
        }
    }*/


    private void Update()
    {
        string sceneName = SceneManager.GetActiveScene().name;

            if (sceneName == "Level01" && level == 0)
            {
                Play("rain");
                Play("city");
                level = 1;
                menu = 0;
            }

            if (sceneName == "End_Screen" && end == 0)
            {
                Play("theme");
                Play("rain");
                end = 1;
            }

            if (sceneName == "credit" && credit == 0)
            {
                Play("theme");
                credit = 1;
            }

            if (sceneName == "menu" && menu == 0)
            {
                Play("theme");
                menu = 1;
                credit = 0;
                end = 0;
            }
        


            if (Time.timeScale <= 0)
        {
            foreach (AudioSource audioS in allAudioSources)
            {
                audioS.Pause();
            }
        }
        else
        {
            foreach (AudioSource audioS in allAudioSources)
            {
                audioS.UnPause();
            }
        }

    }

    private void FixedUpdate()
    {
        string sceneName = SceneManager.GetActiveScene().name;    
    }

    public void Play(string name)
    {
        MusicClass.Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Error:"+ name + "was not found!");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        MusicClass.Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Error:" + name + "was not found!");
            return;
        }
        s.source.Stop();
    }
}
