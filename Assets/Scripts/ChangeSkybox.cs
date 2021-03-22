using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkybox : MonoBehaviour
{
    
    public Material skyboxes;
    
    
    void Start()
    {
        RenderSettings.skybox = skyboxes;
    }
}
