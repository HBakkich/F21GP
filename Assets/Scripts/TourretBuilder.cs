using UnityEngine;

public class TourretBuilder : MonoBehaviour
{
    [SerializeField]
    private GameObject placeableObjectPrefab;

    [SerializeField]
    private KeyCode newObjectKey = KeyCode.A;

    private GameObject currentplaceableObject;
    private float mousWheelRotation;

    public int turretsAvailable = 5;

    // Update is called once per frame
    void Update()
    {
        HandleNewObjectHotkey();
        if (currentplaceableObject != null)
        {
            MoveCurrentplaceableObjectToMouse();
            RotateFromMouseWheel();
            ReleaseIfClicked();
        }
    }

    private void ReleaseIfClicked()
    {
        if(Input.GetMouseButtonDown(0))
        {
            currentplaceableObject = null;
            turretsAvailable--;
        }
    }

    private void RotateFromMouseWheel()
    {
        mousWheelRotation += Input.mouseScrollDelta.y;
        currentplaceableObject.transform.Rotate(Vector3.up, mousWheelRotation * 10f);
    }


    private void MoveCurrentplaceableObjectToMouse()
    {        
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            currentplaceableObject.transform.position = hit.point;
        }
    }

    private void HandleNewObjectHotkey()
    {
            if (Input.GetKeyDown(newObjectKey))
            {
                if (turretsAvailable > 0)
                {  
                    if(currentplaceableObject == null)
                    {
                        currentplaceableObject = Instantiate(placeableObjectPrefab);
                    }
                    else
                    {
                        Destroy(currentplaceableObject);
                    }
                }
                else
                {
                    Debug.Log("Max number of tourrets reached! " + turretsAvailable);
                }
        }
    }
}
