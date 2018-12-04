using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class DynamicMatrix<T>
{
    public List<List<T>> Matrix { get; }
    public int Count { get { return lineCount * columnCount; } }

    private int lineCount = 0, columnCount = 0;

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

    public void AddRow(params T[] line)
    {
        Matrix.Add(new List<T>());
        for (int i = 0; i < line.Length; i++)
            Matrix[lineCount].Add(line[i]);
        if (line.Length < columnCount)       
            for (int i = line.Length; i < columnCount; i++)
                Matrix[lineCount].Add(line[i]);
        else if (line.Length > columnCount)
        {
            for (int i = 0; i < lineCount; i++)

        }
    }
    public void AddColumn(params T[] col) { }
    public void InsertRow(int numb, params T[] line) { }
    public int GetLength(int i)
    {
        if (i == 0)
            return lineCount;
        else if (i == 1)
            return columnCount;
        else
            return -1;
    }
}

