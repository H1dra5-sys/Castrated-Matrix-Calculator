/******************************************
*  Создал Коновалов К.М.                  *
*  Вариант: нету                          *
*  Язык программирования: C#              *
*******************************************/

using System;

namespace MatrixCalculator {

  // Основной код матрицы
  class Matrix {
    public int[,] matrix, secondMatrix;
    public int rowsForFirstMatrix, columnsForFirstMatrix, rowsCount, columnsCount, rowsForSecondMatrix, columnsForSecondMatrix, copyColumns, copyRows, getCopyFirstMatrix, GetCopySecondMatrix, twoMatrix, firstNewMatrixForSumma, secondNewMatrixForSumma;

    // "Прототип"
    public int[,] CopyFirstMatrix() {
      int[,] copy = new int[rowsForFirstMatrix, columnsForFirstMatrix];

      for (copyRows = 0; copyRows < rowsForFirstMatrix; ++copyRows) {
        for (copyColumns = 0; copyColumns < columnsForFirstMatrix; ++copyColumns) {
          copy[copyRows, copyColumns] = matrix[copyRows, copyColumns];
        }
      }
      return copy;
    }

    // "Прототип"
    public int[,] CopySecondMatrix() {
      int[,] copy = new int[rowsForSecondMatrix, columnsForSecondMatrix];

      for (copyRows = 0; copyRows < rowsForSecondMatrix; ++copyRows) {
        for (copyColumns = 0; copyColumns < columnsForSecondMatrix; ++copyColumns) {
          copy[copyRows, copyColumns] = secondMatrix[copyRows, copyColumns];
        }
      }
      return copy;
    }

    // Конструктор с вводом с клавиатуры
    public Matrix() {
      Console.Write("Enter the number of rows for the first matrix: ");
      rowsForFirstMatrix = int.Parse(Console.ReadLine());

      Console.Write("Enter the number of columns for the first matrix: ");
      columnsForFirstMatrix = int.Parse(Console.ReadLine());

      // ПРОВЕРКА НА КВАДРАТНОСТЬ ПЕРВОЙ МАТРИЦЫ
      if (rowsForFirstMatrix != columnsForFirstMatrix) {
        throw new MatrixSizeException("First matrix must be square!");
      }
      Console.WriteLine();

      Console.Write("Enter the number of rows for the second matrix: ");
      rowsForSecondMatrix = int.Parse(Console.ReadLine());

      Console.Write("Enter the number of columns for the second matrix: ");
      columnsForSecondMatrix = int.Parse(Console.ReadLine());

      // ПРОВЕРКА НА КВАДРАТНОСТЬ ВТОРОЙ МАТРИЦЫ
      if (rowsForSecondMatrix != columnsForSecondMatrix) {
        throw new MatrixSizeException("Second matrix must be square!");
      }
      Console.WriteLine();

      matrix = new int[rowsForFirstMatrix, columnsForFirstMatrix];
      secondMatrix = new int[rowsForSecondMatrix, columnsForSecondMatrix];

      // Сначала весь ввод первой матрицы
      for (rowsCount = 0; rowsCount < rowsForFirstMatrix; ++rowsCount) {
        for (columnsCount = 0; columnsCount < columnsForFirstMatrix; ++columnsCount) {
          Console.Write($"Enter matrix[{rowsCount},{columnsCount}]: ");
          matrix[rowsCount, columnsCount] = int.Parse(Console.ReadLine());
        }
      }

      // Теперь весь ввод второй матрицы
      for (rowsCount = 0; rowsCount < rowsForSecondMatrix; ++rowsCount) {
        for (columnsCount = 0; columnsCount < columnsForSecondMatrix; ++columnsCount) {
          Console.Write($"Enter second matrix[{rowsCount},{columnsCount}]: ");
          secondMatrix[rowsCount, columnsCount] = int.Parse(Console.ReadLine());
        }
      }

      // Потом весь вывод первой матрицы
      Console.WriteLine("\nFirst matrix:");
      for (rowsCount = 0; rowsCount < rowsForFirstMatrix; ++rowsCount) {
        for (columnsCount = 0; columnsCount < columnsForFirstMatrix; ++columnsCount) {
          Console.Write(matrix[rowsCount, columnsCount] + " ");
        }
        Console.WriteLine();
      }

      // Потом весь вывод второй матрицы
      Console.WriteLine("\nSecond matrix:");
      for (rowsCount = 0; rowsCount < rowsForSecondMatrix; ++rowsCount) {
        for (columnsCount = 0; columnsCount < columnsForSecondMatrix; ++columnsCount) {
          Console.Write(secondMatrix[rowsCount, columnsCount] + " ");
        }
        Console.WriteLine();
      }
    }

