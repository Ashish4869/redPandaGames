using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Drag and drop characters on to the screen
/// </summary>
public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    #region Variables
    GameObject _cardCopy;
    RectTransform _cardRectTransform;
    Image _cardImage;
    [SerializeField] Canvas _canvas;
    [SerializeField] CharacterData _dataOfCharacterToSpawn;
    #endregion

    #region Monobehaviour Callbacks
    private void Awake()
    {
        _cardCopy = transform.Find(this.name + "Card").gameObject;
        _cardRectTransform = _cardCopy.GetComponent<RectTransform>();
        _cardImage = _cardCopy.GetComponent<Image>();

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        _cardCopy.SetActive(true);
    }

    public void OnDrag(PointerEventData eventData) 
    {
        _cardRectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _cardImage.color = new Color(_cardImage.color.r, _cardImage.color.g, _cardImage.color.b, 0.5f);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector3 pos = InputManager.Instance.GetMapPosition(); 
        _cardRectTransform.anchoredPosition = Vector3.zero;
        _cardImage.color = new Color(_cardImage.color.r, _cardImage.color.g, _cardImage.color.b, 1f);
        _cardCopy.SetActive(false);
        GameManager.Instance.SpawnCharacter(_dataOfCharacterToSpawn,pos);
    }
    #endregion
}
