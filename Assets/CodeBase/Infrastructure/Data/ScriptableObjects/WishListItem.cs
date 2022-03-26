using UnityEngine;

[CreateAssetMenu(menuName = "Game/Wish list/Wish item data", fileName = "Wish list item")]
public class WishListItem : ScriptableObject
{
    public string Title => _title;
    public Sprite Icone => _icone;
    
    [SerializeField] private string _title;
    [SerializeField] private Sprite _icone;
}
