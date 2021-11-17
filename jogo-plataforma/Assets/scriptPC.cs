using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPC : MonoBehaviour
{
    private Rigidbody2D rbd;
    public float velocidade = 5;
    public float pulo = 250;
    private bool chao = true;
    private Animator anim;
    private bool direita = true;
    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        if (x == 0)
            anim.SetBool("parado", true);
        else
            anim.SetBool("parado", false);

        if (direita && x < 0 || !direita && x > 0)
        {
            direita = !direita;
            transform.Rotate(new Vector2(0, 180));
        }

        float velY;

        if (chao)
            velY = 0;
        else
            velY = rbd.velocity.y;

        rbd.velocity = new Vector2(x * velocidade, velY);

        if (Input.GetKeyDown(KeyCode.Space) && chao)
        {
            chao = false;
            rbd.AddForce(new Vector2(0, pulo));
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        chao = true;
        transform.parent = collision.transform;
    }

    private void OnCollisionExit2D(Collision2D collition)
    {
        chao = false;
        transform.parent = null;
    }
}
