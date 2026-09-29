using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Castle
{
    internal class GameMain
    {
        private CastleObject castle;

        public GameMain(int investment, int background)
        {
            castle = new CastleObject(investment, background);
        }

        public CastleObject getCastle()
        {
            return castle;
        }

        internal void NewTurn()
        {
            castle.NewTurn();
        }
    }
}
