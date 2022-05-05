using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField]
    protected Color color;

    public virtual Color Color => color;

    public void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Liquid")
        {
            Destroy(gameObject);
        }

    }
}
