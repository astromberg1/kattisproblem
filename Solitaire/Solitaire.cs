using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace peeble5
    {
    class Program
        {


        public const int MAXRADER = 10;




        static byte GetLowPeeble(char[] list, ref Dictionary<string, int> slist)
            {
            string tlist = string.Join("", list);
            //Debug.WriteLine(tlist);
            byte result = 23;

            byte antal = (byte)tlist.Replace("-", "").Length;

            if (slist.ContainsKey(tlist))

                result = (byte)slist[tlist];


            else

                {

                if ((list[0] == 'o') & (list[1] == 'o') & list[2] == '-') 
                    {
                    list[0] = '-';
                    list[1] = '-';
                    list[2] = 'o';
                    result = Math.Min(result, GetLowPeeble(list, ref slist));

                    list[0] = 'o';
                    list[1] = 'o';
                    list[2] = '-';

                    }

                if ((list[0] == '-') & (list[1] == 'o') & list[2] == 'o')
                    {
                    list[0] = 'o';
                    list[1] = '-';
                    list[2] = '-';
                    result = Math.Min(result, GetLowPeeble(list, ref slist));

                    list[0] = '-';
                    list[1] = 'o';
                    list[2] = 'o';

                    }

                if ((list[20] == 'o') & (list[21] == 'o') & list[22] == '-')
                    {
                    list[20] = '-';
                    list[21] = '-';
                    list[22] = 'o';
                    result = Math.Min(result, GetLowPeeble(list, ref slist));

                    list[20] = 'o';
                    list[21] = 'o';
                    list[22] = '-';

                    }

                if ((list[20] == '-') & (list[21] == 'o') & list[22] == 'o')
                    {
                    list[20] = 'o';
                    list[21] = '-';
                    list[22] = '-';
                    result = Math.Min(result, GetLowPeeble(list, ref slist));

                    list[20] = '-';
                    list[21] = 'o';
                    list[22] = 'o';

                    }



                for (int i = 0; i < 23; i++)
                    {
                    if (i < 22)
                        {
                        if ((list[i] == 'o') & (list[i + 1] == 'o'))
                            {
                            if (i < 21)
                                { 
                                if (list[i + 2] == '-')
                                    {

                                    list[i] = '-';
                                    list[i + 1] = '-';
                                    list[i + 2] = 'o';
                                    result = Math.Min(result, GetLowPeeble(list, ref slist));

                                    list[i] = 'o';
                                    list[i + 1] = 'o';
                                    list[i + 2] = '-';

                                    }
                                }
                            if (i > 1)
                                {
                                if (list[i - 1] == '-')
                                    {

                                    list[i - 1] = 'o';
                                    list[i] = '-';
                                    list[i + 1] = '-';
                                    result = Math.Min(result, GetLowPeeble(list, ref slist));
                                    list[i - 1] = '-';
                                    list[i] = 'o';
                                    list[i + 1] = 'o';

                                    }
                                }
                            }
                        }
                    }
                
            
            
                result = Math.Min(result, antal);

                slist.Add(tlist, result);
                }

            return result;
            }



        static void Main(string[] args)
            {
            Dictionary<string, int> slista = new Dictionary<string, int>();
            string[] peebles = new string[20];
            char[] list = new char[25];

            int intal = int.Parse(Console.ReadLine());

            for (int i = 0; i < intal; i++)
                {
                peebles[i] = Console.ReadLine();

                }

            //Stopwatch sw = Stopwatch.StartNew();
            // Do work
            for (int i = 0; i < intal; i++)
                {
                list = peebles[i].ToCharArray();
                byte lres = GetLowPeeble(list, ref slista);
                Console.WriteLine(lres);

                }
            //sw.Stop();
            //TimeSpan elapsedTime = sw.Elapsed;
            //Console.WriteLine(elapsedTime);
            //Console.ReadKey();
            }

        }
    }
