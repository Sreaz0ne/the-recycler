using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIControlManager : MonoBehaviour
{   

    private Vector3 lastMouseCoordinate = Vector3.zero;
    private EventSystem eventSystem;
    private GameObject lastSelectedObject;
    private PointerEventData pointer;
    private GameObject lastHoveredObject;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        eventSystem = EventSystem.current;
        pointer = new PointerEventData(eventSystem);
        lastMouseCoordinate = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        if ( MainMenuManager.mainMenu || GameManager.gamePaused ) {
            
            if (eventSystem.currentSelectedGameObject != null)
                lastSelectedObject = eventSystem.currentSelectedGameObject;

            if ( !Cursor.visible ) 
                ExecuteEvents.Execute(lastHoveredObject, pointer, ExecuteEvents.pointerExitHandler);
            else {
                if (lastHoveredObject) {
                    ExecuteEvents.Execute(lastHoveredObject, pointer, ExecuteEvents.pointerEnterHandler);
                    lastHoveredObject = null;
                }
            }

            // First we find out how much it has moved, by comparing it with the stored coordinate.
            Vector3 mouseDelta = Input.mousePosition - lastMouseCoordinate;

            // if mouse moved
            if ( mouseDelta.x != 0 || mouseDelta.y != 0 ) {
                Cursor.visible = true;
                lastMouseCoordinate = Input.mousePosition;
                if (eventSystem.currentSelectedGameObject != null) 
                    eventSystem.SetSelectedGameObject(null);
            } else {
                Vector2 padMovement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

                if ( padMovement.x != 0 || padMovement.y != 0 ) {
                    Cursor.visible = false;
                    ExecuteEvents.Execute(lastSelectedObject, pointer, ExecuteEvents.pointerExitHandler);
                    if (eventSystem.currentSelectedGameObject == null) 
                        eventSystem.SetSelectedGameObject(lastSelectedObject);
                } 
                else
                {
                    if ( Input.GetButton("Horizontal") || Input.GetButton("Vertical") ) 
                    {
                        Cursor.visible = false;
                        ExecuteEvents.Execute(lastSelectedObject, pointer, ExecuteEvents.pointerExitHandler);
                        if (eventSystem.currentSelectedGameObject == null) 
                            eventSystem.SetSelectedGameObject(lastSelectedObject);
                    }
                }
            }
        } 
    }

    public void SetLastSelectedObject(GameObject gameObject) {
        lastSelectedObject = gameObject;
    }

    public void SetLastHoveredObject(GameObject gameObject) {
        lastHoveredObject = gameObject;
    }

    public void RefreshlastMouseCoordinate()
    {
        lastMouseCoordinate = Input.mousePosition;
    }
}
