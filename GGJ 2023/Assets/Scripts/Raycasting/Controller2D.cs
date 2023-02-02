using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Controller2D : MonoBehaviour
{
    private BoxCollider2D collider;
    private RaycastOrigins raycastOrigins;
    
    const float skinWidth = .015f;

    //How many rays are being fired by default?
    public int horizontalRayCount = 4;
    public int verticalRayCount = 4;

    //How far apart are those rays?
    private float horizontalRaySpacing;
    private float verticalRaySpacing;
    
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        UpdateRaycastOrigins();
        CalculateRaySpacing();

        for (int i = 0; i < verticalRayCount; i++)
        {
            Debug.DrawRay(raycastOrigins.bottomLeft + Vector2.right * verticalRaySpacing * i, Vector2.up * -2,
                Color.red);
        }
    }
    
    void UpdateRaycastOrigins()
    {
        //Get the bounds of the collider
        Bounds bounds = collider.bounds;
        
        //Shrink to be inset by the skin width
        bounds.Expand(skinWidth * -2);

        raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
    }

    void CalculateRaySpacing()
    {
        Bounds bounds = collider.bounds;
        bounds.Expand(skinWidth * -2);

        //At least 2 rays are being fired in both directions
        horizontalRayCount = Mathf.Clamp(horizontalRayCount, 2, int.MaxValue);
        verticalRayCount = Mathf.Clamp(verticalRayCount, 2, int.MaxValue);

        horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
        verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
    }

    struct RaycastOrigins
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }
}
