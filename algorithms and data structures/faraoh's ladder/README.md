# Problem definition
Archaeologists have excavated an ancient Temple, to the entrance of which leads a staircase, 1 (one) meter wide, of M steps of different lengths and heights. The staircase is built of 1x1x1 meter stone blocks. Archaeologists want to make the staircase consist of fewer N steps for the convenience of tourists. For this purpose, they can also install 1x1x1 stone blocks. What is the minimum number of blocks needed to make a staircase of N steps if the initial length and height of each step are known. The heights and lengths of the steps of the new staircase may vary.

# Input data
The first line contains two integers M and N (1 ≤ N < M ≤ 100). Then there are M lines containing a pair of integers L and H - length and height of the i-th step respectively (1 ≤ L, H ≤ 101). The steps are numbered from bottom to top.

# Output data
In the output file print a single number - the answer to the task.

# Example
Input data  
5 3  
4 2  
1 2  
5 2  
1 2  
2 1  
Output data   
3

[Solved using the R.Bellman formula from the article of the journal "Quantum"](http://kvant.mccme.ru/1991/10/dinamicheskoe_programmirovanie.htm)

# Условие задачи.
Археологи раскопали Древний Храм, ко входу в который ведет лестница, шириной в 1 (один) метр, из М ступенек различной длины и высоты. Лестница построена из каменных блоков 1x1x1 метр. Археологи хотят для удобства туристов, чтобы лестница состояла из меньшего количества ступенек N. Для этого они могут также устанавливать каменные блоки 1x1x1. Какое минимальное количество блоков необходимо, чтобы сделать лестницу в N ступенек, если известны начальная длина и высота каждой ступеньки. Высоты и длины ступенек новой лестницы могут различаться.

# Входные данные
В первой строке через пробел заданы два целых числа M и N (1 ≤ N < M ≤ 100). Далее идут M строк, содержащих пару целых чисел L и H - длина и высота i-ой ступеньки соответственно (1 ≤ L, H ≤ 101). Ступеньки нумеруются снизу вверх.

# Выходные данные
В выходной файл выведите единственное число - ответ на задачу.

# Пример
входные данные  
5 3  
4 2  
1 2  
5 2  
1 2  
2 1  
выходные данные  
3
