using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptJogo : MonoBehaviour
{
    public void Iniciar() {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void Sair() {
        Application.Quit();
    }
}
