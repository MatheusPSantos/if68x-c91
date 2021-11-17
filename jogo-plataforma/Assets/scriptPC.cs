using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class scriptPC : MonoBehaviour
{
    private Rigidbody2D rbd;
    public float velocidade = 5;
    public float pulo = 250;
    private bool chao = true;
    private Animator anim;
    private bool direita = true;
    public LayerMask mascara;
    public LayerMask endPoint;
    public LayerMask espinhos;
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

        RaycastHit2D hit2D;
        RaycastHit2D frontHit;
        RaycastHit2D hitEnd;
        RaycastHit2D hitEspinhos;

        hit2D = Physics2D.Raycast(transform.position, -transform.up, 0.5f, mascara);
        hitEspinhos = Physics2D.Raycast(transform.position, -transform.up, 0.5f, mascara);
        frontHit = Physics2D.Raycast(transform.position, transform.right, 0.5f, mascara);        
        hitEnd = Physics2D.Raycast(transform.position, transform.right, 0.5f, endPoint);

        if(hit2D.collider != null) {
            Destroy(hit2D.collider.gameObject);
        }

        if(frontHit.collider != null || hitEspinhos.collider != null) {
            Destroy(gameObject);
            SceneManager.LoadScene(3);
        }

        if(hitEnd.collider != null) {
            Destroy(gameObject);
            SceneManager.LoadScene(2);
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
