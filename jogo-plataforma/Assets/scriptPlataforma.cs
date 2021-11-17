using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPlataforma : MonoBehaviour
{
    private float count = 0;
    public float velocidade = 3;
    private Vector2 posicaoInicial;
    public float largura = 1;
    public float altura = 1;
    // Start is called before the first frame update
    void Start()
    {
        posicaoInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        count += velocidade * Time.deltaTime;        
        float posX = Mathf.Cos(count) * largura;
        float posY = Mathf.Sin(count) * altura;

        Vector2 posicaoAtual = new Vector2(posX, posY);
        transform.position = posicaoInicial + posicaoAtual;

        if(count >= 2 * Mathf.PI)
            count = 2 * Mathf.PI - count;
    }
}
