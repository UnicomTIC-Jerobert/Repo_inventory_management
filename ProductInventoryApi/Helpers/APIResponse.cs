public class APIResponse<T>
{
    public bool Success { get; set; }
    public T Payload { get; set; }
    public string Title { get; set; }
    public List<string> Errors { get; set; } = new List<string>();
}
