namespace WorkProject.Models
{
    public class CarParameters
    {
        public CarParameters(int startIndex, int endIndex)
        {
            this.StartIndex = startIndex;
            this.EndIndex = endIndex;
        }

        public int StartIndex { get; set; }
        public int EndIndex { get; set; }

        public bool IsValid 
        {
            get 
            {
                if (StartIndex < 0)
                {
                    return false;
                }

                if (EndIndex < 0)
                {
                    return false;
                }

                return EndIndex >= StartIndex;
            }
        }

        public int ItemsNumber
        {
            get
            {
                if (!IsValid)
                {
                    return 0;
                }

                return EndIndex - StartIndex + 1;
            }
        }
    }
}
