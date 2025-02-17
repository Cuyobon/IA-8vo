using System.Collections.Generic;
using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToMove; // Lista de objetos a mover
    [SerializeField] private Vector3 direction = Vector3.forward; // Dirección del movimiento
    [SerializeField] private float speed = 5f; // Velocidad de movimiento

    void Update()
    {
        MoveAllObjects();
    }

    private void MoveAllObjects()
    {
        foreach (GameObject obj in objectsToMove)
        {
            if (obj != null)
            {
                obj.transform.position += direction.normalized * speed * Time.deltaTime;
            }
        }
    }
}
