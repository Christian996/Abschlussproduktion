using UnityEngine;
using System.Collections;
using System.Collections.Generic;
// Verarbeitet die Charaktersteuerung
public class CharacterMovement : MonoBehaviour
{
    private GameObject Player;

    // Kitchentools will be saved in a List
    // All Kitchentools have to be tagged with "Kitchentool"
    private List<GameObject> LKitchentools;

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (Player != null)
            Debug.Log("Find Player");

        LKitchentools = new List<GameObject>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
