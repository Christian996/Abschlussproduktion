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

    // will be set in the "SetTransparency"-Function
    float transparency = 0f;

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
                    SetIcon(carotteCooked = true, activeKitchentool.name);

            }
            else if (activeKitchentool.name == "Reis")
            {
                // reduce cooktime
                cookTimeRice -= Time.deltaTime;
                // Check if cookTime reaching 0
                // if true, activate the icon for the kitchentool
                if (cookTimeRice <= 0)
                    SetIcon(riceCooked = true, activeKitchentool.name);

            }
            else if (activeKitchentool.name == "Reiskocher")
            {
                // reduce cooktime
                cookTimeRiceCooker -= Time.deltaTime;
                // Check if cookTime reaching 0
                // if true, activate the icon for the kitchentool
                if (cookTimeRiceCooker <= 0)
                    SetIcon(riceCookerCooked = true, activeKitchentool.name);

            }
            else if (activeKitchentool.name == "Fisch")
            {
                // reduce cooktime
                cookTimeFish -= Time.deltaTime;
                // Check if cookTime reaching 0
                // if true, activate the icon for the kitchentool
                if (cookTimeFish <= 0)
                    SetIcon(fishCooked = true, activeKitchentool.name);

            }
            else if (activeKitchentool.name == "Nori")
            {
                // reduce cooktime
                cookTimeNori -= Time.deltaTime;
                // Check if cookTime reaching 0
                // if true, activate the icon for the kitchentool
                if (cookTimeNori <= 0)
                    SetIcon(noriCooked = true, activeKitchentool.name);

            }
            else if (activeKitchentool.name == "Makisu")
            {
                // reduce cooktime
                cookTimeMakisu -= Time.deltaTime;
                // Check if cookTime reaching 0
                // if true, activate the icon for the kitchentool
                if (cookTimeMakisu <= 0)
                {
                    Debug.Log("Makisu is cooked");
                    SetIcon(makisuCooked = true, activeKitchentool.name);
                }

            }
        }
        #endregion

        //ActivateIcon(smokeParticles, 
    }
    // Check which Kitchentool was clicked
    // and play his ParticleSystem
    public GameObject StartParticleSystem(GameObject p_clickedKitchentool)
    {

        Debug.Log("Check which Kitchentool is clicked");
        // Check which kitchentool is clicked to set the lifetime from the ParticleSystem
        // Carotte
        if (p_clickedKitchentool.name == "Karotte" && !carotteCooked)
        {
            Debug.Log("Clicked Kitchentool: " + p_clickedKitchentool.name);

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
                Debug.Log("ParticleSystem from: " + p_clickedKitchentool.name + " is already playing");

            return activeKitchentool = p_clickedKitchentool;
        }
        else
            smokeParticles.Clear();

        // Rice
        if (p_clickedKitchentool.name == "Reis" && !riceCooked)
        {
            Debug.Log("Clicked Kitchentool: " + p_clickedKitchentool.name);
            smokeParticles = GetComponentInChildren<ParticleSystem>();
            // check if particlesystem is already playing
            if (smokeParticles.isPlaying == false)
            {

                // Set lifetime
                smokeParticles.startLifetime = cookTimeRice;
                smokeParticles.Play();
            }
            else Debug.Log("ParticleSystem from: " + p_clickedKitchentool.name + " is already playing");

            return activeKitchentool = p_clickedKitchentool;
        }
        else
            smokeParticles.Clear();

        // Nori
        if (p_clickedKitchentool.name == "Nori" && !noriCooked)
        {
            Debug.Log("Clicked Kitchentool: " + p_clickedKitchentool.name);
            smokeParticles = GetComponentInChildren<ParticleSystem>();
            // check if particlesystem is already playing
            if (smokeParticles.isPlaying == false)
            {

                // Set lifetime
                smokeParticles.startLifetime = cookTimeNori;
                smokeParticles.Play();
            }
            else Debug.Log("ParticleSystem from: " + p_clickedKitchentool.name + " is already playing");

            return activeKitchentool = p_clickedKitchentool;
        }
        else
            smokeParticles.Clear();

        // Makisu
        if (p_clickedKitchentool.name == "Makisu" && !makisuCooked)
        {
            Debug.Log("Clicked Kitchentool: " + p_clickedKitchentool.name);
            smokeParticles = GetComponentInChildren<ParticleSystem>();
            // check if particlesystem is already playing
            if (smokeParticles.isPlaying == false)
            {
                // Set lifetime
                smokeParticles.startLifetime = cookTimeMakisu;
                smokeParticles.Play();
            }
            else
                Debug.Log("ParticleSystem from: " + p_clickedKitchentool.name + " is already playing");

            return activeKitchentool = p_clickedKitchentool;
        }
        else
            smokeParticles.Clear();

        // Ricecooker
        if (p_clickedKitchentool.name == "Reiskocher" && !riceCookerCooked)
        {
            Debug.Log("Clicked Kitchentool: " + p_clickedKitchentool.name);
            smokeParticles = GetComponentInChildren<ParticleSystem>();
            // check if particlesystem is already playing
            if (smokeParticles.isPlaying == false)
            {

                // Set lifetime
                smokeParticles.startLifetime = cookTimeRiceCooker;
                smokeParticles.Play();
            }
            else Debug.Log("ParticleSystem from: " + p_clickedKitchentool.name + " is already playing");

            return activeKitchentool = p_clickedKitchentool;
        }
        else
            smokeParticles.Clear();

        // Fish
        if (p_clickedKitchentool.name == "Fisch" && !fishCooked)
        {
            Debug.Log("Clicked Kitchentool: " + p_clickedKitchentool.name);
            smokeParticles = GetComponentInChildren<ParticleSystem>();
            // check if particlesystem is already playing
            if (smokeParticles.isPlaying == false)
            {

                // Set lifetime
                smokeParticles.startLifetime = cookTimeFish;
                smokeParticles.Play();
            }
            else
                Debug.Log("ParticleSystem from: " + p_clickedKitchentool.name + " is already playing");
            return activeKitchentool = p_clickedKitchentool;
        }
        else
            smokeParticles.Clear();

        return null;
    }

    // Called in the update - function to check if duration from particle system is finished
    // after finishing, set icon transparence to 255
    // After finishing makisu, reset transparency
    void SetIcon(bool cookedKitchentool, string kitchentoolName)
    {
        // Check what bool is true and check whats the name from kitchentool
        // call SetTransparency - Function
        if (cookedKitchentool && kitchentoolName == "Karotte")
        {
            // Carotte
            Debug.Log("Change Alpha from  " + kitchentoolName);
            SetTransparency(im_carotte, carotteCooked);

        }
        else if (cookedKitchentool && kitchentoolName == "Reis")
        {
            // Rice
            Debug.Log("Change Alpha from " + kitchentoolName);
            SetTransparency(im_rice, riceCooked);

        }
        else if (cookedKitchentool && kitchentoolName == "Reiskocher")
        {
            // Ricecooker
            Debug.Log("Change Alpha from " + kitchentoolName);
            SetTransparency(im_riceCooker, riceCookerCooked);

        }
        else if (cookedKitchentool && kitchentoolName == "Fisch")
        {
            // Fish
            Debug.Log("Change Alpha from " + kitchentoolName);
            SetTransparency(im_fish, fishCooked);

        }
        else if (cookedKitchentool && kitchentoolName == "Nori")
        {
            // Nori
            Debug.Log("Change Alpha from " + kitchentoolName);
            SetTransparency(im_nori, noriCooked);

        }
        // No icon for Makisu
        // if Makisu finished, reset all icons
        else if (cookedKitchentool && kitchentoolName == "Makisu")
        {
            Debug.Log("Change Alpha from " + kitchentoolName);
            //SetTransparency(im_makisu, makisuCooked);
            // set bools to false

            carotteCooked = false;
            riceCooked = false;
            riceCookerCooked = false;
            fishCooked = false;
            noriCooked = false;
            makisuCooked = false;

            //#region CheckStateOfKitchentool
            //Debug.Log("Carotte is cooked: " + carotteCooked);
            //Debug.Log("Rice is cooked: " + riceCooked);
            //Debug.Log("RiceCooker is cooked: " + riceCookerCooked);
            //Debug.Log("Fish is cooked: " + fishCooked);
            //Debug.Log("Nori is cooked: " + noriCooked);
            //#endregion
            SetTransparency(im_carotte, carotteCooked);
            SetTransparency(im_rice, riceCooked);
            SetTransparency(im_riceCooker, riceCookerCooked);
            SetTransparency(im_fish, fishCooked);
            SetTransparency(im_nori, noriCooked);

        }
    }

    // Check if bool true
    // if so, transparency will be set to 255f,
    // else to 140f;
    void SetTransparency(Image p_imageToChange, bool p_isKitchentoolCooked)
    {
        float cookedTransparency = 1f;
        float uncookedTransparency = .3f;

        if (p_imageToChange != null)
        {
            // make a tmp variable to save the color
            UnityEngine.Color color = p_imageToChange.color;
            Debug.Log("Got Image to change " + p_imageToChange.name);

            //#region CheckStateOfKitchentool
            //Debug.Log("Carotte is cooked: " + carotteCooked);
            //Debug.Log("Rice is cooked: " + riceCooked);
            //Debug.Log("RiceCooker is cooked: " + riceCookerCooked);
            //Debug.Log("Fish is cooked: " + fishCooked);
            //Debug.Log("Nori is cooked: " + noriCooked);
            //#endregion

            if (p_isKitchentoolCooked)
            {
                Debug.Log("Change transparency to cooked.");
                // change alpha from tmp color
                color.a = cookedTransparency;
                // give the changed alpha to the original color 
                p_imageToChange.color = color;
            }
            else
            {
                Debug.Log("Change transparency to uncooked.");
                // change alpha from tmp color
                color.a = uncookedTransparency;
                // give the changed alpha to the original color 
                p_imageToChange.color = color;
            }


        }
    }

    //void ResetParticleSystems

}
