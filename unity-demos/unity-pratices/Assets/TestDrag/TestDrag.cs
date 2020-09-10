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
    public RectTransform itemRoot = null;
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
        var pos = new Vector2(0,0);
        var screenPos = new Vector2(eventData.position.x, eventData.position.y);
        var ok = RectTransformUtility.ScreenPointToLocalPointInRectangle(itemRoot,screenPos,Camera.main, out pos);
        print($"x={pos.x},y = {pos.y}");
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
        //transform.position = eventData.position;
        var screenPos = new Vector2(eventData.position.x, eventData.position.y);
        var ok = RectTransformUtility.ScreenPointToLocalPointInRectangle(itemRoot,screenPos,Camera.main, out var pos);
        print($"x={pos.x},y = {pos.y}");
        var rtrans = GetComponent<RectTransform>();
        rtrans.anchoredPosition = pos;


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
