using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace C_Sharp_Lab
{
    delegate System.Collections.Generic.KeyValuePair<TKey, TValue> GenerateElement<TKey, TValue>(int j);
    class TestCollections<TKey, TValue>
    {
        private List<TKey> keys;
        private List<string> strings;
        private Dictionary<TKey,TValue> keyDictionary;
        private Dictionary<string, TValue> stringDictionary;
        GenerateElement<TKey,TValue> generateElement;

        public TestCollections(int amount,GenerateElement<TKey, TValue> generateElement)
        {
            keys = new List<TKey>();
            strings = new List<string>();
            keyDictionary = new Dictionary<TKey, TValue>();
            stringDictionary = new Dictionary<string, TValue>();
            this.generateElement = generateElement;
            for (int i = 0 ; i < amount ; i++)
            {
                KeyValuePair<TKey, TValue> element = generateElement(i);
                keyDictionary.Add(element.Key, element.Value);
                stringDictionary.Add(element.Key.ToString(), element.Value);
                keys.Add(element.Key);
                strings.Add(element.Key.ToString());
            }
        }

        public void SearchTimeKeyList()
        {
            var first = keys[0];
            var middle = keys[keys.Count / 2];
            var last = keys[keys.Count - 1];
            var none = generateElement(keys.Count + 1).Key;
            Stopwatch sw = Stopwatch.StartNew();
            keys.Contains(first);
            sw.Stop();
            Console.WriteLine("Time for the first element: " + sw.Elapsed);
            sw.Restart();
            keys.Contains(middle);
            sw.Stop();
            Console.WriteLine("Time for the middle element: " + sw.Elapsed);
            sw.Restart();
            keys.Contains(last);
            sw.Stop();
            Console.WriteLine("Time for the last element: " + sw.Elapsed);
            sw.Restart();
            keys.Contains(none);
            sw.Stop();
            Console.WriteLine("Time for the element that is not in list: " + sw.Elapsed);
        }

        public void SearchTimeStringList()
        {
            var first = strings[0];
            var middle = strings[keys.Count / 2];
            var last = strings[keys.Count - 1];
            var none = generateElement(strings.Count + 1).Key.ToString();
            Stopwatch sw = Stopwatch.StartNew();
            strings.Contains(first);
            sw.Stop();
            Console.WriteLine("Time for the first element: " + sw.Elapsed);
            sw.Restart();
            strings.Contains(middle);
            sw.Stop();
            Console.WriteLine("Time for the middle element: " + sw.Elapsed);
            sw.Restart();
            strings.Contains(last);
            sw.Stop();
            Console.WriteLine("Time for the last element: " + sw.Elapsed);
            sw.Restart();
            strings.Contains(none);
            sw.Stop();
            Console.WriteLine("Time for the element that is not in list: " + sw.Elapsed);
        }

        public void SearchTimeKeyCollection()
        {
            var first = keys[0];
            var middle = keys[keys.Count / 2];
            var last = keys[keys.Count - 1];
            var none = generateElement(keys.Count + 1).Key;
            var sw = Stopwatch.StartNew();
            keyDictionary.ContainsKey(first);
            sw.Stop();
            Console.WriteLine("Time for the first element: " + sw.Elapsed);
            sw.Restart();
            keyDictionary.ContainsKey(middle);
            sw.Stop();
            Console.WriteLine("Time for the middle element: " + sw.Elapsed);
            sw.Restart();
            keyDictionary.ContainsKey(last);
            sw.Stop();
            Console.WriteLine("Time for the last element: " + sw.Elapsed);
            sw.Restart();
            keyDictionary.ContainsKey(none);
            sw.Stop();
            Console.WriteLine("Time for the element that is not in list: " + sw.Elapsed);
        }

        public void SearchTimeStringCollection()
        {
            var first = stringDictionary[strings[0]];
            var middle = stringDictionary[strings[strings.Count / 2]];
            var last = stringDictionary[strings[strings.Count - 1]];
            var none = generateElement(keyDictionary.Count + 1).Value;
            Stopwatch sw = Stopwatch.StartNew();
            stringDictionary.ContainsValue(first);
            sw.Stop();
            Console.WriteLine("Time for the first element: " + sw.Elapsed);
            sw.Restart();
            stringDictionary.ContainsValue(middle);
            sw.Stop();
            Console.WriteLine("Time for the middle element: " + sw.Elapsed);
            sw.Restart();
            stringDictionary.ContainsValue(last);
            sw.Stop();
            Console.WriteLine("Time for the last element: " + sw.Elapsed);
            sw.Restart();
            stringDictionary.ContainsValue(none);
            sw.Stop();
            Console.WriteLine("Time for the element that is not in list: " + sw.Elapsed);
        }
    }
}
