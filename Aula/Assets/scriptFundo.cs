using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptFundo : MonoBehaviour
{
    private Rigidbody2D rbd;
    public float velocidade = 10;
    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        rbd.velocity = new Vector2(0, -velocidade);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector2(0, -velocidade) * Time.deltaTime);
        if (transform.position.y < -2 * Camera.main.orthographicSize)
        {
            transform.position = new Vector2(0, 2*Camera.main.orthographicSize);
        }
    }
}
