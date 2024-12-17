using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers
{
    public class CellPool : MonoBehaviour, IPoolable
    {
        [SerializeField]
        private Cell cellPrefab;
        private Stack<Cell> availableCells = new Stack<Cell>();
        private List<Cell> allCells = new List<Cell>();

        public Cell GetCell()
        {
            if (availableCells.Count > 0)
            {
                Cell cell = availableCells.Pop();
                cell.gameObject.SetActive(true);
                return cell;
            }
            else
            {
                Cell newCell = Instantiate(cellPrefab);
                allCells.Add(newCell);
                return newCell;
            }
        }

        public void ReturnCell(Cell cell)
        {
            cell.gameObject.SetActive(false); 
            availableCells.Push(cell);
        }
    }
}
