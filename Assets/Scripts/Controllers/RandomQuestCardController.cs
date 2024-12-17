using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Controllers
{
    //second variant:
    public class RandomQuestCardController : ICardController
    {
        private HashSet<CardData> usedCards = new HashSet<CardData>();

        public List<CardData> GetRandomCardsWithUnique(Level level, CardBundleData[] cardBundles, out CardData uniqueCard)
        {
            var allCards = cardBundles.SelectMany(bundle => bundle.CardData).ToList();
            var unusedCards = allCards.Where(card => !usedCards.Contains(card)).ToList();

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

            var randomCards = myBundle?.CardData.OrderBy(card => Random.Range(0, int.MaxValue)).Take(count).ToList();

            if (randomCards == null || randomCards.Count < count)
            {
                randomCards = myBundle?.CardData.OrderBy(card => Random.Range(0, int.MaxValue)).Take(count).ToList();
            }

            if (randomCards != null && !randomCards.Contains(uniqueCard))
            {
                int randomIndex = Random.Range(0, randomCards.Count);
                randomCards[randomIndex] = uniqueCard;
            }

            return randomCards;
        }
    }
}
