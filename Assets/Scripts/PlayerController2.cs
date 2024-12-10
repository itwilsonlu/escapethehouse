using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController2 : MonoBehaviour
{
    public TMP_Text objectiveText;
    public Transform spawnPoint;
    public GameObject Enemy;

    bool hasTriggered = false;
    bool hasTriggered2 = false;
    bool hasTriggered3 = false;
    bool hasDestroyed = false;




    // Start is called before the first frame update
    void Start()
    {
        objectiveText.text = "Objective: Escape";
    }

    // Update is called once per frame
    void Update()
    {
        if (GameData.balls == 4) {
            Destroy(GameObject.FindGameObjectWithTag("FakeWall"));
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("WallTrigger") && hasTriggered == false) 
        {
            objectiveText.text = "Objective: Solve the puzzle";
            bool hasTriggered = true;
        }
        if (other.CompareTag("WallTrigger2") && hasTriggered2 == false) {
            objectiveText.text = "Objective: Escape";
            bool hasTriggered2 = true;
        }
        if (other.CompareTag("WallTrigger3") && hasTriggered3 == false) {
            objectiveText.text = "Objective: Escape this maze";
            bool hasTriggered3 = true;
        }
        if (other.CompareTag("Key")) {
            objectiveText.text = "Objective: Escape";
            Destroy(other.gameObject);
            hasDestroyed = true;
            objectiveText.text = "Objective: Avoid the monster and escape";
            Instantiate(Enemy, spawnPoint.position, spawnPoint.rotation);
        }
        if (other.CompareTag("NPC") && hasDestroyed == true) {
            objectiveText.text = "";
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level3");
        }
        else if (other.CompareTag("NPC") && hasDestroyed == false) {
            objectiveText.text = "NPC: You're missing the lie to this maze";
        }
        if (other.CompareTag("AI")) {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Lose");
        }
    }
}
