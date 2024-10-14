using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.BCore.CardProcessing
{
    // What can the user do with the app ? Request card info.
    internal interface ICallCardData
    {
        public void AskForCard();
    }
}
