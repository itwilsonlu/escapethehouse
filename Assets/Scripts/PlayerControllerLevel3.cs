using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControllerLevel3 : MonoBehaviour
{
    public Camera cam; 
    UnityEngine.AI.NavMeshAgent monster;
    public TMP_Text objectiveText;
    public float timer = 0f;
    bool first = true;
    // Start is called before the first frame update
    void Start()
    {
        GameData.points = 0;
        monster = GameObject.FindGameObjectWithTag("AI").GetComponent<UnityEngine.AI.NavMeshAgent>();
        objectiveText.text = "the mannequinn use all their power to grant you a skill\ntry it out press x";
        first = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (timer <= 8 && monster.speed == 0) {
            first = false;
            monster.speed = 3.5f;
        }
        if (Input.GetKeyDown(KeyCode.X)) {
            if (timer <= 0) {
                if (first) {
                    objectiveText.text = "it freeze the monster, there a big cooldown to use it again";
                }
                monster.speed = 0;
                timer = 10f;
            }
        }
        timer -= Time.deltaTime;
        if (timer > 0 && !first) {
            objectiveText.text = "cooldown: " + timer.ToString();
        } else if (timer <= 0 && !first) {
            objectiveText.text = "you can use x skill again";
        }
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Collectible")) {
            Destroy(other.gameObject);
            GameData.points++;
            if (GameData.points == 3) {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Win");
            }
        }
        if (other.CompareTag("AI")) {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Lose");
        }
    }
}
