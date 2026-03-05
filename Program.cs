using System;
﻿/******************************************
*  Создал Коновалов К.М.                  *
*  Вариант: нету                          *
*  Язык программирования: C#              *
*******************************************/

using System;

namespace MatrixCalculator {

  //Основной код матрицы
  class Matrix {
    public int[,] matrix, secondMatrix;
    public int rowsForFirstMatrix, columnsForFirstMatrix, rowsCount, columnsCount, rowsForSecondMatrix, columnsForSecondMatrix, copyColumns, copyRows, getCopyFirstMatrix, GetCopySecondMatrixбб, twoMatrix, firstNewMatrixForSumma, secondNewMatrixForSumma;

    //"Прототип"
    public int[,] CopyFirstMatrix() {
      int[,] copy = new int[rowsForFirstMatrix, columnsForFirstMatrix];

      for (int copyRows = 0; copyRows < rowsForFirstMatrix; ++copyRows) {
        for (int copyColumns = 0; copyColumns < columnsForFirstMatrix; ++copyColumns) {
          copy[copyRows, copyColumns] = matrix[copyRows, copyColumns];
        }
      }
      return copy;
    }

    //"Прототип"
    public int[,] CopySecondMatrix() {
      int[,] copy = new int[rowsForSecondMatrix, columnsForSecondMatrix];

      for (int copyRows = 0; copyRows < rowsForSecondMatrix; ++copyRows) {
        for (int copyColumns = 0; copyColumns < columnsForSecondMatrix; ++copyColumns)  // ИСПРАВЛЕНО
        {
          copy[copyRows, copyColumns] = secondMatrix[copyRows, copyColumns];
        }
      }
      return copy;
    }

    //Конструктор с вводом с клавиатуры
    public Matrix() {
      Console.Write("Enter the number of rowsForFirstMatrix for the first matrix: ");
      rowsForFirstMatrix = int.Parse(Console.ReadLine());

      Console.Write("Enter the number of columnsForFirstMatrix for the first matrix: ");
      columnsForFirstMatrix = int.Parse(Console.ReadLine());
      Console.WriteLine();

      Console.Write("Enter the number of rowsForFirstMatrix for the second matrix: ");
      rowsForSecondMatrix = int.Parse(Console.ReadLine());

      Console.Write("Enter the number of columnsForFirstMatrix for second matrix: ");
      columnsForSecondMatrix = int.Parse(Console.ReadLine());
      Console.WriteLine();

      matrix = new int[rowsForFirstMatrix, columnsForFirstMatrix];
      secondMatrix = new int[rowsForSecondMatrix, columnsForSecondMatrix];

      //Сначала весь ввод первой матрицы
      for (int rowsCount = 0; rowsCount < rowsForFirstMatrix; ++rowsCount) {
        for (int columnsCount = 0; columnsCount < columnsForFirstMatrix; ++columnsCount) {
          Console.Write($"Enter matrix[{rowsCount},{columnsCount}]: ");
          matrix[rowsCount, columnsCount] = int.Parse(Console.ReadLine());
        }
      }

      //Теперь весь ввод второй матрицы
      for (int rowsCount = 0; rowsCount < rowsForSecondMatrix; ++rowsCount) {
        for (int columnsCount = 0; columnsCount < columnsForSecondMatrix; ++columnsCount) {
          Console.Write($"Enter second matrix[{rowsCount},{columnsCount}]: ");
          secondMatrix[rowsCount, columnsCount] = int.Parse(Console.ReadLine());
        }
      }

      //Потом весь вывод первой матрицы
      Console.WriteLine("\nFirst matrix:");
      for (int rowsCount = 0; rowsCount < rowsForFirstMatrix; ++rowsCount) {
        for (int columnsCount = 0; columnsCount < columnsForFirstMatrix; ++columnsCount) {
          Console.Write(matrix[rowsCount, columnsCount] + " ");
        }
        Console.WriteLine();
      }

      //Потом весь вывод второй матрицы
      Console.WriteLine("\nSecond matrix:");
      for (int rowsCount = 0; rowsCount < rowsForSecondMatrix; ++rowsCount) {
        for (int columnsCount = 0; columnsCount < columnsForSecondMatrix; ++columnsCount) {
          Console.Write(secondMatrix[rowsCount, columnsCount] + " ");
        }
        Console.WriteLine();
      }
    }

    //Нахождения Hash-кода
    public override int GetHashCode() {
      return HashCode.Combine(matrix, secondMatrix);
    }

    //Вывод в строку
    public virtual string Tostring() {
      return this.GetType().ToString();
    }
  }
    //Класс Исключения
    public static class ExceptionFinder {
      public static void Exception(string error) {
        Console.WriteLine("An error has occurred. Please read the instructions carefully and restart the program; ERROR name is:" + error);
      }
    }

    // Класс операций над матрицами
    // Класс сложения матриц
    public class PlusMatrix {
      public int rowsForFirstMatrix, columnsForFirstMatrix, first, second, plusRows, plusColumns;
      public int[,] SumMatrix;

