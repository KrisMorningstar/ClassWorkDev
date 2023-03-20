using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/* Script created by Kris Tidey for AT1 Testing  
 *
 *
 *
 */

public class CarButton : MonoBehaviour
{
    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private GraphicRaycaster _graphicRaycaster;
    private PointerEventData _pointerEventData;

    public delegate void ChangeAcceleration(float _acceleration);
    public static ChangeAcceleration changeAccelerationEvent;

    [SerializeField] float accelerationRate; 
    
    private Image buttonSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) { MouseInteraction(); }
    }

    private void MouseInteraction()
    {
        _pointerEventData = new PointerEventData(_eventSystem);

        _pointerEventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();

        _graphicRaycaster.Raycast(_pointerEventData, results);

        foreach(RaycastResult result in results)
        {
            Image _buttonSprite;
            if(result.gameObject.tag == "FrontButt")
            {
                buttonSprite = GetComponent<Image>();
                changeAccelerationEvent(accelerationRate);
                Debug.Log("Frutt");
                buttonSprite.color = Color.green;
            }

            else if(result.gameObject.tag == "BackButt")
            {
                changeAccelerationEvent(-accelerationRate);
            }
            //else { buttonSprite.color = Color.black; }
        }
    }
}
