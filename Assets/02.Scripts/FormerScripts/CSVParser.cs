using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace CSVParse
{
    class Program
    {
        static void Main(string[] args)
        {
            string strFile = "testcsv.csv";

            using (FileStream fs = new FileStream(strFile, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8, false))
                {
                    string strLineValue = null;
                    string[] keys = null;
                    string[] values = null;

                    while ((strLineValue = sr.ReadLine()) != null)
                    {
                        if (string.IsNullOrEmpty(strLineValue)) return;

                        if (strLineValue.Substring(0, 1).Equals("#"))
                        {
                            keys = strLineValue.Split(',');

                            keys[0] = keys[0].Replace("#", "");

                            Console.Write("Key : ");
                            
                            for (int nIndex = 0; nIndex < keys.Length; nIndex++) // 결과
                            {
                                Console.Write(keys[nIndex]);
                                if (nIndex != keys.Length - 1)
                                    Console.Write(", ");
                            }

                            Console.WriteLine();

                            continue;
                        }

                        values = strLineValue.Split(',');

                        Console.Write("Value : ");

                        for (int nIndex = 0; nIndex < values.Length; nIndex++) //결과
                        {
                            Console.Write(values[nIndex]);
                            if (nIndex != values.Length - 1)
                                Console.Write(", ");
                        }

                        Console.WriteLine();
                    }
                }
            }
        }
    }
}