using UnityEngine;
using System.Collections;

// Leitet jeglichen Input an die entsprechende Klassen und Funktionen weiter
// Verabeitet selbst keinen Input
public class InputManager : MonoBehaviour
{
    /* Following Tags are needed:
        MainCamera to Main Camera
        Player to Character (Parentobject)
            Be careful that the children aren't tagged too!
        Kitchentool to all Kitchentools like the karrotes, fishes etc.

    */
    Ray ray;
    RaycastHit rayHit;
    public Vector3 touchPosition;

    CharacterMovement charMovement;
    //UIManager uiManager;

    void Awake()
    {
        charMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();
        //uiManager = GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>();
        touchPosition = charMovement.Player.transform.position;

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
            Debug.Log("Get Mousebutton");
            TouchPos();
            if(charMovement.checkIfMovable(touchPosition))
                charMovement.Move(touchPosition);


        }

    }

    private Vector3 TouchPos()
    {
        Plane plane = new Plane(Vector3.up, charMovement.Player.transform.position);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(Camera.main.transform.position, ray.direction, out rayHit);
        float point = 0f;
        if (plane.Raycast(ray, out point))
            touchPosition = ray.GetPoint(point);
        Debug.Log("TargetPos: " + touchPosition);


        return touchPosition;
    }
}
