using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Obstacle))]
public class DestructionSystem : MonoBehaviour
{
    private Obstacle _obstacle;

    void Start()
    {
        _obstacle = GetComponentInParent<Obstacle>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Ball>())
        {
            Debug.Log("Player hit.");
            this.GetComponent<Rigidbody2D>().isKinematic = false;

            this.GetComponent<Rigidbody2D>().AddForceAtPosition(
                -col.gameObject.GetComponent<Rigidbody2D>().velocity * 40f
                ,this.transform.position, ForceMode2D.Force);

            this.GetComponent<PolygonCollider2D>().isTrigger = true;

            _obstacle.RemoveItemFromChildObjectsList(this);

            _obstacle.GetComponent<Animator>().SetTrigger("onHit");

            DestroyObject(this.gameObject, 2f);
        }
    }
}
