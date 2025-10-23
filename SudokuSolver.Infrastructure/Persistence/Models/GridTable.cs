namespace SudokuSolver.Infrastructure.Persistence.Models;

public class GridTable
{
    public required int ColumnsInChunk { get; init; } = 3;
    public required int RowsInChunk { get; init; } = 3;
    
    public required int HorizontalChunk { get; init; } = 3;
    public required int VerticalChunk { get; init; } = 3;
    
    public int[,] Table { get; set; }  = new int[9, 9];

    /// <summary>
    /// Create default sudoku 3x3
    /// </summary>
    public GridTable()
    { }
    
    /// <summary>
    /// Create custom sudoku chunk size
    /// </summary>
    /// <param name="squareInChunk">Width and height in one chunk (WxH)</param>
    /// <param name="squareChunk">Count chunks (WxH)</param>
    public GridTable(int squareInChunk, int squareChunk)
    {
        ColumnsInChunk = squareInChunk;
        RowsInChunk = squareInChunk;
        HorizontalChunk = squareChunk;
        VerticalChunk = squareChunk;
        
        Table = new int[ColumnsInChunk * HorizontalChunk, RowsInChunk * VerticalChunk];
    }

    /// <summary>
    /// Create custom sudoku chunk size
    /// </summary>
    /// <param name="rowsInChunk"></param>
    /// <param name="columnsInChunk"></param>
    /// <param name="horizontalChunk"></param>
    /// <param name="verticalChunk"></param>
    public GridTable(int rowsInChunk, int columnsInChunk, int horizontalChunk, int verticalChunk)
    {
        ColumnsInChunk = columnsInChunk;
        RowsInChunk = rowsInChunk;
        HorizontalChunk = horizontalChunk;
        VerticalChunk = verticalChunk;
        
        Table = new int[ColumnsInChunk * HorizontalChunk, RowsInChunk * VerticalChunk];
    }

    public bool WriteValue(int column, int row, int value)
    {
        var valid = Validate(column, row, value);
        if (!valid) return false;
        Table[column, row] = value;
        return true;
    }

    private bool Validate(int column, int row, int value)
    {
        for (var rowIndex = 0; rowIndex < RowsInChunk; rowIndex++)
            if(Table[column, rowIndex] == value) return false;
        for (var columnIndex = 0; columnIndex < ColumnsInChunk; columnIndex++)
            if (Table[columnIndex, row] == value) return false;
        return true;
    }

}