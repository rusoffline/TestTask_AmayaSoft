using System.Collections.Generic;
using System.Linq;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Game.Controllers
{
    public class QuestCardController : ICardController
    {
        private List<CardData> usedCards = new List<CardData>();

        public List<CardData> GetRandomCardsWithUnique(Level level, CardBundleData[] cardBundles, out CardData uniqueCard)
        {
            /*
             * идея:
             * 1. объеденить все карточки
             * 2. исключить использованные карты
             * 3. получить случайную карточку из исключенного массива и добавить в список использованных карт
             * 4. получить список где хранится случайная карточка
             * 5. из полученного списка проверить наличие уникальной карты и если ее нет то заменить случайную карту
             * 6. перемешать полученный список 
             * 7. условие: если исключенный список не содержит элементов вернуть нул,
             * иначе вернуть списко случайных карт и вернуть уникальную карточку для вопропроса
             */
            var allCards = cardBundles.SelectMany(bundle => bundle.CardData).ToList();

            var unusedCards = allCards.Except(usedCards).ToList();

            if (unusedCards.Count == 0)
            {
                uniqueCard = null;
                return null;
            }

            uniqueCard = unusedCards[Random.Range(0, unusedCards.Count)];
            usedCards.Add(uniqueCard);

            var uCard = uniqueCard;
            var myBundle = cardBundles.FirstOrDefault(bundle => bundle.CardData.Contains(uCard));

            int count = level.Row * level.Col;

            var randomCards = myBundle.CardData.OrderBy(card => Random.Range(0, int.MaxValue)).Take(count).ToList();

            if (!randomCards.Contains(uCard))
            {
                randomCards[Random.Range(0, randomCards.Count)] = uCard;
            }

            return randomCards;
        }
    }
}
