using UnityEngine;
using System.Collections;

// Beinhaltet sämtliche Funktionen zu den Geräten in der Küche ( Reiskocher, Wok, Makisu, Kühlschrank etc..)
// Für jedes Gerät eine eigene Funktion
// Funktion startet einen Timer, veranschaulicht durch ein UI
public class Geräte : MonoBehaviour
{
    

    public class KitchenTool
    {
        private float cookTime = 10f;
        public ParticleSystem smokeParticle;
        Animator animController;
    }

    public KitchenTool carotte = new KitchenTool();
    public KitchenTool rice = new KitchenTool();
    public KitchenTool fish = new KitchenTool();
    public KitchenTool nori = new KitchenTool();
    public KitchenTool riceCooker = new KitchenTool();
    public KitchenTool makisu = new KitchenTool();

   

    void Awake()
    {
        // Check what the Name from Object for using the correct classe 
        if(gameObject.name == "Karotte")
        {
            // set values
        }
        else if (gameObject.name == "Reis")
        {

        }
        else if (gameObject.name == "Fisch")
        {

        }
        else if (gameObject.name == "Nori")
        {

        }
        else if (gameObject.name == "Reiskocher")
        {

        }
        else if (gameObject.name == "Makisu")
        {

        }
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
