using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    GameObject player;
    Vector3 destination;
    bool goingToSound = false;
    
    // Start is called before the first frame update
    public float range = 40.0f;

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            UnityEngine.AI.NavMeshHit hit;
            if (UnityEngine.AI.NavMesh.SamplePosition(randomPoint, out hit, 1.0f, UnityEngine.AI.NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (GameData.destination != Vector3.zero) {
            if (goingToSound) {
                if (agent.remainingDistance == 0) {
                    goingToSound = false;
                    GameData.destination = Vector3.zero;
                }
            } else {
                goingToSound = true;
                agent.destination = GameData.destination;
            }
        } else {
            if (RandomPoint(transform.position, range, out destination))
            {
                if (agent.remainingDistance == 0)
                {
                    agent.destination = destination;
                } 
            }
        }
    }
}
