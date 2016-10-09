using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LevelManager))]
public class NextLevelObjectBehaviour : MonoBehaviour
{
    private LevelManager _levelManager;

	void Start ()
    {
        _levelManager = GameObject.FindObjectOfType<LevelManager>();    
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject obj = col.gameObject;
        if(obj.tag == "Player")
        {
            _levelManager.GenerateNewLevel();

            Destroy(this.gameObject);
        }
    }
}
