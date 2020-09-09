using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestDrag : MonoBehaviour, 
    IPointerClickHandler, 
    IPointerEnterHandler, 
    IPointerExitHandler,
    IDragHandler,
    IBeginDragHandler,
    IEndDragHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        print($"OnPointerClick{eventData.position.x} {eventData.position.y}");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        print($"OnPointerEnter{eventData.position.x} {eventData.position.y}");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print($"OnPointerExit{eventData.position.x} {eventData.position.y}");
    }

    public void OnDrag(PointerEventData eventData)
    {
        print($"OnDrag{eventData.position.x} {eventData.position.y}");
        transform.position = eventData.position;
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        print($"OnBeginDrag{eventData.position.x} {eventData.position.y}");
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        print($"OnEndDrag{eventData.position.x} {eventData.position.y}");
    }
}
