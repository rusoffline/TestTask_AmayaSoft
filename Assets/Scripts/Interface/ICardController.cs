using System.Collections.Generic;

public interface ICardController
{
    List<CardData> GetRandomCardsWithUnique(Level level, CardBundleData[] cardBundles, out CardData uniqueCard);
}