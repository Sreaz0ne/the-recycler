using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public Rigidbody2D rb; // Store reference to player's rigidbody
    public SpriteRenderer sr; // Store reference to player's sprite
    public RectTransform canvasUI;
    public RectTransform leftUIElement;
    public RectTransform rightUIElement;

    public float speed = 9.5f; // Floating point variable to store the player's movement speed.

    private float playerHalfWidth;
    private float playerHalfHeight;

    // Start is called before the first frame update
    void Start()
    {
        playerHalfWidth = sr.bounds.extents.x; //extents = size of width / 2
        playerHalfHeight = sr.bounds.extents.y; //extents = size of height / 2
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        direction.Normalize();

        // Get current position
        Vector2 position = transform.position;

        // Calculate new position
        position += direction * speed * Time.deltaTime;

        //
        // Restrict position to the camera's boundaries
        //

        // Vertical boundaries 
        if ( position.y + playerHalfHeight > Camera.main.orthographicSize ) {
            position.y = Camera.main.orthographicSize - playerHalfHeight;
        } else if ( position.y - playerHalfHeight < -Camera.main.orthographicSize ) {
            position.y = -Camera.main.orthographicSize + playerHalfHeight;
        }

        // Horizontal boundaries
        // First calculate the width of the UI element under which the player cannot be
        float widthFactor =  (float)Screen.width/ canvasUI.rect.width;
        float rightUIelementSize = ((float)Screen.width - (rightUIElement.position.x + Mathf.FloorToInt(rightUIElement.rect.width * widthFactor) / 2f)) + Mathf.FloorToInt(rightUIElement.rect.width * widthFactor);
        float leftUIelementSize = (leftUIElement.position.x - Mathf.FloorToInt(leftUIElement.rect.width * widthFactor) / 2f) + Mathf.FloorToInt(leftUIElement.rect.width * widthFactor);

        // Next calculate the orthographic width based on the screen ratio
        float screenWidth = ((float)Screen.width - (leftUIelementSize + rightUIelementSize));
        float screenRatio = screenWidth / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        if ( position.x + playerHalfWidth > widthOrtho ) {
            position.x = widthOrtho - playerHalfWidth;
        } else if ( position.x - playerHalfWidth < -widthOrtho ) {
            position.x = -widthOrtho + playerHalfWidth;
        }

        //
        // End of Restrict position to the camera's boundaries
        //

        // Apply new position
        transform.position = position;
    }
}
