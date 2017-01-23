using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
// Verarbeitet die Charaktersteuerung
public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    public GameObject Player;
    private NavMeshAgent agent;
    private Vector3 agentTarget;
    private float speed;

    // Kitchentools will be saved in a List
    // All Kitchentools have to be tagged with "Kitchentool"
    [SerializeField]
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
    }

    // Use this for initialization
    void Start()
    {
        AddKtichentoolsToTheList();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move(Vector3 targetPosition)
    {
        agentTarget = targetPosition;
        agent.SetDestination(agentTarget);
        Debug.DrawRay(transform.position, targetPosition, Color.red);
    }

    private void AddKtichentoolsToTheList()
    {
        foreach (GameObject c in GameObject.FindGameObjectsWithTag("Kitchentool"))
        {
            LKitchentools.Add(c);
        }
        Debug.Log("Anzahl der Kitchentools in der Liste:" + LKitchentools.Count);
    }
}
