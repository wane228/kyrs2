using System;


namespace obertka
{
    interface IArray
    {
        void Add(int newValue);
        int Find(int index);
        void Remove(int index);
        void Update(int index, int newValue);
    }

    class Obertka : IArray
    {
        public int[] Array1 = { 1, 2, 3, 4, 5, 6, 7 };
        public void Add(int newValue)
        { 
            int lenght = Array1.Length;
            Array.Resize<int>(ref Array1, lenght+1);
            Array1[lenght] = newValue;
        }

        public int Find(int index)
        {
            if (index > Array1.Length - 1 || index < 0)
            {
                Console.WriteLine("Error");
                return 0;
            }
            int lenght = Array1.Length;
            int temp = 0;
            for(int i = 0; i < lenght - 1; i++)
            {
                if(i + 1 == index)
                {
                    temp = Array1[i];
                }
            }
            return temp;
        }
        public void Remove(int index)
        {
            if (index > Array1.Length - 1 || index < 0)
            {
                Console.WriteLine("Error");
                return;
            }
            int[] temp = Array1;
            Array.Resize<int>(ref temp, Array1.Length - 1);
            int j = 0;
            for(int i =0; i < Array1.Length ;i++ )
            {
                if (i != index-1)
                {
                    temp[j] = Array1[i];
                    j++;
                }
            }
            Array1 = temp;
        }
        public void Update(int index, int newValue)
        {
            if(index > Array1.Length - 1 || index < 0  )
            {
                Console.WriteLine("Error");
                return;
            }
            Array1[index - 1] = newValue;
        }
    }

    class Programm
    {
        static void Main()
        {
            Obertka a = new Obertka();

            for (int i = 0; i < a.Array1.Length; i++)
            {
                Console.Write(a.Array1[i]);
            }
            Console.WriteLine();

            a.Add(9);
            a.Add(9);
            a.Add(9);

            for(int i =0; i < a.Array1.Length; i++)
            {
                Console.Write(a.Array1[i]);
            }
            Console.WriteLine();

        }
    }
}
