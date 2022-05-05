using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Fruit")
        {
            Destroy(gameObject);
        }
        
    }
}
