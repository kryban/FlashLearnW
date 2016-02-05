using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashLearnW.Models
{
    public class StringHelper
    {
        public string RemoveSpecialCharacter(string inputString)
        {
            return Regex.Replace(inputString, @"\W+", "");
        }
    }
}
