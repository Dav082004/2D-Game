using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //es importante que pongas eso

public class RestartGame : MonoBehaviour
{
    public void RestartGame1()
    {
        SceneManager.LoadScene("Scene 1");
    }
}
