﻿namespace HexagonalPattern.FrontController.BCore.CardProcessing
{
    // What can the user do with the app ? Request card info.
    interface ICall
    {
        public void RequestCard();
        
        public bool ProcessCard(string input);
    }
}
