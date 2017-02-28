using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KitchentoolManager : MonoBehaviour
{
    // Particlesystem for each Object
    public ParticleSystem smokeParticles;
    // the lifetime from the smokeParticle for each Kitchentool
    float cookTimeCarotte = 10;
    float cookTimeRice = 3;
    float cookTimeRiceCooker = 15;
    float cookTimeFish = 6;
    float cookTimeNori = 6;
    float cookTimeMakisu = 6;

    // After click a tool, acitveKitchentool will be filled
    GameObject activeKitchentool;
    GameObject clickedKitchentool;

    // Bools to check if one Kitchentool is finished
    // if true, canvas will be visible
    bool carotteCooked;
    bool riceCooked;
    bool riceCookerCooked;
    bool fishCooked;
    bool noriCooked;
    bool makisuCooked;

    // Images for the icons
    Image im_carotte;
    Image im_rice;
    Image im_riceCooker;
    Image im_fish;
    Image im_nori;
    Image im_makisu;

    void Awake()
    {
        activeKitchentool = null;
        clickedKitchentool = null;
        smokeParticles = this.GetComponentInChildren<ParticleSystem>();

        // Find Images in the Scene
        im_carotte = GameObject.Find("Image_Karotte").GetComponent<Image>();
        if (im_carotte == null)
            Debug.Log("Add a Image-Component to the UI and make sure, the Name is Image_Karotte");

        im_rice = GameObject.Find("Image_Reis").GetComponent<Image>();
        if (im_rice == null)
            Debug.Log("Add a Image-Component to the UI and make sure, the Name is Image_Reis");

        im_riceCooker = GameObject.Find("Image_Reiskocher").GetComponent<Image>();
        if (im_riceCooker == null)
            Debug.Log("Add a Image-Component to the UI and make sure, the Name is Image_Reiskocher");

        im_fish = GameObject.Find("Image_Fisch").GetComponent<Image>();
        if (im_fish == null)
            Debug.Log("Add a Image-Component to the UI and make sure, the Name is Image_Fisch");

        im_nori = GameObject.Find("Image_Nori").GetComponent<Image>();
        if (im_nori == null)
            Debug.Log("Add a Image-Component to the UI and make sure, the Name is Image_Nori");

        im_makisu = GameObject.Find("Image_Makisu").GetComponent<Image>();
        if (im_makisu == null)
            Debug.Log("Add a Image-Component to the UI and make sure, the Name is Image_Makisu");

    }
    // Use this for initialization
    void Start()
    {
        // make sure, that no bool is set to true at the beginnig from the games
        carotteCooked = false;
        riceCooked = false;
        riceCookerCooked = false;
        fishCooked = false; 
        noriCooked = false;
        makisuCooked = false;
    }

    void Update()
    {
        if (smokeParticles.isPlaying)
            Debug.Log("Particlesystem run: " + smokeParticles.time + " sec. long.");

        if (smokeParticles.time == cookTimeCarotte)
            Debug.Log("Particlesystem abgeschlossen");
        #region timer for kitchentools
        // Check the clicked Kitchentool to make clear, what variables should used
        if (activeKitchentool != null)
        {
            if (activeKitchentool.name == "Karotte")
            {
                // reduce cooktime
                cookTimeCarotte -= Time.deltaTime;
                // Check if cookTime reaching 0
                // if true, give the true bool to the ActivateIcon-Fucntion
                // it will activate the icons
                if (cookTimeCarotte <= 0)
                    ActivateIcon(carotteCooked = true);

            }
            else if (activeKitchentool.name == "Reis")
            {
                // reduce cooktime
                cookTimeRice -= Time.deltaTime;
                // Check if cookTime reaching 0
                // if true, activate the icon for the kitchentool
                if (cookTimeRice <= 0)
                    ActivateIcon(riceCooked = true);

            }
            else if (activeKitchentool.name == "Reiskocher")
            {
                // reduce cooktime
                cookTimeRiceCooker -= Time.deltaTime;
                // Check if cookTime reaching 0
                // if true, activate the icon for the kitchentool
                if (cookTimeRiceCooker <= 0)
                    ActivateIcon(riceCookerCooked = true);

            }
            else if (activeKitchentool.name == "Fisch")
            {
                // reduce cooktime
                cookTimeFish -= Time.deltaTime;
                // Check if cookTime reaching 0
                // if true, activate the icon for the kitchentool
                if (cookTimeFish <= 0)
                    ActivateIcon(fishCooked = true);

            }
            else if (activeKitchentool.name == "Nori")
            {
                // reduce cooktime
                cookTimeNori -= Time.deltaTime;
                // Check if cookTime reaching 0
                // if true, activate the icon for the kitchentool
                if (cookTimeNori <= 0)
                    ActivateIcon(noriCooked = true);

            }
            else if (activeKitchentool.name == "Makisu")
            {
                // reduce cooktime
                cookTimeMakisu -= Time.deltaTime;
                // Check if cookTime reaching 0
                // if true, activate the icon for the kitchentool
                if (cookTimeMakisu <= 0)
                    ActivateIcon(makisuCooked = true);

            }
        }
        #endregion

        //ActivateIcon(smokeParticles, 
    }
    // Check which Kitchentool was clicked
    // and play his ParticleSystem
    public GameObject StartParticleSystem(GameObject clickedKitchentool)
    {

        Debug.Log("Check which Kitchentool is clicked");
        // Check which kitchentool is clicked to set the lifetime from the ParticleSystem

        if (clickedKitchentool.name == "Karotte")
        {
            Debug.Log("Clicked Kitchentool: " + clickedKitchentool.name);

            smokeParticles = GetComponentInChildren<ParticleSystem>();
            // Set lifetime
            // Duration have to be set to the same value as the variables in the inspector
            // check if particlesystem is already playing
            if (smokeParticles.isPlaying == false)
            {

                smokeParticles.startLifetime = cookTimeCarotte;
                smokeParticles.Play();
            }
            else
                Debug.Log("ParticleSystem from: " + clickedKitchentool.name + " is already playing");

            return activeKitchentool = clickedKitchentool;
        }
        else if (clickedKitchentool.name == "Reis")
        {
            Debug.Log("Clicked Kitchentool: " + clickedKitchentool.name);
            smokeParticles = GetComponentInChildren<ParticleSystem>();
            // check if particlesystem is already playing
            if (smokeParticles.isPlaying == false)
            {

                // Set lifetime
                smokeParticles.startLifetime = cookTimeRice;
                smokeParticles.Play();
            }
            else Debug.Log("ParticleSystem from: " + clickedKitchentool.name + " is already playing");

            return activeKitchentool = clickedKitchentool;
        }
        else if (clickedKitchentool.name == "Nori")
        {
            Debug.Log("Clicked Kitchentool: " + clickedKitchentool.name);
            smokeParticles = GetComponentInChildren<ParticleSystem>();
            // check if particlesystem is already playing
            if (smokeParticles.isPlaying == false)
            {

                // Set lifetime
                smokeParticles.startLifetime = cookTimeNori;
                smokeParticles.Play();
            }
            else Debug.Log("ParticleSystem from: " + clickedKitchentool.name + " is already playing");

            return activeKitchentool = clickedKitchentool;
        }
        else if (clickedKitchentool.name == "Makisu")
        {
            Debug.Log("Clicked Kitchentool: " + clickedKitchentool.name);
            smokeParticles = GetComponentInChildren<ParticleSystem>();
            // check if particlesystem is already playing
            if (smokeParticles.isPlaying == false)
            {
                // Set lifetime
                smokeParticles.startLifetime = cookTimeMakisu;
                smokeParticles.Play();
            }
            else
                Debug.Log("ParticleSystem from: " + clickedKitchentool.name + " is already playing");

            return activeKitchentool = clickedKitchentool;
        }
        else if (clickedKitchentool.name == "Reiskocher")
        {
            Debug.Log("Clicked Kitchentool: " + clickedKitchentool.name);
            smokeParticles = GetComponentInChildren<ParticleSystem>();
            // check if particlesystem is already playing
            if (smokeParticles.isPlaying == false)
            {

                // Set lifetime
                smokeParticles.startLifetime = cookTimeRiceCooker;
                smokeParticles.Play();
            }
            else Debug.Log("ParticleSystem from: " + clickedKitchentool.name + " is already playing");

            return activeKitchentool = clickedKitchentool;
        }
        else if (clickedKitchentool.name == "Fisch")
        {
            Debug.Log("Clicked Kitchentool: " + clickedKitchentool.name);
            smokeParticles = GetComponentInChildren<ParticleSystem>();
            // check if particlesystem is already playing
            if (smokeParticles.isPlaying == false)
            {

                // Set lifetime
                smokeParticles.startLifetime = cookTimeFish;
                smokeParticles.Play();
            }
            else
                Debug.Log("ParticleSystem from: " + clickedKitchentool.name + " is already playing");
            return activeKitchentool = clickedKitchentool;
        }
        else
            return null;
    }

    // Called in the update - function to check if duration from particle system is finished
    // after finishing, set icon transparence to 100
    void ActivateIcon(bool cookedKitchentool)
    {
        // Change Alpha-canal to 100
        // Check out how to
        // Check what bool is true
        if (carotteCooked)
        {
            //im_carotte.
        }
    }

}
