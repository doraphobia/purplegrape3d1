using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject selectionIndicatorPrefab; //  Selection marker prefab 
    private GameObject currentSelection = null;
    private GameObject currentSelectionMarker = null;
    private CameraControl cameraControl;

    void Start()
    {
        cameraControl = FindObjectOfType<CameraControl>();
        if (cameraControl == null)
        {
            Debug.LogError("y.");
        }
    }

    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit,Mathf.Infinity, Physics.DefaultRaycastLayers,QueryTriggerInteraction.Collide))
            {
                GameObject selectedObject = hit.transform.gameObject;
                Debug.Log("hit"+ selectedObject.name);
                if (selectedObject.CompareTag("Selectable"))
                {

                    // Deselect previous selection
                    if (currentSelection != null && currentSelectionMarker != null)
                    {
                        Destroy(currentSelectionMarker); // 把上一个毁掉
                    }

                    // 选择新角色
                    currentSelection = selectedObject;
                    Debug.Log(currentSelection);

                    // Create the selection marker
                    if (selectionIndicatorPrefab != null)
                    {
                        Vector3 markerPosition = selectedObject.transform.position + new Vector3(0, 2.0f, 0);
                        currentSelectionMarker = Instantiate(selectionIndicatorPrefab, markerPosition, Quaternion.identity);
                        currentSelectionMarker.transform.SetParent(selectedObject.transform);
                    }
                    else
                    {
                        Debug.LogError("9.");
                    }

                    if (cameraControl != null)
                    {
                        cameraControl.SetTarget(selectedObject.transform);
                    }
                    else
                    {
                        Debug.LogError("u");
                    }
                }
                else
                {

                    if (currentSelection != null && currentSelectionMarker != null)
                    {
                        Destroy(currentSelectionMarker);
                        currentSelection = null; // 取消选择

                        if (cameraControl != null)
                        {
                            cameraControl.SetTarget(null);
                        }
                    }
                }
            }
            else
            {
                Debug.LogWarning("??.");
            }
        }
    }

    public GameObject GetCurrentSelection()
    {
        return currentSelection;
    }
}
