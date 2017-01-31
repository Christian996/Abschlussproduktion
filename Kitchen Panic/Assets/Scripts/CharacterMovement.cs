using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

// Verarbeitet die Charaktersteuerung
public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    public GameObject Player;

    [SerializeField]
    private NavMeshAgent agent;
    private Vector3 agentTarget;
    private float speed;

    [SerializeField]
    private bool isMoveable;
    private RaycastHit hit;

    // Kitchentools will be saved in a List
    // All Kitchentools have to be tagged with "Kitchentool"
    private List<GameObject> LKitchentools;

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (Player != null)
            Debug.Log("Find Player");

        agent = GetComponent<NavMeshAgent>();
        if (agent != null)
            Debug.Log("Agentname: " + agent.name);

        LKitchentools = new List<GameObject>();
        agentTarget = Vector3.zero;
        LKitchentools = new List<GameObject>();
        isMoveable = false;
        hit = new RaycastHit();
    }

    // Use this for initialization
    void Start()
    {
        AddKtichentoolsToTheList();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(Camera.main.transform.position, agentTarget - Camera.main.transform.position, Color.red);
    }

    public void Move(Vector3 targetPosition)
    {
        agentTarget = targetPosition;

        agent.SetDestination(agentTarget);
        Debug.DrawRay(transform.position, agentTarget - transform.position, Color.red);
        agent.transform.forward = Vector3.Lerp(agent.transform.forward, agentTarget, 2f);

    }

    private void AddKtichentoolsToTheList()
    {
        foreach (GameObject c in GameObject.FindGameObjectsWithTag("Kitchentool"))
        {
            LKitchentools.Add(c);
        }
        Debug.Log("Anzahl der Kitchentools in der Liste:" + LKitchentools.Count);
    }

    public bool checkIfMovable(Vector3 targetPosition)
    {
        agentTarget = targetPosition;
        if (Physics.Raycast(Camera.main.transform.position, agentTarget - Camera.main.transform.position, out hit))
        {
            Debug.Log("Hit object's tag: " + hit.collider.tag);
            if (hit.collider.CompareTag("Kitchentool"))
            {
                return isMoveable = true;
            }

        }
        Debug.Log("Char isn't moveable");
        return isMoveable = false;
    }
}
