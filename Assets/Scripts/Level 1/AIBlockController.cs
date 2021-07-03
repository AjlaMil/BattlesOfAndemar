using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
[SelectionBase] // Gives priority to selecting the AI Block as a whole when clicking on it, rather than its children.
[RequireComponent(typeof(Waypoint))]

public class AIBlockController : MonoBehaviour
{

    Waypoint waypoint;

    void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        
        transform.position = new Vector3(
            waypoint.GetGridPosition().x * gridSize,
            0f,
            waypoint.GetGridPosition().y * gridSize
        );
    }
        
    private void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        // int gridSize = waypoint.GetGridSize();
        string blockCoordinateText = 
            waypoint.GetGridPosition().x + 
            "," + 
            waypoint.GetGridPosition().y;
        
        textMesh.text = blockCoordinateText;
        gameObject.name = "AI Block (" + blockCoordinateText + ")";
    }
}