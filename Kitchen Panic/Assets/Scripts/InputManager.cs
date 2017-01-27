using UnityEngine;
using System.Collections;

// Leitet jeglichen Input an die entsprechende Klassen und Funktionen weiter
// Verabeitet selbst keinen Input
public class InputManager : MonoBehaviour
{
    Ray ray;
    public Vector3 targetPosition;

    CharacterMovement charMovement;

    void Awake()
    {
        charMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();
        targetPosition = charMovement.Player.transform.position;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // check if there is an input
        if (Input.GetMouseButtonDown(0))
        {
            TouchPos();
        }
        charMovement.Move(targetPosition);
    }

    private Vector3 TouchPos()
    {
        Plane plane = new Plane(Vector3.up, charMovement.Player.transform.position);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point = 0f;

        if (plane.Raycast(ray, out point))
            targetPosition = ray.GetPoint(point);
        Debug.Log("TargetPos: " + targetPosition);

        return targetPosition;
    }
}
