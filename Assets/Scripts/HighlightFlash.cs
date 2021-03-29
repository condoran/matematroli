using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HighlightFlash : MonoBehaviour
{

    [SerializeField] private int blueCol;
    [SerializeField] private int redCol;
    [SerializeField] private int greenCol;

    private bool flashingIn;
    private bool objectHighlighted;
    private bool startedFlashing;
    private Renderer renderer;
    private List<Color32> normalColors;
    
    // Start is called before the first frame update
    void Start()
    {
        flashingIn = true;
        objectHighlighted = false;
        startedFlashing = false;
        renderer = this.GetComponent<Renderer>();
        normalColors = new List<Color32>();
        foreach (Material material in renderer.materials)
        {
            normalColors.Add(material.color);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (objectHighlighted)
        {
            foreach (Material material in renderer.materials)
            {
                material.color = new Color32((byte) redCol, (byte) greenCol, (byte) blueCol, 255);
            }
        }
    }

    public void StartHighlight()
    {
        objectHighlighted = true;
        if (startedFlashing == false)
        {
            startedFlashing = true;
            StartCoroutine(FlashObject());
        }
    }

    public void StopHighlight()
    {
        startedFlashing = false;
        objectHighlighted = false;
        StopCoroutine(FlashObject());
        for (int i = 0; i < renderer.materials.Length; i++)
        {
            renderer.materials[i].color = normalColors.ElementAt(i);
        }    
    }

    IEnumerator FlashObject()
    {
        while (objectHighlighted)
        {
            yield return new WaitForSeconds(0.05f);
            if (flashingIn)
            {
                if (greenCol <= 30)
                {
                    flashingIn = false;
                }
                else
                {
                    redCol -= 25;
                    blueCol -= 1;
                }
            }
            else
            {
                if (greenCol >= 250)
                {
                    flashingIn = true;
                }
                else
                {
                    greenCol += 25;
                    blueCol += 1;
                }
            }
        }
    }
}
