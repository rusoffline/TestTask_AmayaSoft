using UnityEngine;

[CreateAssetMenu(fileName = "New GameData", menuName = "Game Data")]
public class GameData : ScriptableObject
{
    [SerializeField]
    private CardBundleData[] cards;
    [SerializeField]
    private Level[] level;

    public CardBundleData[] Cards => cards;
    public Level[] Level => level;
}