      // Конструктор
      public PlusMatrix(int rowsForFirstMatrix, int columnsForFirstMatrix) {
        this.rowsForFirstMatrix = rowsForFirstMatrix;
        this.columnsForFirstMatrix = columnsForFirstMatrix;
        this.SumMatrix = new int[rowsForFirstMatrix, columnsForFirstMatrix];
      }

      // Метод для заполнения из копии
      public void FillFromCopy(int[,] copy) {
        for (int i = 0; i < rowsForFirstMatrix; i++) {
          for (int j = 0; j < columnsForFirstMatrix; j++) {
            SumMatrix[i, j] = copy[i, j];
          }
        }
      }

      // Перегрузка +
      public static PlusMatrix operator +(PlusMatrix first, PlusMatrix second) {
        PlusMatrix result = new PlusMatrix(first.rowsForFirstMatrix, first.columnsForFirstMatrix);

        for (int plusRows = 0; plusRows < first.rowsForFirstMatrix; ++plusRows) {
          for (int plusColumns = 0; plusColumns < first.columnsForFirstMatrix; ++plusColumns) {
            result.SumMatrix[plusRows, plusColumns] = first.SumMatrix[plusRows, plusColumns] + second.SumMatrix[plusRows, plusColumns];
          }
        }
        return result;
      }
    }

    class MainProgramm {
      static void Main() {
  //Класс Исключения
  public class MatrixSizeException : Exception {
    public MatrixSizeException(string message) : base(message) {
    }
  }

  // Класс операций над матрицами
  // Класс сложения матриц
  public class PlusMatrix {
    public int rowsForFirstMatrix, columnsForFirstMatrix, first, second, plusRows, plusColumns;
    public int[,] SumMatrix;

    // Конструктор
    public PlusMatrix(int rowsForFirstMatrix, int columnsForFirstMatrix) {
      this.rowsForFirstMatrix = rowsForFirstMatrix;
      this.columnsForFirstMatrix = columnsForFirstMatrix;
      this.SumMatrix = new int[rowsForFirstMatrix, columnsForFirstMatrix];
    }

    // Метод для заполнения из копии
    public void FillFromCopy(int[,] copy) {
      for (int i = 0; i < rowsForFirstMatrix; i++) {
        for (int j = 0; j < columnsForFirstMatrix; j++) {
          SumMatrix[i, j] = copy[i, j];
        }
      }
    }

    // Перегрузка +
    public static PlusMatrix operator +(PlusMatrix first, PlusMatrix second) {
      PlusMatrix result = new PlusMatrix(first.rowsForFirstMatrix, first.columnsForFirstMatrix);

      for (int plusRows = 0; plusRows < first.rowsForFirstMatrix; ++plusRows) {
        for (int plusColumns = 0; plusColumns < first.columnsForFirstMatrix; ++plusColumns) {
          result.SumMatrix[plusRows, plusColumns] = first.SumMatrix[plusRows, plusColumns] + second.SumMatrix[plusRows, plusColumns];
        }
      }
      return result;
    }
  }

  class MainProgramm {
    static void Main() {
      try {
        //Ввод матриц
        Matrix twoMatrix = new Matrix();

        //ДЕЛАЕМ ГЛУБОКИЕ КОПИИ
        int[,] firstCopy = twoMatrix.CopyFirstMatrix();
        int[,] secondCopy = twoMatrix.CopySecondMatrix();

        //Создаем PlusMatrix для сложения
        PlusMatrix firstNewMatrixForSumma = new PlusMatrix(twoMatrix.rowsForFirstMatrix, twoMatrix.columnsForFirstMatrix);
        PlusMatrix secondNewMatrixForSumma = new PlusMatrix(twoMatrix.rowsForSecondMatrix, twoMatrix.columnsForSecondMatrix);

        //Заполняем их из копий
        firstNewMatrixForSumma.FillFromCopy(firstCopy);
        secondNewMatrixForSumma.FillFromCopy(secondCopy);

        // 5. Проверяем размеры и складываем
        if (twoMatrix.rowsForFirstMatrix == twoMatrix.rowsForSecondMatrix && twoMatrix.columnsForFirstMatrix == twoMatrix.columnsForSecondMatrix) {
          PlusMatrix result = firstNewMatrixForSumma + secondNewMatrixForSumma;

          // ВЫВОД ВНУТРИ IF!
          Console.WriteLine("\nSum Result:");
          for (int plusRows = 0; plusRows < result.rowsForFirstMatrix; ++plusRows) {
            for (int plusColumns = 0; plusColumns < result.columnsForFirstMatrix; ++plusColumns) {
              Console.Write(result.SumMatrix[plusRows, plusColumns] + " ");
            }
            Console.WriteLine();
          }
        } else {
            ExceptionFinder.Exception("Matrices of different sizes");
            throw new MatrixSizeException("Matrices of different sizes");
        }

        Console.WriteLine($"\nHash Code: {twoMatrix.GetHashCode()}");
        Console.WriteLine($"\n{twoMatrix.Tostring()}");
      }
    }
}




      } 
      catch (MatrixSizeException ex) {  // Ловим НАШУ ошибку
        Console.WriteLine($"ERROR: {ex.Message}");
      }

      catch (Exception ex) {  // Ловим ВСЕ остальные ошибки
        Console.WriteLine($"ERROR: {ex.Message}");
      }
    }
  }
}
