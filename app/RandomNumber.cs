using System;

class RandomNumber

    {
        private Random random = new Random();
        public static List<string> multipliers =new List<string> { "x15", "x16", "x17", "x18", "x19", "x20" };
        int count=0;
        
        public string GenerateMultiplier()
        {
            
            int index = random.Next(multipliers.Count);
            count+=2;//Change the value depending of your wanted probability
            AddProbability(multipliers[index]);
            
            return multipliers[index];
        }

        private void AddProbability(string element)
        {

            for (int i = 0; i < count; i++)
            {
                multipliers.Add(element);
            }
        }

    }
