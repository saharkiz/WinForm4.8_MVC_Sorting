using System;

namespace WinForm_Model
{
    public class CorrelationIdentifier
    {
        private string _Id; 
        public CorrelationIdentifier(string correlationId)
        {
            _Id = string.IsNullOrWhiteSpace(correlationId)
                ? _Id = Guid.NewGuid().ToString("N")
                : correlationId;
        }
        public CorrelationIdentifier()
        {
            _Id = Guid.NewGuid().ToString("N");
        }

        public string CorrelationId
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_Id))
                    _Id = Guid.NewGuid().ToString("N");
                return _Id;
            }
        }
    }
}
