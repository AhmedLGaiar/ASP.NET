namespace Day2.VewModel
{
    public enum Status : byte
    {
        Succeeded = 0,
        Failed = 1,
    }
    
    public class TraineeDetails
    {
        public string TName { get; set; }
        public string CName { get; set; }

        public byte _degree;
        public byte Degree
        {
            get { return _degree; }
            set
            {
                _degree = value;
                _status = _degree > 60 ? Status.Succeeded : Status.Failed;
            }
        }

        private Status _status;

        public Status Status
        {
            get { return _status; }
        }

    }
}
