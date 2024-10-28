using UnityEngine;

public class MoveObjectsForward : MonoBehaviour
{
    [SerializeField]
    GameObject[] objectsToMove; // Array to store all objects that will move forward

    [SerializeField]
    float moveSpeed = 5f;       // Speed at which the objects will move forward

    void Update()
    {
        // Loop through each object in the objectsToMove array
        foreach (GameObject obj in objectsToMove)
        {
            if (obj != null)
            {
                // Move each object forward in its local space
                obj.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
        }
    }
}
