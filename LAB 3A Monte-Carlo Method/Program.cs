using System;

namespace LAB_3A_Monte_Carlo_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length != 1) throw new AccessViolationException();
                
                var maxIterations = int.Parse(args[0]);
                RunGameEngine(maxIterations);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please provide a valid integer representing the number of iterations");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("You should only input one parameter");    
            }
        }
        

        private static void RunGameEngine(int maxIters)
        {
            var prng = new Random();
            static (double,double) RandomPair(Random prng)
            {
                return (prng.NextDouble(), prng.NextDouble());
            }

            static double Hy(double x, double y)
            {
                return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            }

            bool done = false;
            int iteration = 0;
            int CircleCount = 0;
            do
            {               
                iteration += 1;
                var (x, y) = RandomPair(prng);
                var hy = Hy(x, y);

                if (hy <= 1)
                {
                    CircleCount += 1;
                }

                done = iteration >= maxIters;

            } while (!done);

            double TargetPi = 4.0 * CircleCount / maxIters;
            double AbsoluteDif = Math.Abs(TargetPi - Math.PI);
            Console.WriteLine($"The result of Monte-Carlo Method with {maxIters} iterations is {TargetPi}");
            Console.WriteLine($"The difference between the result and library-provided value of π is {AbsoluteDif}");
        }
    }
}

//Questions

//1. Why do we multiply the value from step 5 above by 4?
//   Area of the quater circle is Pi/4, thus the times 4.

//2. What do you observe in the output when running your program with parameters of increasing size?
//   The precision increases with more iterations. 

//3. If you run the program multiple times with the same parameter, does the output remain the same? Why or why not?
//   The output is most likely different every time, for the coordinates are generated randomly,  
//   so every time is a different case.

//4. Find a parameter that requires multiple seconds of run time.What is that parameter?
//   100000

//5. How accurate is the estimated value of pi?
//   1/100

//6. Research one other use of Monte-Carlo methods.Record it in your exercise submission and be prepared to discuss it in class.
// See Below

// The ratio of the coin lands on one side when filpping it for a certain amount of times.

//namespace FlippingCoins
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Random prng = new Random();

//            try
//            {
//                if (args.Length != 1) throw new AccessViolationException();

//                var times = int.Parse(args[0]);
//                int count = 0;

//                for (int i = 0; i < times; i++)
//                {
//                    int x = RandomSide(prng);

//                    if (x == 1)
//                    {
//                        count += 1;
//                    }
//                }

//                var Ratio = 1.0 * count / times;

//                Console.WriteLine($"The ratio of flipping {times} times is{Ratio}");

//            }
//            catch (FormatException)
//            {
//                Console.WriteLine("count must be a  valid integer");
//            }
//            catch (ArgumentException)
//            {
//                Console.WriteLine("You should only input one parameter");
//            }
//        }


//        static int RandomSide(Random prng)
//        {
//            return (prng.Next(1, 3));
//        }

//    }
//}
