using System;
using System.Collections;
using System.Collections.Generic;
using Naninovel;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MiniGameScripts
{
    public class CardsController : MonoBehaviour
    {
        [SerializeField] private Card cardPrefab;
        [SerializeField] private Transform gridLayout;
        [SerializeField] private Sprite[] sprites;

        [SerializeField] private GameObject winScreen;
        
        private List<Sprite> spritePairs;
        private Card firstSelected;
        private Card secondSelected;

        private int matchCounts;
        
        private void Start()
        {
            PrepareSprites();
            CreateCards();
        }
        
        public async UniTask OnGameComplete()
        {
            while (!winScreen.activeSelf)
            {
                await UniTask.Yield();
            }
        }

        public void SetSelected(Card card)
        {
            if (!card.isSelected)
            {
                card.Show();

                if (firstSelected == null)
                {
                    firstSelected = card;
                    return;
                }

                if (secondSelected == null)
                {
                    secondSelected = card;
                    StartCoroutine(CheckMatching(firstSelected, secondSelected));
                    firstSelected = null;
                    secondSelected = null;
                }
            }
        }

        private IEnumerator CheckMatching(Card firstCard, Card secondCard)
        {
            yield return new WaitForSeconds(0.3f);
            if (firstCard.showedIcon == secondCard.showedIcon)
            {
                matchCounts++;
                if (matchCounts >= spritePairs.Count / 2)
                {
                    gridLayout.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    winScreen.SetActive(true);
                    yield return new WaitForSecondsRealtime(2f);
                }
            }
            else
            {
                firstCard.Hide();
                secondCard.Hide();
            }
        }

        private void PrepareSprites()
        {
            spritePairs = new List<Sprite>();

            for (int i = 0; i < sprites.Length; i++)
            {
                spritePairs.Add(sprites[i]);
                spritePairs.Add(sprites[i]);
            }
            
            ShuffleSprites(spritePairs);
        }

        private void CreateCards()
        {
            for (int i = 0; i < spritePairs.Count; i++)
            {
                Card card = Instantiate(cardPrefab, gridLayout);
                card.SetIconSprite(spritePairs[i]);
                card.cardsController = this;
            }
        }
        
        private void ShuffleSprites(List<Sprite> spriteList)
        {
            if (spriteList == null || spriteList.Count == 0)  return;

            for (int i = spriteList.Count - 1; i > 0; i--)
            {
                int j = Random.Range(0, i + 1);
                (spriteList[i], spriteList[j]) = (spriteList[j], spriteList[i]);
            }
            
        }
    }
}
