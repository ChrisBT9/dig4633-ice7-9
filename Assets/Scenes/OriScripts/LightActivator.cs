using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LightActivator : MonoBehaviour
{
    public Light targetLight;  // Reference to the Light that you want to toggle
    public string grabObjectTag = "LightActivatorObject";  // Tag for the object that will activate the light

    private XRGrabInteractable grabInteractable;

    private void Start()
    {
        // Ensure that the light starts off
        if (targetLight != null)
        {
            targetLight.enabled = false;  // Turn off the light initially
        }

        // Try to get the XR Grab Interactable component if not using events
        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.onSelectEntered.AddListener(OnObjectGrabbed);
        }
    }

    private void OnObjectGrabbed(XRBaseInteractor interactor)
    {
        // Check if the object grabbed has the correct tag
        if (gameObject.CompareTag(grabObjectTag))
        {
            // Toggle the light on
            if (targetLight != null)
            {
                targetLight.enabled = true;
            }
        }
    }

    private void OnDestroy()
    {
        // Clean up the event listener when the script is destroyed
        if (grabInteractable != null)
        {
            grabInteractable.onSelectEntered.RemoveListener(OnObjectGrabbed);
        }
    }
}