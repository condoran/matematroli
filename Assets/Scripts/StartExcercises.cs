using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MatematroliiCreateConfig.Service;
using UnityEngine;

public class StartExcercises : MonoBehaviour
{
    private HttpPostService service;
    
    
    void Start()
    {
        service = new HttpPostService();
    }

    public void Excercise()
    {
        var result = Task.Run(() => service.GetExercise()).Result;
        Debug.Log(result[0].Name + ", " + result[0].Title + ", " + result[0].Type + ", " + result[0].Description);
    }
}
