using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class DynamicMatrix<T>
{
    public List<List<T>> Matrix { get; }
    public int Length { get { return lines * columns; } }
    private int lines = 0, columns = 0;

    public T this[int i, int j]
    {
        get { return Matrix[i][j]; }
        set { Matrix[i][j] = value; }
    }

    public List<T> this[int i]
    {
        get { return Matrix[i];  }
    }

    public DynamicMatrix(int i, int j)
    {
        Matrix = new List<List<T>>(i);
        for (int k1 = 0; k1 < i; k1++)
        {
            Matrix[i] = new List<T>();
            for (int k2 = 0; k2 < j; k2++)
                Matrix[i][j] = default(T);
        }
    }

    public void AddRow(params T[] line) { }
    public void AddColumn(params T[] col) { }
    public void InsertRow(int numb, params T[] line) { }
    public int GetLength(int i)
    {
        if (i == 0)
            return lines;
        else if (i == 1)
            return columns;
        else
            return -1;
    }
}

