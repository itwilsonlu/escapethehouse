using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWin : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown || Input.GetButtonDown("Jump")) {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        }
    }
}