using System.Collections;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    public Color firstColor = Color.white; // Initial color
    public Color secondColor = Color.red; // Final color
    public float transitionDuration = 1.0f; // Duration of each transition
    public Material material; // Material to change its color
    private bool isTransitioning = false; // Flag to check if transitioning is in progress
    private float transitionTimer = 0f; // Timer for the transition

    void Start()
    {
        //Renderer renderer = GetComponent<Renderer>();
        //if (renderer != null)
        //{
        //    material = renderer.material;
        //}
        //else
        //{
        //    Debug.LogError("No Renderer component found on the GameObject.");
        //    enabled = false;
        //}
       // StartTransition();
    }

    void Update()
    {
        if (isTransitioning)
        {
            TransitionColor();
        }
    }

    public void StartTransition()
    {
        if (!isTransitioning)
        {
            isTransitioning = true;
            transitionTimer = 0f;
        }
    }

    void TransitionColor()
    {
        transitionTimer += Time.deltaTime;
        float lerpFactor = Mathf.Clamp01(transitionTimer / transitionDuration);
        if (lerpFactor < 1.0f) // Lerp to the second color
        {
            material.color = Color.Lerp(firstColor, secondColor, lerpFactor);
        }
        else // Lerp back to the first color
        {
            lerpFactor = Mathf.Clamp01((transitionTimer - transitionDuration) / transitionDuration);
            material.color = Color.Lerp(secondColor, firstColor, lerpFactor);
            if (lerpFactor >= 1.0f) // Transition complete
            {
                isTransitioning = false;
            }
        }
    }

}
