using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaboteurX
{
    static class TextToAsciiArtConverter
    {
        public static Dictionary<char, string> BigFontDictionary = new Dictionary<char, string>() { { ' ', "  \n  \n  \n  \n  \n  \n  \n  \n" }, {'-', "         \n         \n         \n  ______ \n |______|\n         \n         \n         \n         " } };
        public static void InitializeLetters()
        {
            var sourceCapital =
@"             ____     _____   _____    ______   ______    _____   _    _   _____        _   _  __  _        __  __   _   _    ____    _____     ____    _____     _____   _______   _    _  __      __ __          __ __   __ __     __  ______ 
     /\     |  _ \   / ____| |  __ \  |  ____| |  ____|  / ____| | |  | | |_   _|      | | | |/ / | |      |  \/  | | \ | |  / __ \  |  __ \   / __ \  |  __ \   / ____| |__   __| | |  | | \ \    / / \ \        / / \ \ / / \ \   / / |___  / 
    /  \    | |_) | | |      | |  | | | |__    | |__    | |  __  | |__| |   | |        | | | ' /  | |      | \  / | |  \| | | |  | | | |__) | | |  | | | |__) | | (___      | |    | |  | |  \ \  / /   \ \  /\  / /   \ V /   \ \_/ /     / /  
   / /\ \   |  _ <  | |      | |  | | |  __|   |  __|   | | |_ | |  __  |   | |    _   | | |  <   | |      | |\/| | | . ` | | |  | | |  ___/  | |  | | |  _  /   \___ \     | |    | |  | |   \ \/ /     \ \/  \/ /     > <     \   /     / /   
  / ____ \  | |_) | | |____  | |__| | | |____  | |      | |__| | | |  | |  _| |_  | |__| | | . \  | |____  | |  | | | |\  | | |__| | | |      | |__| | | | \ \   ____) |    | |    | |__| |    \  /       \  /\  /     / . \     | |     / /__  
 /_/    \_\ |____/   \_____| |_____/  |______| |_|       \_____| |_|  |_| |_____|  \____/  |_|\_\ |______| |_|  |_| |_| \_|  \____/  |_|       \___\_\ |_|  \_\ |_____/     |_|     \____/      \/         \/  \/     /_/ \_\    |_|    /_____| 
                                                                                                                                                                                                                                                
                                                                                                                                                                                                                                                ".Split('\n');
            var sourceLower = @"          _                  _           __           _       _     _   _      _                                                            _                                                    
         | |                | |         / _|         | |     (_)   (_) | |    | |                                                          | |                                                   
   __ _  | |__     ___    __| |   ___  | |_    __ _  | |__    _     _  | | __ | |  _ __ ___    _ __     ___    _ __     __ _   _ __   ___  | |_   _   _  __   __ __      __ __  __  _   _   ____ 
  / _` | | '_ \   / __|  / _` |  / _ \ |  _|  / _` | | '_ \  | |   | | | |/ / | | | '_ ` _ \  | '_ \   / _ \  | '_ \   / _` | | '__| / __| | __| | | | | \ \ / / \ \ /\ / / \ \/ / | | | | |_  / 
 | (_| | | |_) | | (__  | (_| | |  __/ | |   | (_| | | | | | | |   | | |   <  | | | | | | | | | | | | | (_) | | |_) | | (_| | | |    \__ \ | |_  | |_| |  \ V /   \ V  V /   >  <  | |_| |  / /  
  \__,_| |_.__/   \___|  \__,_|  \___| |_|    \__, | |_| |_| |_|   | | |_|\_\ |_| |_| |_| |_| |_| |_|  \___/  | .__/   \__, | |_|    |___/  \__|  \__,_|   \_/     \_/\_/   /_/\_\  \__, | /___| 
                                               __/ |              _/ |                                        | |         | |                                                        __/ |       
                                              |___/              |__/                                         |_|         |_|                                                       |___/        ".Split('\n');
            InsertIntoDictionary(sourceCapital,'A');
            InsertIntoDictionary(sourceLower, 'a');
        }
        public static void InsertIntoDictionary(string[] source,char startingChar)
        {
            int counter = 0;
            int last = 0;
            for (int j = 0; j < source[0].Length; j++)
            {
                bool allWhite = true;
                for (int i = 0; i < source.Length; i++)
                {
                    if(source[i].Length>j)
                        if (source[i][j] != ' ')
                            allWhite = false;
                }
                if (allWhite)
                {
                    string newLetter = "";
                    for (int ii = 0; ii < source.Length; ii++)
                    {
                        for (int jj = last; jj < j; jj++)
                        {
                            if (source[ii].Length > jj)
                                newLetter += source[ii][jj];
                        }
                        newLetter += '\n';
                    }
                    BigFontDictionary.Add((char)(startingChar - 1 + counter), newLetter);
                    counter++;
                    last = j + 1;

                }
            }
        }
        public static string ToAsciiArt(this string str)
        {
            if (str.Length == 0)
                return "";
            string result = "";
            var start = BigFontDictionary[str[0]].Split('\n');
            for (int i = 1; i < str.Length; i++)
            {
                var letter = BigFontDictionary[str[i]].Split('\n');
                for (int j = 0; j < start.Length; j++)
                {
                    start[j] += letter[j];
                }
            }
            for (int i = 0; i < start.Length; i++)
            {
                for (int j = 0; j < start[i].Length; j++)
                {
                    result += start[i][j];
                }
                result += '\n';
            }
            return result;
        }
    }
}
