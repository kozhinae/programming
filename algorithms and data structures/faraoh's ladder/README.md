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

# Solution - Dynamic programming
Let it be required to extend a staircase having N steps so that it has n, where n<=N, N is much larger than n. Suppose that we know the optimal distribution of steps when there are less than n steps in the new staircase. Let h_k be the number of the old staircase where the k-th new staircase ends. Obviously, this k-th step starts at (h_(k-1)+1)-th old step. We denote the added area shown in the picture 1 by g(h_(k-1)+1, h_k). The general problem is to find the values h1, h2...h_(k-1), at which the sum of k values g(1, h_1) + g(h_1 + 1, h_2) + ... + g(h_(k-1)+1, h_k) (at a given k = n, h_k = h) is the smallest, we denote this smallest value by f_n(h_n). Note that the sum of the first n - 1 summands in which h_n is not included takes the smallest value f_n-1(h_n-1) -this is the same problem for one less number of steps.   
As a result, we obtain R. Bellman's formula f_k(h_k) = min(f_k-1(h_k-1) + g(h_(k-1)+1, h_k)), which allows us to consistently find the numbers f_k(h_k) (at all k<=n, h_k <= h) at each step. It should be understood as follows: to find the minimum, we should assign to k all possible values starting from 1, and for each value we should find and remember the value h_k-1 delivering the smallest value f_k(h_k). And then, having reached the last value k = n, it is necessary to go back and find all optimal values h_n-1, h_n-2, ..., h1(see red arrows in picture 2).
![image 1](https://github.com/kozhinae/programming/assets/89837526/2593c746-4fcf-4024-ac41-553f5a057a50)

![image 2](https://github.com/kozhinae/programming/assets/89837526/febc8703-97d6-4af8-83c7-704c456e4a3c)

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
