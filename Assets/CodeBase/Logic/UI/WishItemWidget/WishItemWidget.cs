using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Logic.UI.WishItemWidget
{
    [RequireComponent(typeof(Image))]
    public class WishItemWidget : MonoBehaviour
    {
        public RectTransform OwnerRectTransform => _ownerRectTransform;
        
        [SerializeField] private RectTransform _ownerRectTransform;
        [SerializeField] private Image _widgetImage;

        public void SetWidgetSprite(Sprite sprite)
        {
            _widgetImage.sprite = sprite;
        }

        public void Show()
        {
            SetEnableDisable(true);
        }

        public void Hide()
        {
            SetEnableDisable(false);
        }

        private void SetEnableDisable(bool isEnable)
        {
            gameObject.SetActive(isEnable);
        }
    }
}
