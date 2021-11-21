using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItem : MonoBehaviour
{
    //private Rigidbody2D _rigidbody2D;

    //private void Start()
    //{
        //_rigidbody2D = GetComponent<Rigidbody2D>();
    //}
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Bag.Instance.AddWood(1);
            Destroy(gameObject);
        }
    }

    public void Explode()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-175f, 175f), Random.Range(0f, 170f)));
    }
}
