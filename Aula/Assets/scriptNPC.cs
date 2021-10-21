using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptNPC : MonoBehaviour
{
    private Rigidbody2D rbd;
    private float altura;
    public float velocidade = 5;
    // Start is called before the first frame update
    void Start()
    {
        altura = Camera.main.orthographicSize;
        rbd = GetComponent<Rigidbody2D>();
        rbd.velocity = new Vector2(0, -velocidade);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -altura)
        {
            Destroy(this.gameObject);
        }
    }
}
