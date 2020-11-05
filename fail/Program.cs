using System;
using System.IO;
using System.Threading;

namespace verstkafaila
{
    class Readfromfile
    {
        //public string number;
        //public string name;
        //public string fname;
        //public string phone;
        //public string uid;
        //public string nik;
        //public string wo;
        //public string[] linestruct = new string[7];
        public void Read(string path)
        {
            if (!(File.Exists(path)))
            {
                Console.WriteLine("Ошибка:: Файла не существует");
                return;
            }

            StreamReader sr = new StreamReader(path);
            string line;
            Console.Write("Введите данные поиска: ");
            string data = Console.ReadLine();

            if (data == "")
            {
                Console.WriteLine("Ошибка:: отсутствуют данные для поиска");
                return;
            }

            double ellapledTicks = DateTime.Now.Ticks;

            bool flag = false;

            int count = 0;
            while ((line = sr.ReadLine()) != null)
            {
                string[] linestruct = new string[7];
                int separatorCount = 0;
                for (int i = 0; i < line.Length - 1; i++)
                {
                    if (line[i] == 124)
                    {
                        separatorCount++;

                        int j = i + 1;
                        while (line[j] != 124 && j < line.Length - 1)
                        {
                            if (separatorCount == 1)
                            {
                                linestruct[0] += line[j];
                                j++;
                            }
                            else if (separatorCount == 2)
                            {
                                linestruct[1] += line[j];
                                j++;
                            }
                            else if (separatorCount == 3)
                            {
                                linestruct[2] += line[j];
                                j++;
                            }
                            else if (separatorCount == 4)
                            {
                                linestruct[3] += line[j];
                                j++;
                            }
                            else if (separatorCount == 5)
                            {
                                linestruct[4] += line[j];
                                j++;
                            }
                            else if (separatorCount == 6)
                            {
                                linestruct[5] += line[j];
                                j++;
                            }
                            else if (separatorCount == 7)
                            {
                                linestruct[6] += line[j];
                                j++;
                            }
                            else if (separatorCount > 7)
                            {
                                j++;
                            }
                        }

                        i = j - 1;
                    }
                }


                for (int i = 0; i < linestruct.Length; i++)
                {
                    if (data == linestruct[i])
                    {
                        ellapledTicks = (DateTime.Now.Ticks - ellapledTicks) / 10000000;

                        flag = true;

                        if (separatorCount > 7)
                        {
                            Console.WriteLine("Error");
                            return;
                        }
                        Console.WriteLine(line);
                        Console.WriteLine($"Время поиска: {ellapledTicks}c");
                        return;
                    }
                }

                count++;

                if(count == 200000)
                {
                    //Console.Clear();
                    Console.WriteLine("Подождите, идёт поиск...");
                    count = 0;
                }
            }

            if (flag == false)
            {
                Console.WriteLine("Ничего не найдено");
            }


        }

    }


    class Program
    {
        static void Main()
        {
            Console.Write("Укажите путь к файлу: ");
            string path = Console.ReadLine();
            Readfromfile a = new Readfromfile();
            a.Read(path);
        }
    }
}
