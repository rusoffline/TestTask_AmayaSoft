using UnityEngine.Events;

public interface ILevelController
{
    void LoadLevel(int levelIndex);
    bool IsLastLevel(int levelIndex);
    void AddLevelCompletedListener(UnityAction subscribe);
    IFieldController FieldController { get; }
}
