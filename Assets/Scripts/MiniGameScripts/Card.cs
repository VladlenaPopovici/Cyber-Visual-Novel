using UnityEngine;
using UnityEngine.UI;

namespace MiniGameScripts
{
    public class Card : MonoBehaviour
    {
        [SerializeField] private Image iconImage;

        public Sprite hiddenIcon;
        public Sprite showedIcon;

        public bool isSelected;

        public CardsController cardsController;

        public void OnCardClick()
        {
            cardsController.SetSelected(this);
        }

        public void SetIconSprite(Sprite sprite)
        {
            showedIcon = sprite;
        }

        public void Show()
        {
            iconImage.sprite = showedIcon;
            isSelected = true;
        }

        public void Hide()
        {
            iconImage.sprite = hiddenIcon;
            isSelected = false;
        }
    }
}
