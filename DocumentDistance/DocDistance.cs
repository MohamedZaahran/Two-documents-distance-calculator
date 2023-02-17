using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentDistance
{
    class DocDistance
    {
        // *****************************************
        // DON'T CHANGE CLASS OR FUNCTION NAME
        // YOU CAN ADD FUNCTIONS IF YOU NEED TO
        // *****************************************
        /// <summary>
        /// Write an efficient algorithm to calculate the distance between two documents
        /// </summary>
        /// <param name="doc1FilePath">File path of 1st document</param>
        /// <param name="doc2FilePath">File path of 2nd document</param>
        /// <returns>The angle (in degree) between the 2 documents</returns>

        public static double CalculateDistance(string doc1FilePath, string doc2FilePath)
        {
            // TODO comment the following line THEN fill your code here
            //throw new NotImplementedException();

            // Needed Functions :

            Dictionary<string, long> countWordsInFile(string file, Dictionary<string, long> words)
            {
                // Reading the text in .txt files & converting all the letters to lower case letters.
                string content = File.ReadAllText(file);
                content = content.ToLower();

                // For removing all the special characters and removing all extra whitespaces.
                StringBuilder sb = new StringBuilder();
                bool x = false;
                foreach (char c in content)
                {
                    if ((c >= '0' && c <= '9') || (c >= 'a' && c <= 'z'))
                    {
                        sb.Append(c);
                        x = false;
                    }
                    else
                    {
                        if (x == false)
                        {
                            sb.Append(" ");
                            x = true;
                        }
                    }
                }
                content = sb.ToString();
                if (content[0] == ' ') content = content.TrimStart();
                if (content[content.Length - 1] == ' ') content = content.TrimEnd();

                // Count the words frequency in the file.
                string[] contentSplit = content.Split(' ');
                foreach (var word in contentSplit)
                {
                    words.TryGetValue(word, out long currentCount);
                    words[word] = ++currentCount;
                }

                return words;
            }

            double dotProduct(Dictionary<string, long> D1, Dictionary<string, long> D2)
            {
                double sum = 0;
                foreach (var key in D1)
                {
                    if (D2.ContainsKey(key.Key))
                        sum += (D1[key.Key] * D2[key.Key]);
                }
                return sum;
            }

            double vectorAngle(Dictionary<string, long> D1, Dictionary<string, long> D2)
            {
                double upper = dotProduct(D1, D2);
                double lower = Math.Sqrt(dotProduct(D1, D1) * dotProduct(D2, D2));

                return Math.Acos(upper / lower) * (180 / Math.PI);
            }

            //----------------------------------------------------------------------------------------------

            // Returning the distance between the two documents
            Dictionary<string, long> wordsDoc1 = new Dictionary<string, long>();
            Dictionary<string, long> wordsDoc2 = new Dictionary<string, long>();

            return vectorAngle(countWordsInFile(doc1FilePath, wordsDoc1), countWordsInFile(doc2FilePath, wordsDoc2));
        }
    }
}
