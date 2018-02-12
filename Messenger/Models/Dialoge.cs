using System;

namespace Messenger
{
    public class Dialoge
    {
        public bool ComeIn { get; set; }
        public string MessageText { get; set; }
        public string Author { get; set; }
        public DateTime DtMsg { get; set; }

        public override string ToString()
        {
            TimeSpan tt = DtMsg.TimeOfDay;
            
            return String.Format("[{0}]{1} = {2}", Author, MessageText, tt);
        }
    }
}