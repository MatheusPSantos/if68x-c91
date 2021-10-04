using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptNPC : MonoBehaviour
{
    private Rigidbody2D rbd;
    public float velocidade = 5;
    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rbd.velocity = new Vector2(0, -velocidade);
        if(transform.position.y < -Camera.main.orthographicSize)
        {
            Destroy(this.gameObject);
        }
    }
}