    // Нахождения Hash-кода
    public override int GetHashCode() {
      return HashCode.Combine(matrix, secondMatrix);
    }

    // Вывод в строку
    public override string ToString() {
      return this.GetType().ToString();
    }
  }

  //Класс Исключения
  public class MatrixSizeException : Exception {
    public MatrixSizeException(string message) : base(message) {
    }
  }

  // Класс операций над матрицами
  // Класс сложения матриц
  public class PlusMatrix {
    public int rowsForFirstMatrix, columnsForFirstMatrix, first, second;
    public static int rowsForCopy, columnsForCopy, plusRows, plusColumns;
    public int[,] SumMatrix;

    // Конструктор
    public PlusMatrix(int rowsForFirstMatrix, int columnsForFirstMatrix) {
      this.rowsForFirstMatrix = rowsForFirstMatrix;
      this.columnsForFirstMatrix = columnsForFirstMatrix;
      this.SumMatrix = new int[rowsForFirstMatrix, columnsForFirstMatrix];
    }

    // Метод для заполнения из копии
    public void FillFromCopy(int[,] copy) {
      for (int rowsForCopy = 0; rowsForCopy < rowsForFirstMatrix; ++rowsForCopy) {
        for (int columnsForCopy = 0; columnsForCopy < columnsForFirstMatrix; ++columnsForCopy) {
          SumMatrix[rowsForCopy, columnsForCopy] = copy[rowsForCopy, columnsForCopy];
        }
      }
    }

    // Перегрузка +
    public static PlusMatrix operator +(PlusMatrix first, PlusMatrix second) {
      PlusMatrix result = new PlusMatrix(first.rowsForFirstMatrix, first.columnsForFirstMatrix);

      for (plusRows = 0; plusRows < first.rowsForFirstMatrix; ++plusRows) {
        for (plusColumns = 0; plusColumns < first.columnsForFirstMatrix; ++plusColumns) {
          result.SumMatrix[plusRows, plusColumns] = first.SumMatrix[plusRows, plusColumns] + second.SumMatrix[plusRows, plusColumns];
        }
      }
      return result;
    }
  }

  class MainProgramm {
    public static int plusColumns, plusRows;
    static void Main() {
      try {
        // Ввод матриц
        Matrix twoMatrix = new Matrix();

        // Копии
        int[,] firstCopy = twoMatrix.CopyFirstMatrix();
        int[,] secondCopy = twoMatrix.CopySecondMatrix();

        // Создаем PlusMatrix для сложения
        PlusMatrix firstNewMatrixForSumma = new PlusMatrix(twoMatrix.rowsForFirstMatrix, twoMatrix.columnsForFirstMatrix);
        PlusMatrix secondNewMatrixForSumma = new PlusMatrix(twoMatrix.rowsForSecondMatrix, twoMatrix.columnsForSecondMatrix);

        // Заполняем их из копий
        firstNewMatrixForSumma.FillFromCopy(firstCopy);
        secondNewMatrixForSumma.FillFromCopy(secondCopy);

        // Проверяем размеры и складываем
        if (twoMatrix.rowsForFirstMatrix == twoMatrix.rowsForSecondMatrix && twoMatrix.columnsForFirstMatrix == twoMatrix.columnsForSecondMatrix) {
          PlusMatrix result = firstNewMatrixForSumma + secondNewMatrixForSumma;

          // ВЫВОД ВНУТРИ IF!
          Console.WriteLine("\nSum Result:");
          for (plusRows = 0; plusRows < result.rowsForFirstMatrix; ++plusRows) {
            for (plusColumns = 0; plusColumns < result.columnsForFirstMatrix; ++plusColumns) {
              Console.Write(result.SumMatrix[plusRows, plusColumns] + " ");
            }
            Console.WriteLine();
          }
        } else {
          throw new MatrixSizeException("Matrices of different sizes");
        }

        Console.WriteLine($"\nHash Code: {twoMatrix.GetHashCode()}");
        Console.WriteLine($"\n{twoMatrix.ToString()}");

      } catch (MatrixSizeException ex) {
        Console.WriteLine($"ERROR: {ex.Message}");
      } catch (Exception ex) {
        Console.WriteLine($"ERROR: {ex.Message}");
      }
    }
  }
}
