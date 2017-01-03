using UnityEngine;
using System.Collections;

public class DestroyGameObject : MonoBehaviour 
{
    public float TimeTillDestroy = 2f;

    void Update()
    {
        DestroyObject(this.gameObject, TimeTillDestroy);
    }
	
}