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
    public Button buttonA, buttonB, buttonC, buttonD;
    public Text quizText;
    public GameObject quizImg;
    private AudioClip lamusic;

    void Start()
    {
        service = new HttpPostService();
    }

    public void Excercise()
    {
        int sol;
        var result = Task.Run(() => service.GetExercise()).Result;
        StartCoroutine(GetAudioClip(result[0].Properties.HelperOne.Audio));
        Debug.Log(result[0].Properties.OptionOne);
        Debug.Log(result[0].Properties.OptionTwo);
        Debug.Log(result[0].Properties.OptionThree);
        Debug.Log(result[0].Properties.OptionFour);
        Debug.Log(result[0].Properties.Solution);
        quizImg.SetActive(true);
        quizText.text = result[0].Properties.Editor;
        foreach (Transform child in buttonA.transform)
        {
            child.gameObject.GetComponent<Text>().text = result[0].Properties.OptionOne;
        }
        
        foreach (Transform child in buttonB.transform)
        {
            child.gameObject.GetComponent<Text>().text = result[0].Properties.OptionTwo;
        }
        
        foreach (Transform child in buttonC.transform)
        {
            child.gameObject.GetComponent<Text>().text = result[0].Properties.OptionThree;
        }
        
        foreach (Transform child in buttonD.transform)
        {
            child.gameObject.GetComponent<Text>().text = result[0].Properties.OptionFour;
        }

        if (result[0].Properties.OptionOne.Equals(result[0].Properties.Solution))
        {
            sol = 0;
        }
        else if (result[0].Properties.OptionTwo.Equals(result[0].Properties.Solution))
        {
            sol = 1;
        }
        else if (result[0].Properties.OptionThree.Equals(result[0].Properties.Solution))
        {
            sol = 2;
        }
        else
        {
            sol = 3;
        }
        //Debug.Log();
        //StartCoroutine(DownloadImage(result[0].Properties.HelperOne.Images[0].Url));
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
