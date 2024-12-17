using System.Collections.Generic;
using UnityEngine.Events;

public interface IFieldController
{
    void CreateField(List<CardData> cards, Level levelData, UnityAction<Cell> onCellClick);
    void ClearField();
    void AnimateFieldCells(float duration);
    void LockCells(bool isLocked);
}
