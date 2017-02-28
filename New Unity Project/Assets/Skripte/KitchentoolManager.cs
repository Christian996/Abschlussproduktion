using UnityEngine;
using System.Collections;

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
    bool fishCooked;
    bool riceCooked;
    bool noriCooked;
    bool makisuCooked;
    bool riceCookerCooked;
    bool carotteCooked;


    void Awake()
    {
        activeKitchentool = null;
        clickedKitchentool = null;
        smokeParticles = this.GetComponentInChildren<ParticleSystem>();
    }
    // Use this for initialization
    void Start()
    {
        //smokeSparticles.playOnAwake = false;
        //smokeSparticles.Stop();
    }

    void Update()
    {
        if (smokeParticles.isPlaying)
            Debug.Log("Particlesystem run: " + smokeParticles.time + " sec. long.");

        if (smokeParticles.time == cookTimeCarotte)
            Debug.Log("Particlesystem abgeschlossen");

        // Check the clicked Kitchentool to make clear, what variables should used
        if (activeKitchentool != null)
        {
            if (activeKitchentool.name == "Karotte")
            {
                // reduce cooktime
                cookTimeCarotte -= Time.deltaTime;
                // Check if cookTime reaching 0
                // if true, activate the icon for the kitchentool
                if (cookTimeCarotte <= 0)
                    ActivateIcon(activeKitchentool);

            } else if (activeKitchentool.name == "Reis")
            {
                // reduce cooktime
                cookTimeRice -= Time.deltaTime;
                // Check if cookTime reaching 0
                // if true, activate the icon for the kitchentool
                if (cookTimeRice <= 0)
                    ActivateIcon(activeKitchentool);

            } else if (activeKitchentool.name == "Reiskocher")
            {
                // reduce cooktime
                cookTimeRiceCooker -= Time.deltaTime;
                // Check if cookTime reaching 0
                // if true, activate the icon for the kitchentool
                if (cookTimeRiceCooker <= 0)
                    ActivateIcon(activeKitchentool);

            }else if(activeKitchentool.name == "Fisch")
            {
                // reduce cooktime
                cookTimeFish -= Time.deltaTime;
                // Check if cookTime reaching 0
                // if true, activate the icon for the kitchentool
                if (cookTimeFish <= 0)
                    ActivateIcon(activeKitchentool);

            }else if(activeKitchentool.name == "Nori")
            {
                // reduce cooktime
                cookTimeNori -= Time.deltaTime;
                // Check if cookTime reaching 0
                // if true, activate the icon for the kitchentool
                if (cookTimeNori <= 0)
                    ActivateIcon(activeKitchentool);

            }else if(activeKitchentool.name == "Makisu")
            {
                // reduce cooktime
                cookTimeMakisu -= Time.deltaTime;
                // Check if cookTime reaching 0
                // if true, activate the icon for the kitchentool
                if (cookTimeMakisu <= 0)
                    ActivateIcon(activeKitchentool);

            }
        }

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
    void ActivateIcon(GameObject activeKitchentool)
    {
        Debug.Log("Activate Icon for " + activeKitchentool.name);
    }

}
