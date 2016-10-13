using UnityEngine;
using System.Collections;

public class ActionBar : MonoBehaviour
{
    public GameObject[] Items;

    void Update()
    {
        // temp code for test.
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(Items[0], this.transform.position, Quaternion.identity);
        }
    }
	
}