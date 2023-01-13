using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchComparer.Shared.Extentions
{
    public class SearchExtention
    {
        public static int LinearSearch(List<int> arr, int elementToSearch)
        {
            for (int index = 0; index < arr.Count; index++)
            {
                if (arr[index].Equals(elementToSearch))
                    return index;
            }
            return -1;
        }
        public static int BinarySearch(List<int> arr, int elementToSearch)
        {
            int firstIndex = 0;
            int lastIndex = arr.Count - 1;

            // условие прекращения (элемент не представлен)
            while (firstIndex <= lastIndex)
            {
                int middleIndex = (firstIndex + lastIndex) / 2;
                // если средний элемент - целевой элемент, вернуть его индекс
                if (arr[middleIndex].Equals(elementToSearch))
                {
                    return middleIndex;
                }

                // если средний элемент меньше
                // направляем наш индекс в middle+1, убирая первую часть из рассмотрения
                else if (arr[middleIndex] < elementToSearch)
                    firstIndex = middleIndex + 1;

                // если средний элемент больше
                // направляем наш индекс в middle-1, убирая вторую часть из рассмотрения
                else if (arr[middleIndex] > elementToSearch)
                    lastIndex = middleIndex - 1;

            }
            return -1;
        }
        public static int recursiveBinarySearch(List<int> arr, int elementToSearch)
        {
            return recursiveBinarySearchPrivate(arr, 0, arr.Count, elementToSearch);
        }
        public static int jumpSearch(List<int> integers, int elementToSearch)
        {
            int arrayLength = integers.Count;
            int jumpStep = (int)Math.Sqrt(integers.Count);
            int previousStep = 0;

            while (integers[Math.Min(jumpStep, arrayLength) - 1] < elementToSearch)
            {
                previousStep = jumpStep;
                jumpStep += (int)(Math.Sqrt(arrayLength));
                if (previousStep >= arrayLength)
                    return -1;
            }
            while (integers[previousStep] < elementToSearch)
            {
                previousStep++;
                if (previousStep == Math.Min(jumpStep, arrayLength))
                    return -1;
            }

            if (integers[previousStep] == elementToSearch)
                return previousStep;
            return -1;
        }
        public static int interpolationSearch(List<int> integers, int elementToSearch)
        {
            int startIndex = 0;
            int lastIndex = (integers.Count - 1);

            while ((startIndex <= lastIndex) && (elementToSearch >= integers[startIndex]) &&
                   (elementToSearch <= integers[lastIndex]))
            {
                // используем формулу интерполяции для поиска возможной лучшей позиции для существующего элемента
                int pos = startIndex + (((lastIndex - startIndex) /
                  (integers[lastIndex] - integers[startIndex])) *
                                (elementToSearch - integers[startIndex]));

                if (integers[pos] == elementToSearch)
                    return pos;

                if (integers[pos] < elementToSearch)
                    startIndex = pos + 1;

                else
                    lastIndex = pos - 1;
            }
            return -1;
        }
        public static int exponentialSearch(List<int> integers, int elementToSearch)
        {
            if (integers[0] == elementToSearch)
                return 0;
            if (integers[integers.Count - 1] == elementToSearch)
                return integers.Count;

            int range = 1;

            while (range < integers.Count && integers[range] <= elementToSearch)
            {
                range = range * 2;
            }
            return recursiveBinarySearchPrivate(integers, range / 2, Math.Min(range, integers.Count), elementToSearch);
        }
        public static int recursiveBinarySearchPrivate(List<int> arr, int firstElement, int lastElement, int elementToSearch)
        {

            // условие прекращения
            if (lastElement >= firstElement)
            {
                int mid = firstElement + (lastElement - firstElement) / 2;

                // если средний элемент - целевой элемент, вернуть его индекс
                if (arr[mid] == elementToSearch)
                    return mid;

                // если средний элемент больше целевого
                // вызываем метод рекурсивно по суженным данным
                if (arr[mid] > elementToSearch)
                    return recursiveBinarySearchPrivate(arr, firstElement, mid - 1, elementToSearch);

                // также, вызываем метод рекурсивно по суженным данным
                return recursiveBinarySearchPrivate(arr, mid + 1, lastElement, elementToSearch);
            }

            return -1;
        }

    }

}
