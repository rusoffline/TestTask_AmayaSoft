using System.Collections.Generic;

public interface ICellController
{
    void CreateGrid(List<CardData> cards, Level levelData, System.Action<Cell> onCellClick);
}