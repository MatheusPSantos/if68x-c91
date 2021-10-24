using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptNPC : MonoBehaviour
{
    private float altura;
    public float velocidade = 5;
    private Rigidbody2D rbd;

    // Start is called before the first frame update
    void Start()
    {
        altura = Camera.main.orthographicSize;
        rbd = GetComponent<Rigidbody2D>();
        rbd.velocity = new Vector2(0, -velocidade);    
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -altura) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Jogador") { }
        Destroy(collider.gameObject);
        Destroy(this.gameObject);
    }
}
