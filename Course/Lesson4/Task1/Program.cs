﻿int[] numbers = {1, 2, 3, 4, 5};
int result = 0;

foreach(int number in numbers) {
    result += number;
}
Console.WriteLine($"Сумма всех элиметов в моссиве: {result}");