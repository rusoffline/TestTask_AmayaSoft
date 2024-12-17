using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CellController : MonoBehaviour
{
    [SerializeField]
    private Cell cellPrefab;
    [SerializeField]
    private float cellSpacing = 2;
    private List<Cell> cells = new List<Cell>();

    public void CreateGrid(List<CardData> cards, Level level, UnityAction<Cell> onClick)
    {
        Clear();

        float xOffset = (level.Col * cellSpacing - cellSpacing) / 2f;
        float yOffset = (level.Row * cellSpacing - cellSpacing) / 2f;

        for (int row = 0; row < level.Row; row++)
        {
            for (int col = 0; col < level.Col; col++)
            {
                Cell cell = Instantiate(cellPrefab, transform);

                float xPos = col * cellSpacing - xOffset;
                float yPos = -row * cellSpacing + yOffset;
                cell.transform.localPosition = new Vector3(xPos, yPos, 0);

                cells.Add(cell);
            }
        }

        Debug.Log($"cells.count = {cells.Count}, cards.count = {cards.Count}");
        var cardsCount = level.Row * level.Col;
        for (int i = 0; i <= cardsCount - 1; i++)
        {
            cells[i].Initialize(cards[i], onClick);
        }
    }
    
    private void Clear()
    {
        foreach(var cell in cells)
        {
            Destroy(cell.gameObject);
        }
        cells.Clear();
    }

    public void PlayeApperEffect(float duration)
    {
        if(cells!=null && cells.Count > 0)
        {
            foreach(var cell in cells)
            {
                cell.PlayeApperEffect(duration);
            }
        }
    }
}