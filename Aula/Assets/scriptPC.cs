using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPC : MonoBehaviour {
    private Rigidbody2D rbd;
    private AudioSource som;
    public float velocidade = 10;
    private float largura;
    private float altura;
    private float alturaNave;
    public GameObject tiro;
    
    // Start is called before the first frame update
    void Start() {
        som = GetComponent<AudioSource>();
        rbd = this.GetComponent<Rigidbody2D>();
        altura = Camera.main.orthographicSize;
        largura = Camera.main.aspect * altura;
        alturaNave = GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void Update() {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        rbd.velocity = new Vector2(x, y) * velocidade;

        verificarBordas();
        verificarTiro();
    }

    private void verificarBordas() {
        if (transform.position.x > largura) {
            transform.position = new Vector2(-largura, transform.position.y);
        }
        else if (transform.position.x < -largura) {
            transform.position = new Vector2(largura, transform.position.y);
        }

        if(transform.position.y > 0) {
            transform.position = new Vector2(transform.position.x, 0);
        } else if(transform.position.y < -altura) {
            transform.position = new Vector2(transform.position.x, -altura);
        }
    }

    private void verificarTiro() {
             if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetKeyDown("joystick button 0")) {           
            som.Play();
            Vector2 pos = new Vector2(transform.position.x, transform.position.y+ alturaNave);
            Instantiate(tiro, pos, Quaternion.identity);
        }
    }
}
