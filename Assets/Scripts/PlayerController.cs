using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    AudioSource src;
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public TMP_Text objectiveText;

    void Start () 
    {
        src = GetComponent<AudioSource>();
        objectiveText.text = "Objective: Give the mannequin the three items";
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Collectible")) 
        {
            GameData.points++;
            if (GameData.points == 3) {
                objectiveText.text = "Objective: Go to the mannequin";
            }
            src.PlayOneShot(GameData.points == 1 ? sound1 : GameData.points == 2 ? sound2 : sound3);
            GameData.destination = transform.position;
            Debug.Log("Game Data: " + GameData.destination);
            Destroy(other.gameObject);
        }
        if (GameData.points == 3 && other.CompareTag("NPC")) {
            objectiveText.text = "";
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
        }
        if (other.CompareTag("AI")) 
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Lose");
        }
    }
}