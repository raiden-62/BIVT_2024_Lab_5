using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Program program = new Program();
        // int[] to_sort = new int[]{1, -1, 0, 1789, -123, 5, 6, 8, 2,5, 98, 1, 0, 0};
        // to_sort = InsertSort(to_sort, false);
        // for (int i = 0; i < to_sort.Length; i++){
        //     Console.Write(to_sort[i]);
        //     Console.Write(' ');
        // }
    }
    /*public void FindMaxIndex(int[,] matrix, out int row, out int column){
        row = 0;
        column = 0;

        for (int i = 0; i < matrix.GetLength(0); i++){
            for (int j = 0; j < matrix.GetLength(1); j++){
                if (matrix[i, j] > matrix[row, column]){
                    row = i;
                    column = j;
                }
            }
        }
        return;
    }*/
    public static int[] InsertSort(int[] array, bool DoSortAscending){
        for (int i = 0; i < array.Length; i++){
            int key = array[i];
            int j = i -1;

            while (j >= 0 && array[j] > key){
                array[j+1] = array[j];
                j--;
            }

            array[j+1] = key;
        }

        if (!DoSortAscending){//reverse descending
            int temp;
            for (int a = 0, b = array.Length-1; a<=b; a++, b--){
                temp = array[a];
                array[a] = array[b];
                array[b] = temp;
            }
        }

        return array;
    }
    #region Level 1
    public int Factorial(int n){
        if (n <= 1) return 1;
        return Factorial(n-1)*n;
    }

    public int Combinations(int n, int k){
        return Factorial(n)/(Factorial(k)*Factorial(n-k));
    }
    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here
        answer = Combinations(n, k);
        // end

        return answer;
    }

    public double GeronArea(double a, double b, double c){
        double p = (a+b+c)/2;

        return Math.Pow(p*(p-a)*(p-b)*(p-c), 0.5);
    }

    public bool TriangleExists(double a, double b, double c){
        if (a+b <= c || a+c <= b || b+c <= a){
            return false;
        }
        if (a <= 0 || b <= 0 || c <= 0){
            return false;
        }
        return true;
    }

    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        // code here

        // create and use GeronArea(a, b, c);
        if (!TriangleExists(first[0],first[1],first[2]) || !TriangleExists(second[0],second[1],second[2])){
            return -1;
        }

        double area1 = GeronArea(first[0],first[1],first[2]);
        double area2 = GeronArea(second[0],second[1],second[2]);
        if (area1 > area2){
            answer = 1;
        }
        else if (area2 > area1){
            answer = 2;
        }
        else{
            answer = 0;
        }

        // end

        // first = 1, second = 2, equal = 0, error = -1         -returning values
        return answer;
    }
    public double GetDistance(double v, double a, double t){
        //S = vt + at2/2
        return v*t + a*t*t/2;
    }
    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here

        if (GetDistance(v1, a1, time) > GetDistance(v2, a2, time)){
            answer = 1;
        }
        else if (GetDistance(v1, a1, time) < GetDistance(v2, a2, time)){
            answer = 2;
        }
        else{
            answer = 0;
        }

        // end

        // first = 1, second = 2, equal = 0
        return answer;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;

        // code here

        int time = 1;
        while (GetDistance(v1, a1, time) > GetDistance(v2, a2, time))
            time++;
        answer = time;
        // end

        return answer;
    }
    #endregion

    #region Level 2

    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here

        // end
    }


    public int FindMaxIndex(double[] array){
        int index = 0;
        for (int i = 0; i < array.Length; i++){
            if (array[i] > array[index]){
                index = i;
            }
        }
        return index;
    }
    public void Task_2_2(double[] A, double[] B)
    {
        // code here

        // only 1 array has to be changed!

        int i_max_A = FindMaxIndex(A), i_max_B = FindMaxIndex(B);
        double arif = 0, n = 0;

        if ((A.Length - i_max_A) > (B.Length - i_max_B)){ //change A
            for (int i = i_max_A + 1; i < A.Length; i++){
                arif += A[i];
                n++;
            }
            arif /= n;

            for (int i = 0; i < A.Length; i++){
                if (A[i] == A[i_max_A]) A[i] = arif;
            }
        } 
        else{
            for (int i = i_max_B + 1; i < B.Length; i++){
                arif += B[i];
                n++;
            }
            arif /= n;

            for (int i = 0; i < B.Length; i++){
                if (B[i] == B[i_max_B]) B[i] = arif;
            }
        }

        // end
    }

    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix);

        // end
    }


    

    public int FindDiagonalMaxIndex(int[,] matrix){
        int index = 0;
        for (int k = 0; k < matrix.GetLength(0); k++){
            if (matrix[k, k] > matrix[index, index]){
                index = k;
            }
        }
        return index;
    }
    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here
        int k_A = FindDiagonalMaxIndex(A), k_B = FindDiagonalMaxIndex(B);

        int temp;

        for(int k = 0; k < A.GetLength(0); k++){
            temp = A[k_A, k];
            A[k_A, k] = B[k, k_B];
            B[k, k_B] = temp;
        }

        // end
    }

    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);

        // end
    }


    public int[] DeleteElement(int[] array, int index){
        int[] temp = new int[array.Length-1];

        for (int i = 0, j = 0; i < array.Length; i++){
            if (i != index) temp[j++] = array[i];
        }
        return temp;
    }
    public void Task_2_6(ref int[] A, int[] B)
    {
        // code here

        // create and use FindMax(matrix, out row, out column); like in Task_2_1
        // create and use DeleteElement(array, index);

        // end
    }

    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);

        // end
    }


    public int[] SortArrayPart(int[] array, int startIndex){
        int[] temp = new int[array.Length - startIndex - 1];
        for (int i = startIndex+1, j = 0; i < array.Length; i++){
            temp[j++] = array[i];
        }

        temp = InsertSort(temp, true);
        
        for (int i = startIndex+1, j = 0; i < array.Length; i++){
            array[i] = temp[j++];
        }
        return array;
    }
    public int FindMaxIndex(int[] array){
        int index = 0;
        for (int i = 0; i < array.Length; i++){
            if (array[i] > array[index]){
                index = i;
            }
        }
        return index;
    }
    public void Task_2_8(int[] A, int[] B)
    {
        // code here

        A = SortArrayPart(A, FindMaxIndex(A));
        B = SortArrayPart(B, FindMaxIndex(B));

        // end
    }

    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = default(int[]);

        // code here

        // create and use SumPositiveElementsInColumns(matrix);

        // end

        return answer;
    }




    // public int[,] RemoveColumn(int[,] matrix, int columnIndex){
        
    // }
    public void Task_2_10(ref int[,] matrix)
    {
        // code here

        // create and use RemoveColumn(matrix, columnIndex);


        // end
    }

    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); from Task_2_1

        // end
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxColumnIndex(matrix);

        // end
    }

    public void Task_2_13(ref int[,] matrix)
    {
        // code here

        // create and use RemoveRow(matrix, rowIndex);

        // end
    }

    public void Task_2_14(int[,] matrix)
    {
        // code here

        // create and use SortRow(matrix, rowIndex);

        // end
    }

    public int Task_2_15(int[,] A, int[,] B, int[,] C)
    {
        int answer = 0;

        // code here

        // create and use GetAverageWithoutMinMax(matrix);

        // end

        // 1 - increasing   0 - no sequence   -1 - decreasing
        return answer;
    }

    public void Task_2_16(int[] A, int[] B)
    {
        // code here

        // create and use SortNegative(array);

        // end
    }

    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here

        // create and use SortRowsByMaxElement(matrix);

        // end
    }

    public void Task_2_18(int[,] A, int[,] B)
    {
        // code here

        // create and use SortDiagonal(matrix);

        // end
    }

    public void Task_2_19(ref int[,] matrix)
    {
        // code here

        // use RemoveRow(matrix, rowIndex); from 2_13

        // end
    }
    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        // code here

        // use RemoveColumn(matrix, columnIndex); from 2_10

        // end
    }

    public void Task_2_21(int[,] A, int[,] B, out int[] answerA, out int[] answerB)
    {
        answerA = null;
        answerB = null;

        // code here

        // create and use CreateArrayFromMins(matrix);

        // end
    }

    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = null;
        cols = null;

        // code here

        // create and use CountNegativeInRow(matrix, rowIndex);
        // create and use FindMaxNegativePerColumn(matrix);

        // end
    }

    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here

        // create and use MatrixValuesChange(matrix);

        // end
    }

    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        // create and use SwapColumnDiagonal(matrix, columnIndex);

        // end
    }

    public void Task_2_25(int[,] A, int[,] B, out int maxA, out int maxB)
    {
        maxA = 0;
        maxB = 0;

        // code here

        // create and use FindRowWithMaxNegativeCount(matrix);
        // in FindRowWithMaxNegativeCount create and use CountNegativeInRow(matrix, rowIndex); like in 2_22

        // end
    }

    public void Task_2_26(int[,] A, int[,] B)
    {
        // code here

        // create and use FindRowWithMaxNegativeCount(matrix); like in 2_25
        // in FindRowWithMaxNegativeCount use CountNegativeInRow(matrix, rowIndex); from 2_22

        // end
    }

    public void Task_2_27(int[,] A, int[,] B)
    {
        // code here

        // create and use FindRowMaxIndex(matrix, rowIndex, out columnIndex);
        // create and use ReplaceMaxElementOdd(matrix, row, column);
        // create and use ReplaceMaxElementEven(matrix, row, column);

        // end
    }

    public void Task_2_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here

        // create and use FindSequence(array, A, B); // 1 - increasing, 0 - no sequence,  -1 - decreasing
        // A and B - start and end indexes of elements from array for search

        // end
    }

    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a
        // A and B - start and end indexes of elements from array for search

        // end
    }

    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a or Task_2_28b
        // A and B - start and end indexes of elements from array for search

        // end
    }
    #endregion

    #region Level 3
    public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
    {
        // code here

        // create and use public delegate SumFunction(x) and public delegate YFunction(x)
        // create and use method GetSumAndY(sFunction, yFunction, a, b, h);
        // create and use 2 methods for both functions calculating at specific x

        // end
    }

    public void Task_3_2(int[,] matrix)
    {
        // SortRowStyle sortStyle = default(SortRowStyle); - uncomment me

        // code here

        // create and use public delegate SortRowStyle(matrix, rowIndex);
        // create and use methods SortAscending(matrix, rowIndex) and SortDescending(matrix, rowIndex)
        // change method in variable sortStyle in the loop here and use it for row sorting

        // end
    }

    public double Task_3_3(double[] array)
    {
        double answer = 0;
        // SwapDirection swapper = default(SwapDirection); - uncomment me

        // code here

        // create and use public delegate SwapDirection(array);
        // create and use methods SwapRight(array) and SwapLeft(array)
        // create and use method GetSum(array, start, h) that sum elements with a negative indexes
        // change method in variable swapper in the if/else and than use swapper(matrix)

        // end

        return answer;
    }

    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int answer = 0;

        // code here

        // create and use public delegate GetTriangle(matrix);
        // create and use methods GetUpperTriange(array) and GetLowerTriange(array)
        // create and use GetSum(GetTriangle, matrix)

        // end

        return answer;
    }

    public void Task_3_5(out int func1, out int func2)
    {
        func1 = 0;
        func2 = 0;

        // code here

        // use public delegate YFunction(x, a, b, h) from Task_3_1
        // create and use method CountSignFlips(YFunction, a, b, h);
        // create and use 2 methods for both functions

        // end
    }

    public void Task_3_6(int[,] matrix)
    {
        // code here

        // create and use public delegate FindElementDelegate(matrix);
        // use method FindDiagonalMaxIndex(matrix) like in Task_2_3;
        // create and use method FindFirstRowMaxIndex(matrix);
        // create and use method SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);

        // end
    }

    public void Task_3_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use public delegate CountPositive(matrix, index);
        // use CountRowPositive(matrix, rowIndex) from Task_2_7
        // use CountColumnPositive(matrix, colIndex) from Task_2_7
        // create and use method InsertColumn(matrixB, CountRow, matrixC, CountColumn);

        // end
    }

    public void Task_3_10(ref int[,] matrix)
    {
        // FindIndex searchArea = default(FindIndex); - uncomment me

        // code here

        // create and use public delegate FindIndex(matrix);
        // create and use method FindMaxBelowDiagonalIndex(matrix);
        // create and use method FindMinAboveDiagonalIndex(matrix);
        // use RemoveColumn(matrix, columnIndex) from Task_2_10
        // create and use method RemoveColumns(matrix, findMaxBelowDiagonalIndex, findMinAboveDiagonalIndex)

        // end
    }

    public void Task_3_13(ref int[,] matrix)
    {
        // code here

        // use public delegate FindElementDelegate(matrix) from Task_3_6
        // create and use method RemoveRows(matrix, findMax, findMin)

        // end
    }

    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {

        rows = null;
        cols = null;

        // code here

        // create and use public delegate GetNegativeArray(matrix);
        // use GetNegativeCountPerRow(matrix) from Task_2_22
        // use GetMaxNegativePerColumn(matrix) from Task_2_22
        // create and use method FindNegatives(matrix, searcherRows, searcherCols, out rows, out cols);

        // end
    }

    public void Task_3_27(int[,] A, int[,] B)
    {
        // code here

        // create and use public delegate ReplaceMaxElement(matrix, rowIndex, max);
        // use ReplaceMaxElementOdd(matrix) from Task_2_27
        // use ReplaceMaxElementEven(matrix) from Task_2_27
        // create and use method EvenOddRowsTransform(matrix, replaceMaxElementOdd, replaceMaxElementEven);

        // end
    }

    public void Task_3_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here

        // create public delegate IsSequence(array, left, right);
        // create and use method FindIncreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method FindDecreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method DefineSequence(array, findIncreasingSequence, findDecreasingSequence);

        // end
    }

    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
    {
        // code here

        // create public delegate IsSequence(array, left, right);
        // use method FindIncreasingSequence(array, A, B); from Task_3_28a
        // use method FindDecreasingSequence(array, A, B); from Task_3_28a
        // create and use method FindLongestSequence(array, sequence);

        // end
    }
    #endregion
    #region bonus part
    public double[,] Task_4(double[,] matrix, int index)
    {
        // MatrixConverter[] mc = new MatrixConverter[4]; - uncomment me

        // code here

        // create public delegate MatrixConverter(matrix);
        // create and use method ToUpperTriangular(matrix);
        // create and use method ToLowerTriangular(matrix);
        // create and use method ToLeftDiagonal(matrix); - start from the left top angle
        // create and use method ToRightDiagonal(matrix); - start from the right bottom angle

        // end

        return matrix;
    }
    #endregion
}
