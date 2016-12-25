using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wallace_solution
    {

    class Program
        {
        private static int max(int a, int b)
            {
            return (a > b) ? a : b;
            }


        private static int wallace(int wantedWeight, List<int> weightsVec, int sizeVar, int sumOfElements)
            {


            if (sizeVar > 1)
                {
                if (sumOfElements < 1000)
                    {
                    return sumOfElements;
                    }




                int[,] K = new int[2100, 2100];







                int w;
                int sum;
                List<int> weights = new List<int>();

               
             

                for (int i = 0; i <= sizeVar; i++)
                    {
                    K[0, i] = 0;
                    }

                for (int i = 0; i <= wantedWeight; i++)
                    {
                    K[i, 0] = 0;
                    }



                for (int i = 0; i <= sizeVar; i++)
                    {
                    for (w = 0; w <= wantedWeight; w++)
                        {

                        if (i == 0 || w == 0)
                            {
                            K[i, w] = 0;
                            }
                        else if (weightsVec[i - 1] <= w)
                            {
                            sum = weightsVec[i - 1] + K[i - 1, w - weightsVec[i - 1]];
                            K[i, w] = max(K[i - 1, w], sum);

                            }
                        else
                            {
                            K[i, w] = K[i - 1, w];

                            }

                        weights.Add(K[i, w]);
                        }
                    }


                if (weights.Contains(1000))
                    return 1000;
                else if (weights.Max() > 1000)
                        {
                        List<int> ls = weights.Distinct().ToList();



                        var itHigh = ls.OrderBy(n => n)
                         .FirstOrDefault(n => 1000 < n);
                        var itLow = ls.OrderByDescending(n => n)
                      .FirstOrDefault(n => 1000 > n);

                        

                        if ((itLow == 1000) || ((itHigh - 1000) > (1000 - itLow)))
                            {

                            return itLow;
                            }
                        else
                            {

                            return itHigh;
                            }
                        }
                    else
                        return weights.Max();


                    

                }


            else
                {
                return weightsVec[0];
                }

            }


            static void Main(string[] args)
                {
                int numberOfWeights;
                numberOfWeights = int.Parse(Console.ReadLine());

                List<int> weights = new List<int>();
                int weight;
            int min = 1001;
            int sum = 0;
            
                for (int i = 0; i < numberOfWeights; i++)
                    {
                    weight = int.Parse(Console.ReadLine());
                //if (weight < min)
                //    min = weight;
                //sum = sum + weight;
                    weights.Add(weight);

                    }

            // Sort vikter , in ascending order (1 - 1000)
            //weights.Sort();
            min = weights.Min();
            sum = weights.Sum();

            int maxWeight = 1000 + min;
            if (!(weights.Contains(1000)))
                {
                if (sum == 1000)
                    Console.WriteLine(1000);
                else



                    Console.WriteLine(wallace(maxWeight, weights, numberOfWeights, sum));
                }
            else
                Console.WriteLine(1000);
            Console.ReadKey();

                }
            }
        }

