using UnityEngine;
using UnityEngine.AI;

public class PickupAndHoldMultipleCharacters : MonoBehaviour
{
    public Transform holdPoint;               
    public GameObject character;            
    public float pickupRange = 2f;          
    public LayerMask pickupLayerMask;        
    public NavMeshAgent navMeshAgent;      
    public Color pickedUpColor = Color.green; 
    public Color defaultColor = Color.white;  

    private GameObject heldObject;           
    private Renderer objectRenderer;          
    private Renderer characterRenderer;       
    private bool isHoldingObject = false;    

    void Start()
    {
        characterRenderer = character.GetComponent<Renderer>();

        if (characterRenderer != null)
        {
            characterRenderer.material.color = defaultColor;
        }
        else
        {
            Debug.LogError("i");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))  
        {
            if (heldObject == null)
            {
                TryPickupObject();
            }
        }

        if (Input.GetMouseButtonDown(1))  
        {
            if (heldObject != null)
            {
                DropObject();
            }
        }

        if (isHoldingObject && heldObject != null)
        {
            heldObject.transform.position = holdPoint.position;
        }
    }

    void TryPickupObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, pickupRange, pickupLayerMask))
        {
            if (hit.collider.CompareTag("Pickupable"))
            {
                PickupObject(hit.collider.gameObject);
            }
        }
    }

    void PickupObject(GameObject objectToPickup)
    {
        if (objectToPickup != null)
        {
            heldObject = objectToPickup;
            objectRenderer = objectToPickup.GetComponent<Renderer>();  


            objectToPickup.GetComponent<Rigidbody>().isKinematic = true;  
            objectToPickup.transform.SetParent(holdPoint);                
            isHoldingObject = true;                                      

            ChangeColor(pickedUpColor);
        }
    }

    void DropObject()
    {
        if (heldObject != null)
        {
            heldObject.transform.SetParent(null);

            heldObject.GetComponent<Rigidbody>().isKinematic = false;

            ChangeColor(defaultColor);

            heldObject = null;
            objectRenderer = null;
            isHoldingObject = false;
        }
    }

    void ChangeColor(Color color)
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = color; 
        }

        if (characterRenderer != null)
        {
            characterRenderer.material.color = color; 
        }
    }
}
