using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    Tree
}

public class InteractObject : MonoBehaviour
{
    public ObjectType objectType;

    public void Interact()
    {
        if (objectType == ObjectType.Tree)
        {
            Debug.Log("This is a tree"); }
    }
}
