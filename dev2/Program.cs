// Задача
// ---
// Имеется числовой массив A заполненный числами из отрезка [minValue; maxValue]. Создать на его основе масив B, отбрасывая те, которые нарушают порядок
// - возрастания (1)
// - элементы, больше 8 (2)
// - знакочередования (3)

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
        // Console.Write(numArray[index] + " "); //debugging code
        index++;
    }
    // Console.WriteLine(); //debugging code
    return numArray;
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

//(2) создание массива отбрасывая числа выше указанного. Параметры (исходный массив, максимальное число)
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

//(3) создание массива отбрасывая нарушающие знакочередование. Параметры (исходный массив)
int[] RemoveSignAlter(int[] A)
{
    int[] numArray = new int[A.Length];
    int indexA = 1;
    int indexB = 1;
    numArray[0] = A[0];
    bool lastNumPositive; 
    
    if(A[0] >= 0){
        lastNumPositive = true;
    }else{
        lastNumPositive = false;
    };

    while (indexA < A.Length)
    {
        if ((A[indexA] >= 0 && !lastNumPositive) || (A[indexA] < 0 && lastNumPositive))
        {
            numArray[indexB] = A[indexA];
            lastNumPositive = !lastNumPositive;
            indexB++;
        }
        indexA++;
    }
    Array.Resize(ref numArray,indexB);
    return numArray;
}



int[] A = createArray(10,-10,20); //cоздаем массив А createArray({количество элементов},{минимальное значение},{максимальное значение})
Console.Write("Исходный массив: ");
showIntArrayInLine(A);

int[] B = RemoveInc(A); //убирваем нарушения возрастания ({исходный массив})
Console.Write("Без элементов нарушающих возрастание: ");
showIntArrayInLine(B);
 
B = RemoveAbovek(A,8); //убирваем значения выше 8 ({исходный массив},{предельное значение})
Console.Write("Без элементов больше 8: ");
showIntArrayInLine(B);

B = RemoveSignAlter(A); //убирваем нарушения возрастания ({исходный массив})
Console.Write("Без элементов нарушающих знакочередование: ");
showIntArrayInLine(B);
