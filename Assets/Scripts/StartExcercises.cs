using System.Collections;
using System.Collections.Generic;
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
        var result = service.GetExercise();
    }
}
