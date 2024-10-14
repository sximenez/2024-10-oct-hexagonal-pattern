using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.BCore.CardProcessing
{
    // What does the core need satisfy the user ? Obtain card info.
    internal interface IReplyCardData
    {
        public void FindCard(string input);
    }
}
