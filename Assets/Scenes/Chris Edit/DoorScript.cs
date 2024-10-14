using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // This method will be called when the door's collider detects a collision
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object colliding with the door has the "PickUp" tag (or another identifier)
        if (other.CompareTag("PickUp"))
        {
            // Option 1: Destroy the door
            Destroy(gameObject);

            // Option 2: Make the door disappear (disable its renderer and collider)
            // gameObject.SetActive(false);
        }
    }
}
