using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerp : MonoBehaviour
{
    public float speed = 1.0f;
    private Material material;

   
    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }


    public IEnumerator Lerp(Color startColor, Color endColor)
    {
       
        var startTime = Time.time;
        float t = 0;
        while (t < 1)
        {
            t = (Time.time - startTime) * speed;
            //var startColor = material.GetColor("Color_fefca765011a49c5a393f5e4ab2e15c2");
            material.SetColor("Color_fefca765011a49c5a393f5e4ab2e15c2", Color.Lerp(startColor, endColor, t));
           
            yield return new WaitForEndOfFrame();
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }


}
