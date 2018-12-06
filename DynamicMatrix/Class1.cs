using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class DynamicMatrix<T>
{
    private List<List<T>> matrix;
    public int Count { get { return lineCount * columnCount; } }

    private int lineCount = 0, columnCount = 0;

    public T this[int i, int j]
    {
        get { return matrix[i][j]; }
        set { matrix[i][j] = value; }
    }

    public List<T> this[int i]
    {
        get { return matrix[i]; }
        set
        {
            if (lineCount != value.Count)
                throw new Exception("Unavailable length of argument");
            matrix[i] = value;
        }
    }

    public DynamicMatrix(int i, int j)
    {
        if ((i <= 0) || (j <= 0))
            throw new Exception("Unavailable size of matrix");
        matrix = new List<List<T>>(i);
        for (int k1 = 0; k1 < i; k1++)
        {
            matrix.Add(new List<T>());
            for (int k2 = 0; k2 < j; k2++)
                matrix[k1].Add(default(T));
        }
        lineCount = i;
        columnCount = j;
    }

    public void AddRow(params T[] line)
    {
        this.InsertRow(lineCount, line);
    }

    public void AddColumn(params T[] col)
    {
        this.InsertCol(columnCount, col);
    }

    public void InsertRow(int index, params T[] line)
    {
        if ((index < 0) || (index > lineCount))
            throw new Exception("Unavailable index");
        matrix.Insert(index, new List<T>());
        for (int i = 0; i < line.Length; i++)
            matrix[index].Add(line[i]);
        if (line.Length < columnCount)
            for (int i = line.Length; i < columnCount; i++)
                matrix[index].Add(default(T));
        else if (line.Length > columnCount)
        {
            for (int i = 0; i <= lineCount; i++)
                if (i != index)
                    for (int j = columnCount; j < line.Length; j++)
                        matrix[i].Add(default(T));
            columnCount += (line.Length - columnCount);
        }
        lineCount++;
    }

    public void InsertCol(int index, params T[] col)
    {
        if ((index < 0) || (index > columnCount))
            throw new Exception("Unavailable index");
        if (lineCount == col.Length)
            for (int i = 0; i < col.Length; i++)
                matrix[i].Insert(index, col[i]);
        else if (lineCount > col.Length)
        {
            for (int i = 0; i < col.Length; i++)
                matrix[i].Insert(index, col[i]);
            for (int i = col.Length; i < lineCount; i++)
                matrix[i].Insert(index, default(T));
        }
        else
        {
            for (int i = 0; i < lineCount; i++)
                matrix[i].Insert(index, col[i]);
            for (int i = lineCount; i < col.Length; i++)
            {
                matrix.Add(new List<T>());
                lineCount++;
                for (int j = 0; j < columnCount; j++)
                    matrix[i].Add(default(T));
                matrix[i].Insert(index, col[i]);
            }
        }
        columnCount++;

    }

    public int GetLength(int i)
    {
        if (i == 0)
            return lineCount;
        else if (i == 1)
            return columnCount;
        else
            return -1;
    }

    public void RemoveLine(int ind)
    {
        if (ind < 0 || ind >= lineCount)
            throw new Exception("Unavailable index");
        matrix.RemoveAt(ind);
        lineCount--;
    }

    public void RemoveColumn(int ind)
    {
        if (ind < 0 || ind >= columnCount)
            throw new Exception("Unavailable index");
        for (int i = 0; i < lineCount; i++)         
            matrix[i].RemoveAt(ind); ;
        columnCount--;
    }

    public override String ToString()
    {
        String[] s = new String[lineCount];
        for (int i = 0; i < lineCount; i++)
            s[i] = String.Join(" ", matrix[i]);
        return String.Join("\n", s);       
    }
}

