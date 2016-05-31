namespace P2P.WellKnown.P2P
{
    using System;

    [Serializable]
    public class WorkMessage : PPMessage
    {
        private string message;

        public WorkMessage(string msg)
        {
            this.message = msg;
        }

        public string Message
        {
            get
            {
                return this.message;
            }
        }
    }
}

