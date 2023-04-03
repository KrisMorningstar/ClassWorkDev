using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script by Kris Tidey | last modified 03/04/2023
 * Script will be attached to GridCell prefab object
 * Will contain methods for changing the colour when mouse goes over it and
 * automatically setting up neighbours
 */

public class GridCell : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    [SerializeField] Material greenMat;
    [SerializeField] Material blueMat;
    [SerializeField] Material redMat;

    public List<GridCell> neighbours = new List<GridCell>();
    public GridCell pathCell { get; private set; }
    private bool activeGridCell;

    [SerializeField] List<Vector3> neighbourDirections = new List<Vector3>();

    private void Awake()
    {
        activeGridCell = false;
        if(!TryGetComponent<MeshRenderer>(out meshRenderer))
        {
            Debug.Log("Yo Dude, no Mesh Renderer on this object");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer.material = greenMat;

        FindNeighbours();

        BreadthFirstSearch.breadthFirstSearchEvent += ClearPathCell;
        BreadthFirstSearch.clearColourFromCellsEvent += ResetColour;
    }

    // Update is called once per frame
    void Update()
    {
        if (activeGridCell)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Selected " + gameObject.name + " as destination");
                BreadthFirstSearch.setDestinationCellEvent(this);
            }
        }
    }

    private void FindNeighbours()
    {
        RaycastHit hit;
        GridCell gridCell;

        for(int i = 0; i < neighbourDirections.Count; i++)
        {
            if (Physics.Raycast(transform.position, neighbourDirections[i], out hit, 2f))
            {
                if(hit.collider.TryGetComponent<GridCell>(out gridCell))
                {
                    neighbours.Add(gridCell);
                }
            }
        }
    }

    private void ClearPathCell()
    {
        pathCell = null;
    }

    public void SetPathCell(GridCell _pathcell)
    {
        pathCell = _pathcell;
    }

    private void ResetColour()
    {
        meshRenderer.material = greenMat;
    }

    public void SetColour(int _choice)
    {
        switch (_choice)
        {
            case 0:
                meshRenderer.material = greenMat;
                break;
            case 1:
                meshRenderer.material = redMat;
                break;
            case 2:
                meshRenderer.material = blueMat;
                break;
        }

        /*if(_choice == 0)
        {
            meshRenderer.material = greenMat;
        }
        else if(_choice == 1)
        {
            meshRenderer.material = redMat;
        }
        else if(_choice == 2)
        {
            meshRenderer.material = blueMat;
        }*/
    }

    private void OnMouseEnter()
    {
        meshRenderer.material = blueMat;
        activeGridCell = true;
    }

    private void OnMouseExit()
    {
        meshRenderer.material = greenMat;
        activeGridCell = false;
    }

    private void OnDestroy()
    {
        BreadthFirstSearch.breadthFirstSearchEvent -= ClearPathCell;
        BreadthFirstSearch.clearColourFromCellsEvent -= ResetColour;
    }
}
