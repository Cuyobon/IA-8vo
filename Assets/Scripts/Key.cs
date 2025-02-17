using UnityEngine;

public class KeyCollector : MonoBehaviour
{
    private bool hasKey = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            hasKey = true;
            Destroy(other.gameObject);
            Debug.Log("Llave recogida");
        }
        else if (other.CompareTag("Door") && hasKey)
        {
            Transform leftDoor = other.transform.Find("Lower door");
            Transform rightDoor = other.transform.Find("Upper door");

            if (leftDoor != null)
                Destroy(leftDoor.gameObject);
            if (rightDoor != null)
                Destroy(rightDoor.gameObject);

            Debug.Log("Puerta abierta");
        }
    }
}
