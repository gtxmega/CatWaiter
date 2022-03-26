using UnityEngine;

[CreateAssetMenu(menuName = "Game/Wish list/Wish item data", fileName = "Wish list item")]
public class WishListItem : ScriptableObject
{
    public string Title => _title;
    public Sprite Icone => _icone;
    public float TimePreparing => _timePreparing;
    public float Cost => _cost;
    
    
    [SerializeField] private string _title;
    [SerializeField] private Sprite _icone;
    [SerializeField] private float _cost;
    [SerializeField] private float _timePreparing;
}
