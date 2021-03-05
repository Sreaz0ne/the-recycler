using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class UIButtonHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler 
{
    
    public UIControlManager ucm;
    
    private EventSystem eventSystem;

    // Use this for initialization
    void Start () {
        eventSystem = EventSystem.current;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        
        ucm.SetLastHoveredObject(gameObject);

        if ( Cursor.visible ) {
            eventSystem.SetSelectedGameObject(null);
            ucm.SetLastSelectedObject(gameObject);
        } 
    }

    public void OnPointerExit(PointerEventData eventData) {
        
    }
}