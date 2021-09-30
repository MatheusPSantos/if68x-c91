using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPC : MonoBehaviour {
    private Rigidbody2D rbd;
    public float velocidade = 10;

    // Start is called before the first frame update
    void Start() {
        rbd = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        rbd.velocity = new Vector2(x, y) * velocidade;
    }
}
