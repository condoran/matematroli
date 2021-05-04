using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MatematroliiCreateConfig.Service;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class StartExcercises : MonoBehaviour
{
    private HttpPostService service;
    public AudioSource audio;
    public RawImage img;
    private AudioClip lamusic;

    void Start()
    {
        service = new HttpPostService();
    }

    public void Excercise()
    {
        var result = Task.Run(() => service.GetExercise()).Result;
        StartCoroutine(GetAudioClip(result[0].Properties.HelperOne.Audio));
        Debug.Log(result[0].Properties.HelperOne.Images[0].Url);
        StartCoroutine(DownloadImage(result[0].Properties.HelperOne.Images[0].Url));
    }
    
    IEnumerator GetAudioClip(string link)
    {
        using (var webRequest = UnityWebRequestMultimedia.GetAudioClip(link, AudioType.MPEG))
        {
            //((DownloadHandlerAudioClip)webRequest.downloadHandler).streamAudio = true;
 
            webRequest.SendWebRequest();
            while (!webRequest.isNetworkError && !((DownloadHandlerAudioClip)webRequest.downloadHandler).isDone)
                yield return null;
 
            if (webRequest.isNetworkError)
            {
                Debug.LogError(webRequest.error);
                yield break;
            }
       
            lamusic = ((DownloadHandlerAudioClip)webRequest.downloadHandler).audioClip;
            audio.clip = lamusic;
            audio.Play();
        }
    }
    
    IEnumerator DownloadImage(string MediaUrl)
    {   
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("http://www.my-server.com/image.png");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else
        {
            img.gameObject.SetActive(true);
            img.texture = ((DownloadHandlerTexture) www.downloadHandler).texture;
        }
    } 
}
