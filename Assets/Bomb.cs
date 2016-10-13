using UnityEngine;
using System.Collections;

public class Bomb : Item 
{
    [Tooltip("Time till the bombs detonation.")]
    public float FuseTime = 5f;
   
    public float ExplosionForce = 250f;

    private float _startTime;
    private bool _hasExploded;

    private TextMesh _countDownTimerText;
    private Obstacle _obstacle;

    void Start()
    {
        _startTime = Time.time + FuseTime;
        _countDownTimerText = GetComponentInChildren<TextMesh>();
    }

    void Update()
    {
        if(_startTime - Time.time <= 0)
        {
            if (!_hasExploded)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, 1f);

                foreach (var hit in colliders)
                {
                    Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();

                    if (rb != null)
                    {
                        rb.gravityScale = 1;
                        rb.isKinematic = false;
                        rb.AddForceAtPosition(-this.transform.position * ExplosionForce, hit.transform.position, ForceMode2D.Force);
                        if (rb.GetComponent<Ball>())
                        {
                            Destroy(rb.gameObject);
                        }
                        if (rb.GetComponent<DestructionSystem>())
                        {
                            _obstacle = rb.GetComponentInParent<Obstacle>();
                            _obstacle.RemoveItemFromChildObjectsList(rb.GetComponent<DestructionSystem>());
                        }

                        DestroyObject(rb.gameObject, 3f);
                    }
                }
                _hasExploded = true;
            }
            DestroyObject(this.gameObject);
        }
        UpdateTimerText();
    }

    void UpdateTimerText()
    {
        int timer = Mathf.RoundToInt(_startTime - Time.time);
        _countDownTimerText.text = timer.ToString();
    }
}