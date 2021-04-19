using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MatematroliiCreateConfig.Service;
using UnityEngine;

public class StartExcercises : MonoBehaviour
{
    private HttpPostService service;
    public AudioSource audio;
    private AudioClip lamusic;
    private WWW sound;
    
    void Start()
    {
        service = new HttpPostService();
    }

    public void Excercise()
    {
        var result = Task.Run(() => service.GetExercise()).Result;
        sound = new WWW(result[0].Properties.HelperOne.Audio);
        lamusic = sound.GetAudioClip(true, true, AudioType.MPEG);
        //audio.clip = lamusic;
        audio.PlayOneShot(lamusic);
    }
}
