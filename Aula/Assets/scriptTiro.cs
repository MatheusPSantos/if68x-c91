using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptTiro : MonoBehaviour
{
    public float velocidade = 5;
    private Rigidbody2D rbd;
    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        rbd.velocity = new Vector2(0, velocidade);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > Camera.main.orthographicSize) {
            Destroy(gameObject);
        }
    }
}
