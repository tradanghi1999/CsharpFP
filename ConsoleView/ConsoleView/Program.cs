﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlClient;
using Entities;
using Utils;
namespace ConsoleView
{
    class Program
    {
        static void Main(string[] args)
        {
            ///ví dụ cuối chương
            //string dbConnect = "server=localhost;database=ITB_CK;user id=ITB_Admin;pwd=123456";
            //DbReader reader = new DbReader(dbConnect);
            //var teams = reader.GetTeamsv2();
            //Console.WriteLine(teams.Count());

            ///BT 2 chương 1
            //bool bul = new F().bulPredicate(false);
            //Console.WriteLine(bul);

            ///BT 3 chương 1

            //BT 4 chương 1

            // BT 1 chương 2
            //F f = new F();
            //string bmi = f.bmiEval(f.bmiCalculator(1.65, 55));
            //Console.WriteLine(bmi);

            //BT Mô phỏng ForEach
            IEnumerable<int> list = new List<int> { 1, 2, 3 };
            IEnumerable<int> mlist = list.NForEach( y => y * 2);
            IEnumerable<int> wlist = list.NWhere(y => y > 2);
            //
            int x = 8;
            Console.WriteLine(x.IsHigher(7));
            //
            F myF = new F();
            //double mR = 24;
            Console.WriteLine(myF.bmiCalculator(1.65, 55).Map(myF.bmiEval));

            
            Console.ReadKey();


        }
    }
}
