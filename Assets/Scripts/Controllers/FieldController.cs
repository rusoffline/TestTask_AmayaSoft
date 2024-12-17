using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Controllers
{
    public class FieldController : MonoBehaviour, IFieldController
    {
        [SerializeField] private float cellSpacing = 2;
        [SerializeField] private CellPool cellPool;

        private List<Cell> cells = new List<Cell>();

        public void CreateField(List<CardData> cards, Level level, UnityAction<Cell> onClick)
        {
            ClearField();

            float xOffset = (level.Col * cellSpacing - cellSpacing) / 2f;
            float yOffset = (level.Row * cellSpacing - cellSpacing) / 2f;

            for (int row = 0; row < level.Row; row++)
            {
                for (int col = 0; col < level.Col; col++)
                {
                    Cell cell = cellPool.GetCell();

                    float xPos = col * cellSpacing - xOffset;
                    float yPos = -row * cellSpacing + yOffset;
                    cell.transform.localPosition = new Vector3(xPos, yPos, 0);

                    cells.Add(cell);
                }
            }

            var cardsCount = level.Row * level.Col;
            for (int i = 0; i < cardsCount; i++)
            {
                cells[i].Initialize(cards[i], onClick);
            }
        }

        public void ClearField()
        {
            foreach (var cell in cells)
            {
                cellPool.ReturnCell(cell);
            }
            cells.Clear();
        }

        public void AnimateFieldCells(float duration)
        {
            if (cells != null && cells.Count > 0)
            {
                foreach (var cell in cells)
                {
                    cell.PlayeApperEffect(duration);
                }
            }
        }

        public void LockCells(bool isLocked)
        {
            if (cells != null && cells.Count > 0)
            {
                foreach (var cell in cells)
                {
                    cell.SetCellLocked(isLocked);
                }
            }
        }
    }
}
