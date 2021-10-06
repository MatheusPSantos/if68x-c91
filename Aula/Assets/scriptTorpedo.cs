using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptTorpedo : MonoBehaviour
{
    private Rigidbody2D rbd;
    public float velocidade = 15;
    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        rbd.velocity = new Vector2(0, velocidade);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > Camera.main.orthographicSize + 1) ;
        Destroy(gameObject);
    }
}
