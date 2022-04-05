using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class TurninSelectOption : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler// required interface when using the OnPointerEnter method.
{
    public Turnin t;
    public int optionNum;
    public Image option;
    bool selected = false;
    private Color optionUnselected = Color.white;
    private Color optionSelected = new Color(226.0f / 255.0f, 255.0f / 255.0f, 221.0f / 255.0f, 1.0f); // E2FFDD

    public void unselect()
    {
        Debug.Log("Unselected");
        if (selected)
        {
            Debug.Log("Actually unselecting");
            selected = false;
            option.color = optionUnselected;
        } 
    }

    //Do this when the cursor enters the rect area of this selectable UI object.
    public void OnPointerEnter(PointerEventData eventData)
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!selected)
        {
            option.color = optionSelected;
            selected = true;
            t.selectQuest(this);
        }
        
    }
    public void OnPointerExit(PointerEventData eventData)
    {
    }
}
