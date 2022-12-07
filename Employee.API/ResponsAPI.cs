namespace Employee.API
{
    public class ResponsAPI<T>
    {
        public T? Data { get; set; }
        public List<string>? Errors { get; private set; }
        public bool Success => Errors == null;
        public void AddError(string message)
        {
            if (Errors == null)
            {
                Errors = new List<string>();
            }
            Errors.Add(message);
        }
    }
}
