using System;
using System.Collections.Generic;
using System.Text;

namespace LookAlive
{
    class PingResult
    {
        private bool _isAlive;
        private int _responseTimeMs;
        private string _pingError;

        public bool IsAlive
        {
            get { return _isAlive; }
        }

        public int ResponseTimeMs
        {
            get { return _responseTimeMs; }
        }

        public string PingError
        {
            get { return _pingError; }
        }

        public PingResult(bool isAlive, int responseTimeMs)
        {
			_isAlive = isAlive;
			_responseTimeMs = responseTimeMs;
        }

        public PingResult(string pingError)
        {
			_pingError = pingError;
        }
    }
}
