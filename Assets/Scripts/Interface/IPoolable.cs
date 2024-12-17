public interface IPoolable
{
    Cell GetCell();
    void ReturnCell(Cell cell);
}
