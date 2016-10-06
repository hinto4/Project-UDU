using UnityEngine;
using System.Collections;

public class DamageIndicatorBehaviour : MonoBehaviour
{
    private float _speed = 0.5f;

	void Update ()
    {
	    transform.Translate(Vector3.up * Time.deltaTime * _speed);
        DestroyObject(this.gameObject,0.3f);
	}
}
