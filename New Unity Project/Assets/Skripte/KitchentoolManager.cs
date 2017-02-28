using UnityEngine;
using System.Collections;

public class KitchentoolManager : MonoBehaviour
{
    public ParticleSystem smokeSparticles;
    float cookTime;

    GameObject lastActiveKitchentool;
    GameObject clickedKitchentool;

    void Awake()
    {
        lastActiveKitchentool = null;
        clickedKitchentool = null;
    }
    // Use this for initialization
    void Start()
    {
        smokeSparticles.playOnAwake = false;
        smokeSparticles.Stop();
    }

    // Check which Kitchentool was clicked
    // and play his ParticleSystem
    public GameObject StartParticleSystem(GameObject clickedKitchentool)
    {
        Debug.Log("Check which Kitchentool is clicked");
        // Check which kitchentool is clicked
        if (clickedKitchentool.name == "Karotte" )
        { 
            Debug.Log("Clicked Kitchentool: " + clickedKitchentool.name);
            smokeSparticles = GetComponentInChildren<ParticleSystem>();
            smokeSparticles.Play();
        }
        else if (clickedKitchentool.name == "Reis")
        {
            Debug.Log("Clicked Kitchentool: " + clickedKitchentool.name);
            smokeSparticles = GetComponentInChildren<ParticleSystem>();
            smokeSparticles.Play();
        }
        else if (clickedKitchentool.name == "Nori")
        {
            Debug.Log("Clicked Kitchentool: " + clickedKitchentool.name);
            smokeSparticles = GetComponentInChildren<ParticleSystem>();
            smokeSparticles.Play();
        }
        else if (clickedKitchentool.name == "Makisu")
        {
            Debug.Log("Clicked Kitchentool: " + clickedKitchentool.name);
            smokeSparticles = GetComponentInChildren<ParticleSystem>();
            smokeSparticles.Play();
        }
        else if (clickedKitchentool.name == "Reiskocher")
        {
            Debug.Log("Clicked Kitchentool: " + clickedKitchentool.name);
            smokeSparticles = GetComponentInChildren<ParticleSystem>();
            smokeSparticles.Play();
        }
        else if (clickedKitchentool.name == "Fisch")
        {
            Debug.Log("Clicked Kitchentool: " + clickedKitchentool.name);
            smokeSparticles = GetComponentInChildren<ParticleSystem>();
            smokeSparticles.Play();
        }

        return clickedKitchentool;
    }

}
