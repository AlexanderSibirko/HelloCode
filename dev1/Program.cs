// Задача
// ---
// Cформировать случайным образом целочисленный массив A из натуральных двузначных чисел. 
// Создать на его основе масив B, отбрасывая те, которые 
// (1) - нарушают порядок возрастания
// (2) - больше среднего арифметического элементов A
// (3) - чётные

//методы общего назначения
//случайное число из отрезка [minValue; maxValue]
int GetRandomMaxIn(int minValue, int maxValue)
{
    int number;
    return number = new Random().Next(minValue, maxValue+1);
}
//вывод в консоль массива в виде одной строки
void showIntArrayInLine(int[] array){
int index = 0;
while (index < array.Length)
    {
        Console.Write(array[index] + " ");
        index++;
    }
    Console.WriteLine();
}

//методы под задачу
//Сздание массива А "заполненный числами из отрезка [minValue; maxValue]". Парметры (количество элементов, минимальное значение, максимальное значение)
int[] createArray(int arrayLen, int minValue, int maxValue)
{
    int index = 0 ;
    int[] numArray = new int[arrayLen];
    while (index < arrayLen)
    {
        numArray[index] = GetRandomMaxIn(minValue,maxValue);
        index++;
    }
    return numArray;
}

//вычисление среднего арифметического массива !с округлением вниз до целого! из-за применяемого типа данных
int midsumNumRoundDown(int[] array)
{
    int midsumNumber = 0;
    int index = 0;
    int len = array.Length;
    while (index < len)
    {
        midsumNumber = midsumNumber + array[index];
        index++;
    }
    midsumNumber = midsumNumber / len;
    return midsumNumber;
}

//(1) создания массива, игнорируя те что нарушают порядок возрастания. Параметры (исходный массив)
int[] RemoveInc(int[] A)
{
    int[] numArray = new int[A.Length];
    numArray[0] = A[0];
    int indexA = 1;
    int indexB = 1;
    int curMin = A[0];
    while (indexA < A.Length)
    {
        if (A[indexA] > curMin)
        {
            numArray[indexB] = A[indexA];
            curMin = A[indexA];
            indexB++;
        }
        indexA++;
    }
    Array.Resize(ref numArray,indexB);
    return numArray;
}

//(2) создание массива отбрасывая числа выше указанного (передаем среднее арифметичское как предельное значние). Параметры (исходный массив, максимальное число)
int[] RemoveAbovek(int[] A, int k)
{
    int[] numArray = new int[A.Length];
    int indexA = 0;
    int indexB = 0;
    while (indexA < A.Length)
    {
        if (A[indexA] <= k)
        {
            numArray[indexB] = A[indexA];
            indexB++;
        }
        indexA++;
    }
    Array.Resize(ref numArray,indexB);
    return numArray;
}

//(3) создание массива отбрасывая четные. Параметры (исходный массив)
int[] RemoveEven(int[] A)
{
    int[] numArray = new int[A.Length];
    int indexA = 0;
    int indexB = 0;

    while (indexA < A.Length)
    {
        if (!(A[indexA] % 2 == 0))
        {
            numArray[indexB] = A[indexA];
            indexB++;
        }
        indexA++;
    }
    Array.Resize(ref numArray,indexB);
    return numArray;
}



int[] A = createArray(10, 1, 99); //cоздаем массив А createArray({количество элементов},{минимальное значение},{максимальное значение})
Console.Write("Исходный массив: ");
showIntArrayInLine(A);

int[] B = RemoveInc(A); //убираем нарушения возрастания ({исходный массив})
Console.Write("Без элементов нарушающих возрастание: ");
showIntArrayInLine(B);
 

int max = midsumNumRoundDown(A); //вычисляем среднее арифметическое массива А
B = RemoveAbovek(A,max); //убираем значения выше предельного значения ({исходный массив},{предельное значение})
Console.Write($"Без элементов больше среднего арифметичского равного {max}: ");
showIntArrayInLine(B);

B = RemoveEven(A); //убираем чётные ({исходный массив})
Console.Write("Без чётных элементов: ");
showIntArrayInLine(B);