using UnityEngine;
using System.Collections;

public class WordSpaceTextBehaviour : MonoBehaviour
{
    public float DestroyTime = 0.3f;                    // Text destroy timer. Default: 5
    public Vector3 MovementDirection = Vector3.up;      // Text movement direction, Default: UP
    public bool EnableTextDestroyTimer;
    public bool EnableTextMovement;

    private float _speed = 0.5f;

	void Update ()
	{
	    TextMovement();
	    DestroyText();
	}

    void TextMovement()
    {
        if(EnableTextMovement)
            transform.Translate(Vector3.up * Time.deltaTime * _speed);
    }

    void DestroyText()
    {
        if (EnableTextDestroyTimer)
            DestroyObject(this.gameObject, DestroyTime);
    }

    void TextFadeTime()
    {
        // coming soon.
    }
}
