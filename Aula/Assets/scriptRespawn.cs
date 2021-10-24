using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptRespawn : MonoBehaviour
{
    public GameObject inimigo;
    private float altura;
    private float largura;
    private bool pausado = false;
    // Start is called before the first frame update
    void Start()
    {
        altura = Camera.main.orthographicSize;
        largura = altura * Camera.main.aspect;
        InvokeRepeating("Respawn", 1, 1);
    }

    private void Respawn()
    {
        float randomx = Random.Range(-largura, largura);

        Vector2 posicao = new Vector2(randomx, altura + 1);
        Instantiate(inimigo, posicao, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausado)
            {
                Time.timeScale = 1;
                SceneManager.UnloadSceneAsync(0);
            }
            else
            {                
                Time.timeScale = 0;
                SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive);
            }
            pausado = !pausado;
        }
    }
}
