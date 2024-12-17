using UnityEngine;

[System.Serializable]
public class Level
{
    [SerializeField]
    private int row;

    [SerializeField] 
    private int col;

    public int Row => row;
    public int Col => col;
}
